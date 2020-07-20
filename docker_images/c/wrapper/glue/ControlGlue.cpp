// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#include <iostream>
#include "ControlGlue.h"
#include "ModuleGlue.h"
#include "RegistryGlue.h"
#include "ServiceGlue.h"
#include "json.h"

#if unix
#include "unistd.h"
#endif

using namespace std;

extern ModuleGlue module_glue;
extern RegistryGlue registry_glue;
extern ServiceGlue service_glue;

ControlGlue::ControlGlue()
{
}

ControlGlue::~ControlGlue()
{
}

void ControlGlue::CleanupResources()
{
    try
    {
        module_glue.CleanupResources();
    }
    catch (runtime_error)
    {
        cout << "Ignoring exception on module cleanup" << endl;
    }
    try
    {
        service_glue.CleanupResources();
    }
    catch (runtime_error)
    {
        cout << "Ignoring exception on service cleanup" << endl;
    }
    try
    {
        registry_glue.CleanupResources();
    }
    catch (runtime_error)
    {
        cout << "Ignoring exception on registry cleanup" << endl;
    }
}


void ControlGlue::PrintMessage(const char* message)
{
    cout << message;
}

std::string ControlGlue::GetCapabilities()
{
    Json json;
    json.setBool("flags.v2_connect_group", false);
    json.setBool("flags.system_control_app", false);
    return json.serializeToString();
}

#define stringize(s) #s

std::string ControlGlue::GetWrapperStats()
{
    Json json;
    json.setString("language", "C");
    json.setString("languageVersion", stringize(HORTON_COMPILER));
#if unix
    json.setNumber("wrapperPid", getpid());
#endif
    return json.serializeToString();
}


