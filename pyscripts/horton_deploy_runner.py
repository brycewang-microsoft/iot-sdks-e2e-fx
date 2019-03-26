#!/usr/bin/env python
# Copyright (c) Microsoft. All rights reserved.
# Licensed under the MIT license. See LICENSE file in the project root for
# full license information.
#
# filename: horton_deploy_runner.py
# author:   v-greach@microsoft.com

import sys
import os
import json
import shutil
import pathlib
import traceback
from colorama import init, Fore, Back, Style
from horton_set_image_params import HortonSetImageParams
class DeployHorton:

    def __init__(self, args):

        init(convert=True)
        home_dir = self.get_home_path()
        input_manifest_file = home_dir + "/horton/iothub_module_and_device.json"
        save_manifest_file  = home_dir + "/horton/deployment_template.json"

        try:
            shutil.copy(input_manifest_file, save_manifest_file)
        except:
            print(Fore.RED + "Exception copying file: " + input_manifest_file, file=sys.stderr)
            traceback.print_exc()
            print(Fore.RESET, file=sys.stderr)

        HortonSetImageParams(save_manifest_file, 'testObject', "iotsdke2e.azurecr.io/pythonpreview-e2e-v2:vsts-14334")

        print("Complete")
        exit(0)

    def get_home_path(self):
        home_dir = str(pathlib.Path.home())
        from os.path import expanduser
        home_dir = expanduser("~")
        home_dir = os.path.normpath(home_dir)
        home_dir = home_dir.replace('\\', '/')
        if ':/' in home_dir:
            home_dir = home_dir[2:]
        return home_dir

"""
Uber script:

1. copy template json to place where it can be modified
    cp iothub_module_and_device.json deployment_template.json
2. call script to set image name and createOptions
    python ./horton_set_image_params.py deployment_template.json testObject image "iotsdke2e.azurecr.io/pythonpreview-e2e-v2:vsts-14334"
    python ./horton_set_image_params.py deployment_template.json serviceObject image "iotsdke2e.azurecr.io/edge-e2e-node6:latest"
    python ./horton_set_image_params.py deployment_template.json serviceObject createOptions '"HostConfig": {"PortBindings": {"8080/tcp": [{"HostPort": "8071"}],"22/tcp": [{"HostPort": "8171"}]},"CapAdd": "SYS_PTRACE"}'
4. call script to create identities:
    python ./horton_create_identities.py deployment_template.json
3. call script to create containers
    python ./horton_create_containers.py deployment_template.json

--- run test ---

4. call script to remove identities
    python ./horton_delete_identities.py deployment_template.json
"""


if __name__ == "__main__":
    horton_deploymnet = DeployHorton(sys.argv[1:])

