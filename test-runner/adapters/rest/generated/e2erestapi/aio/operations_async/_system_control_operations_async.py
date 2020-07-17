# coding=utf-8
# --------------------------------------------------------------------------
# Code generated by Microsoft (R) AutoRest Code Generator.
# Changes may cause incorrect behavior and will be lost if the code is
# regenerated.
# --------------------------------------------------------------------------

from msrest.pipeline import ClientRawResponse
from msrest.exceptions import HttpOperationError

from ... import models


class SystemControlOperations:
    """SystemControlOperations async operations.

    You should not instantiate directly this class, but create a Client instance that will create it for you and attach it as attribute.

    :param client: Client for service requests.
    :param config: Configuration of service client.
    :param serializer: An object model serializer.
    :param deserializer: An object model deserializer.
    """

    models = models

    def __init__(self, client, config, serializer, deserializer) -> None:

        self._client = client
        self._serialize = serializer
        self._deserialize = deserializer

        self.config = config

    async def set_network_destination(
        self, ip, transport_type, *, custom_headers=None, raw=False, **operation_config
    ):
        """Set destination for network disconnect ops.

        :param ip:
        :type ip: str
        :param transport_type: Transport to use. Possible values include:
         'amqp', 'amqpws', 'mqtt', 'mqttws', 'http'
        :type transport_type: str
        :param dict custom_headers: headers that will be added to the request
        :param bool raw: returns the direct response alongside the
         deserialized response
        :param operation_config: :ref:`Operation configuration
         overrides<msrest:optionsforoperations>`.
        :return: None or ClientRawResponse if raw=true
        :rtype: None or ~msrest.pipeline.ClientRawResponse
        :raises:
         :class:`HttpOperationError<msrest.exceptions.HttpOperationError>`
        """
        # Construct URL
        url = self.set_network_destination.metadata["url"]
        path_format_arguments = {
            "ip": self._serialize.url("ip", ip, "str"),
            "transportType": self._serialize.url(
                "transport_type", transport_type, "str"
            ),
        }
        url = self._client.format_url(url, **path_format_arguments)

        # Construct parameters
        query_parameters = {}

        # Construct headers
        header_parameters = {}
        if custom_headers:
            header_parameters.update(custom_headers)

        # Construct and send request
        request = self._client.put(url, query_parameters, header_parameters)
        response = await self._client.async_send(
            request, stream=False, **operation_config
        )

        if response.status_code not in [200]:
            raise HttpOperationError(self._deserialize, response)

        if raw:
            client_raw_response = ClientRawResponse(None, response)
            return client_raw_response

    set_network_destination.metadata = {
        "url": "/systemControl/setNetworkDestination/{ip}/{transportType}"
    }

    async def disconnect_network(
        self, disconnect_type, *, custom_headers=None, raw=False, **operation_config
    ):
        """Simulate a network disconnection.

        :param disconnect_type: disconnect method for dropped connection
         tests. Possible values include: 'DROP', 'REJECT'
        :type disconnect_type: str
        :param dict custom_headers: headers that will be added to the request
        :param bool raw: returns the direct response alongside the
         deserialized response
        :param operation_config: :ref:`Operation configuration
         overrides<msrest:optionsforoperations>`.
        :return: None or ClientRawResponse if raw=true
        :rtype: None or ~msrest.pipeline.ClientRawResponse
        :raises:
         :class:`HttpOperationError<msrest.exceptions.HttpOperationError>`
        """
        # Construct URL
        url = self.disconnect_network.metadata["url"]
        path_format_arguments = {
            "disconnectType": self._serialize.url(
                "disconnect_type", disconnect_type, "str"
            )
        }
        url = self._client.format_url(url, **path_format_arguments)

        # Construct parameters
        query_parameters = {}

        # Construct headers
        header_parameters = {}
        if custom_headers:
            header_parameters.update(custom_headers)

        # Construct and send request
        request = self._client.put(url, query_parameters, header_parameters)
        response = await self._client.async_send(
            request, stream=False, **operation_config
        )

        if response.status_code not in [200]:
            raise HttpOperationError(self._deserialize, response)

        if raw:
            client_raw_response = ClientRawResponse(None, response)
            return client_raw_response

    disconnect_network.metadata = {
        "url": "/systemControl/disconnectNetwork/{disconnectType}"
    }

    async def reconnect_network(
        self, *, custom_headers=None, raw=False, **operation_config
    ):
        """Reconnect th networrk after a simulated network disconnection.

        :param dict custom_headers: headers that will be added to the request
        :param bool raw: returns the direct response alongside the
         deserialized response
        :param operation_config: :ref:`Operation configuration
         overrides<msrest:optionsforoperations>`.
        :return: None or ClientRawResponse if raw=true
        :rtype: None or ~msrest.pipeline.ClientRawResponse
        :raises:
         :class:`HttpOperationError<msrest.exceptions.HttpOperationError>`
        """
        # Construct URL
        url = self.reconnect_network.metadata["url"]

        # Construct parameters
        query_parameters = {}

        # Construct headers
        header_parameters = {}
        if custom_headers:
            header_parameters.update(custom_headers)

        # Construct and send request
        request = self._client.put(url, query_parameters, header_parameters)
        response = await self._client.async_send(
            request, stream=False, **operation_config
        )

        if response.status_code not in [200]:
            raise HttpOperationError(self._deserialize, response)

        if raw:
            client_raw_response = ClientRawResponse(None, response)
            return client_raw_response

    reconnect_network.metadata = {"url": "/systemControl/reconnectNetwork"}

    async def get_system_stats(
        self, pid, *, custom_headers=None, raw=False, **operation_config
    ):
        """Get statistics about the operation of the operating system.

        :param pid: Process ID for the wrapper process
        :type pid: int
        :param dict custom_headers: headers that will be added to the request
        :param bool raw: returns the direct response alongside the
         deserialized response
        :param operation_config: :ref:`Operation configuration
         overrides<msrest:optionsforoperations>`.
        :return: object or ClientRawResponse if raw=true
        :rtype: object or ~msrest.pipeline.ClientRawResponse
        :raises:
         :class:`HttpOperationError<msrest.exceptions.HttpOperationError>`
        """
        # Construct URL
        url = self.get_system_stats.metadata["url"]
        path_format_arguments = {"pid": self._serialize.url("pid", pid, "int")}
        url = self._client.format_url(url, **path_format_arguments)

        # Construct parameters
        query_parameters = {}

        # Construct headers
        header_parameters = {}
        header_parameters["Accept"] = "application/json"
        if custom_headers:
            header_parameters.update(custom_headers)

        # Construct and send request
        request = self._client.get(url, query_parameters, header_parameters)
        response = await self._client.async_send(
            request, stream=False, **operation_config
        )

        if response.status_code not in [200]:
            raise HttpOperationError(self._deserialize, response)

        deserialized = None
        if response.status_code == 200:
            deserialized = self._deserialize("object", response)

        if raw:
            client_raw_response = ClientRawResponse(deserialized, response)
            return client_raw_response

        return deserialized

    get_system_stats.metadata = {"url": "/systemControl/systemStats/{pid}"}
