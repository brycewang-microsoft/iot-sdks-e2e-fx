#!/usr/bin/env python

# Copyright (c) Microsoft. All rights reserved.
# Licensed under the MIT license. See LICENSE file in the project root for
# full license information.
import time
from azure.eventhub import EventHubClient
from azure.eventhub.common import Offset
from ..print_message import print_message

# our receive loop cycles through our 4 partitions, waiting for
# RECEIVE_CYCLE_TIME seconds at each partition for a message to arrive
RECEIVE_CYCLE_TIME = 0.25

object_list = []


class EventHubApi:
    def __init__(self):
        global object_list
        self.client = None
        self.receivers = []
        object_list.append(self)

    def connect(self, connection_string):
        print_message("EventHubApi: connecting EventHubClient")
        self.client = EventHubClient.from_iothub_connection_string(connection_string)
        print("EventHubApi: enabling EventHub telemetry")
        # partition_ids = self.client.get_eventhub_info()["partition_ids"]
        partition_ids = [0, 1, 2, 3]
        for id in partition_ids:
            print_message("EventHubApi: adding receiver for partition {}".format(id))
            receiver = self.client.add_receiver(
                "$default", id, operation="/messages/events", offset=Offset("@latest")
            )
            self.receivers.append(receiver)
        print_message("EventHubApi: starting client")
        self.client.run()
        print_message("EventHubApi: ready")

    def disconnect(self):
        if self in object_list:
            object_list.remove(self)
        if self.client:
            self.client.stop()
            self.client = None

    def wait_for_next_event(self, device_id, timeout, expected=None):
        print_message("EventHubApi: waiting for next event for {}".format(device_id))
        start_time = time.time()
        while (time.time() - start_time) < timeout:
            for receiver in self.receivers:
                batch = receiver.receive(max_batch_size=1, timeout=RECEIVE_CYCLE_TIME)
                if batch and (batch[0].device_id.decode("ascii") == device_id):
                    print_message(
                        "EventHubApi: received event: {}".format(batch[0].body_as_str())
                    )
                    obj = batch[0].body_as_json()
                    if expected:
                        if expected == obj:
                            print_message("EventHubApi: message received as expected")
                            return obj
                        else:
                            print_message("EventHubApi: unexpected message.  skipping")
                    else:
                        return obj
