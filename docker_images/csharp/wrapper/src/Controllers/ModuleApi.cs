/*
 * Azure IOT End-to-End Test Wrapper Rest Api
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 *
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;

using Microsoft.AspNetCore.Authorization;
using IO.Swagger.Models;

// added 1 line in merge
using System.Threading.Tasks;

namespace IO.Swagger.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [ApiController]
    public class ModuleApiController : ControllerBase
    {
        // Added 1 line in merge
        static internal ModuleGlue module_glue = new ModuleGlue();

        /// <summary>
        /// Connect to the azure IoT Hub as a module
        /// </summary>

        /// <param name="transportType">Transport to use</param>
        /// <param name="connectionString">connection string</param>
        /// <param name="caCertificate"></param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/connect/{transportType}")]
        [ValidateModelState]
        [SwaggerOperation("ModuleConnect")]
        [SwaggerResponse(statusCode: 200, type: typeof(ConnectResponse), description: "OK")]
        public virtual IActionResult ModuleConnect([FromRoute][Required]string transportType, [FromQuery][Required()]string connectionString, [FromBody]Certificate caCertificate)
        {
            // Replaced impl in merge
            Task<ConnectResponse> t = module_glue.ConnectAsync(transportType, connectionString, caCertificate);
            t.Wait();
            return new ObjectResult(t.Result);
        }

        /// <summary>
        /// Connect the module
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/connect2")]
        [ValidateModelState]
        [SwaggerOperation("ModuleConnect2")]
        public virtual IActionResult ModuleConnect2([FromRoute][Required]string connectionId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Connect to the azure IoT Hub as a module using the environment variables
        /// </summary>

        /// <param name="transportType">Transport to use</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/connectFromEnvironment/{transportType}")]
        [ValidateModelState]
        [SwaggerOperation("ModuleConnectFromEnvironment")]
        [SwaggerResponse(statusCode: 200, type: typeof(ConnectResponse), description: "OK")]
        public virtual IActionResult ModuleConnectFromEnvironment([FromRoute][Required]string transportType)
        {
            // replaced impl in merge
            Task<ConnectResponse> t = module_glue.ConnectFromEnvironmentAsync(transportType);
            t.Wait();
            return new ObjectResult(t.Result);
        }

        /// <summary>
        /// Create a module client from a connection string
        /// </summary>

        /// <param name="transportType">Transport to use</param>
        /// <param name="connectionString">connection string</param>
        /// <param name="caCertificate"></param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/createFromConnectionstring/{transportType}")]
        [ValidateModelState]
        [SwaggerOperation("ModuleCreateFromConnectionString")]
        [SwaggerResponse(statusCode: 200, type: typeof(ConnectResponse), description: "OK")]
        public virtual IActionResult ModuleCreateFromConnectionString([FromRoute][Required]string transportType, [FromQuery][Required()]string connectionString, [FromBody]Certificate caCertificate)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(ConnectResponse));

            string exampleJson = null;
            exampleJson = "{\"empty\": false}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<ConnectResponse>(exampleJson)
            : default(ConnectResponse);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Create a module client using the EdgeHub environment
        /// </summary>

        /// <param name="transportType">Transport to use</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/createFromEnvironment/{transportType}")]
        [ValidateModelState]
        [SwaggerOperation("ModuleCreateFromEnvironment")]
        [SwaggerResponse(statusCode: 200, type: typeof(ConnectResponse), description: "OK")]
        public virtual IActionResult ModuleCreateFromEnvironment([FromRoute][Required]string transportType)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(ConnectResponse));

            string exampleJson = null;
            exampleJson = "{\"empty\": false}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<ConnectResponse>(exampleJson)
            : default(ConnectResponse);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Create a module client from a symmetric key
        /// </summary>

        /// <param name="transportType">Transport to use</param>
        /// <param name="deviceId"></param>
        /// <param name="moduleId"></param>
        /// <param name="hostname">name of the host to connect to</param>
        /// <param name="symmetricKey">key to use for connection</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/createFromSymmetricKey/{deviceId}/{moduleId}/{transportType}")]
        [ValidateModelState]
        [SwaggerOperation("ModuleCreateFromSymmetricKey")]
        [SwaggerResponse(statusCode: 200, type: typeof(ConnectResponse), description: "OK")]
        public virtual IActionResult ModuleCreateFromSymmetricKey([FromRoute][Required]string transportType, [FromRoute][Required]string deviceId, [FromRoute][Required]string moduleId, [FromQuery][Required()]string hostname, [FromQuery][Required()]string symmetricKey)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(ConnectResponse));

            string exampleJson = null;
            exampleJson = "{\"empty\": false}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<ConnectResponse>(exampleJson)
            : default(ConnectResponse);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Create a module client from X509 credentials
        /// </summary>

        /// <param name="transportType">Transport to use</param>
        /// <param name="x509"></param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/createFromX509/{transportType}")]
        [ValidateModelState]
        [SwaggerOperation("ModuleCreateFromX509")]
        [SwaggerResponse(statusCode: 200, type: typeof(ConnectResponse), description: "OK")]
        public virtual IActionResult ModuleCreateFromX509([FromRoute][Required]string transportType, [FromBody]Object x509)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(ConnectResponse));

            string exampleJson = null;
            exampleJson = "{\"empty\": false}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<ConnectResponse>(exampleJson)
            : default(ConnectResponse);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Disonnect and destroy the module client
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/destroy")]
        [ValidateModelState]
        [SwaggerOperation("ModuleDestroy")]
        public virtual IActionResult ModuleDestroy([FromRoute][Required]string connectionId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Disconnect the module
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/disconnect")]
        [ValidateModelState]
        [SwaggerOperation("ModuleDisconnect")]
        public virtual IActionResult ModuleDisconnect([FromRoute][Required]string connectionId)
        {
        
            // Replaced impl in merge
            module_glue.DisconnectAsync(connectionId).Wait();
            return StatusCode(200);
        }

        /// <summary>
        /// Disonnect the module
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/disconnect2")]
        [ValidateModelState]
        [SwaggerOperation("ModuleDisconnect2")]
        public virtual IActionResult ModuleDisconnect2([FromRoute][Required]string connectionId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Enable input messages
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/enableInputMessages")]
        [ValidateModelState]
        [SwaggerOperation("ModuleEnableInputMessages")]
        public virtual IActionResult ModuleEnableInputMessages([FromRoute][Required]string connectionId)
        {
            // Replaced impl in merge
            module_glue.EnableInputMessagesAsync(connectionId).Wait();
            return StatusCode(200);
        }

        /// <summary>
        /// Enable methods
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/enableMethods")]
        [ValidateModelState]
        [SwaggerOperation("ModuleEnableMethods")]
        public virtual IActionResult ModuleEnableMethods([FromRoute][Required]string connectionId)
        {
            // Replaced impl in merge
            module_glue.EnableMethodsAsync(connectionId).Wait();
            return StatusCode(200);
        }

        /// <summary>
        /// Enable module twins
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/enableTwin")]
        [ValidateModelState]
        [SwaggerOperation("ModuleEnableTwin")]
        public virtual IActionResult ModuleEnableTwin([FromRoute][Required]string connectionId)
        {
            // Replaced impl in merge
            module_glue.EnableTwinAsync(connectionId).Wait();
            return StatusCode(200);
        }

        /// <summary>
        /// get the current connection status
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/module/{connectionId}/connectionStatus")]
        [ValidateModelState]
        [SwaggerOperation("ModuleGetConnectionStatus")]
        [SwaggerResponse(statusCode: 200, type: typeof(string), description: "OK")]
        public virtual IActionResult ModuleGetConnectionStatus([FromRoute][Required]string connectionId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(string));

            string exampleJson = null;
            exampleJson = "{\n  \"bytes\": [],\n  \"empty\": true\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<string>(exampleJson)
            : default(string);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Get the device twin
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/module/{connectionId}/twin")]
        [ValidateModelState]
        [SwaggerOperation("ModuleGetTwin")]
        [SwaggerResponse(statusCode: 200, type: typeof(Twin), description: "OK")]
        public virtual IActionResult ModuleGetTwin([FromRoute][Required]string connectionId)
        {
            // Replaced impl in merge
            Task<Models.Twin> t = module_glue.GetTwinAsync(connectionId);
            t.Wait();
            return new ObjectResult(t.Result);
        }

        /// <summary>
        /// call the given method on the given device
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <param name="deviceId"></param>
        /// <param name="methodInvokeParameters"></param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/deviceMethod/{deviceId}")]
        [ValidateModelState]
        [SwaggerOperation("ModuleInvokeDeviceMethod")]
        [SwaggerResponse(statusCode: 200, type: typeof(Object), description: "OK")]
        public virtual IActionResult ModuleInvokeDeviceMethod([FromRoute][Required]string connectionId, [FromRoute][Required]string deviceId, [FromBody]MethodInvoke methodInvokeParameters)
        {
            // Replaced impl in merge
            Task<Object> t = module_glue.InvokeDeviceMethodAsync(connectionId, deviceId, methodInvokeParameters);
            t.Wait();
            return new ObjectResult(t.Result);
        }

        /// <summary>
        /// call the given method on the given module
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <param name="deviceId"></param>
        /// <param name="moduleId"></param>
        /// <param name="methodInvokeParameters"></param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/moduleMethod/{deviceId}/{moduleId}")]
        [ValidateModelState]
        [SwaggerOperation("ModuleInvokeModuleMethod")]
        [SwaggerResponse(statusCode: 200, type: typeof(Object), description: "OK")]
        public virtual IActionResult ModuleInvokeModuleMethod([FromRoute][Required]string connectionId, [FromRoute][Required]string deviceId, [FromRoute][Required]string moduleId, [FromBody]MethodInvoke methodInvokeParameters)
        {
            // Replaced impl in merge
            Task<object> t = module_glue.InvokeModuleMethodAsync(connectionId, deviceId, moduleId, methodInvokeParameters);
            t.Wait();
            return new ObjectResult(t.Result);
        }

        /// <summary>
        /// Updates the device twin
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <param name="twin"></param>
        /// <response code="200">OK</response>
        [HttpPatch]
        [Route("/module/{connectionId}/twin")]
        [ValidateModelState]
        [SwaggerOperation("ModulePatchTwin")]
        public virtual IActionResult ModulePatchTwin([FromRoute][Required]string connectionId, [FromBody]Twin twin)
        {
            // Replaced impl in merge
            module_glue.SendTwinPatchAsync(connectionId, twin).Wait();
            return StatusCode(200);
        }

        /// <summary>
        /// Reconnect the module
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <param name="forceRenewPassword">True to force SAS renewal</param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/reconnect")]
        [ValidateModelState]
        [SwaggerOperation("ModuleReconnect")]
        public virtual IActionResult ModuleReconnect([FromRoute][Required]string connectionId, [FromQuery]bool? forceRenewPassword)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Send an event
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <param name="eventBody"></param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/event")]
        [ValidateModelState]
        [SwaggerOperation("ModuleSendEvent")]
        public virtual IActionResult ModuleSendEvent([FromRoute][Required]string connectionId, [FromBody]EventBody eventBody)
        {
            // Replaced impl in merge
            module_glue.SendEventAsync(connectionId, eventBody).Wait();
            return StatusCode(200);
        }

        /// <summary>
        /// Send an event to a module output
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <param name="outputName"></param>
        /// <param name="eventBody"></param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/outputEvent/{outputName}")]
        [ValidateModelState]
        [SwaggerOperation("ModuleSendOutputEvent")]
        public virtual IActionResult ModuleSendOutputEvent([FromRoute][Required]string connectionId, [FromRoute][Required]string outputName, [FromBody]EventBody eventBody)
        {
            // Replaced impl in merge
            module_glue.SendOutputEventAsync(connectionId, outputName, eventBody).Wait();
            return StatusCode(200);
        }

        /// <summary>
        /// wait for the current connection status to change and return the changed status
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <param name="connectionStatus">Desired connection status</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/module/{connectionId}/connectionStatusChange")]
        [ValidateModelState]
        [SwaggerOperation("ModuleWaitForConnectionStatusChange")]
        [SwaggerResponse(statusCode: 200, type: typeof(string), description: "OK")]
        public virtual IActionResult ModuleWaitForConnectionStatusChange([FromRoute][Required]string connectionId, [FromQuery][Required()]string connectionStatus)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(string));

            string exampleJson = null;
            exampleJson = "{\n  \"bytes\": [],\n  \"empty\": true\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<string>(exampleJson)
            : default(string);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Wait for the next desired property patch
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/module/{connectionId}/twinDesiredPropPatch")]
        [ValidateModelState]
        [SwaggerOperation("ModuleWaitForDesiredPropertiesPatch")]
        [SwaggerResponse(statusCode: 200, type: typeof(Twin), description: "OK")]
        public virtual IActionResult ModuleWaitForDesiredPropertiesPatch([FromRoute][Required]string connectionId)
        {
            // Replaced impl in merge
            Task<Models.Twin> t = module_glue.WaitForDesiredPropertyPatchAsync(connectionId);
            t.Wait();
            return new ObjectResult(t.Result);
        }

        /// <summary>
        /// Wait for a message on a module input
        /// </summary>

        /// <param name="connectionId">Id for the connection</param>
        /// <param name="inputName"></param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/module/{connectionId}/inputMessage/{inputName}")]
        [ValidateModelState]
        [SwaggerOperation("ModuleWaitForInputMessage")]
        [SwaggerResponse(statusCode: 200, type: typeof(EventBody), description: "OK")]
        public virtual IActionResult ModuleWaitForInputMessage([FromRoute][Required]string connectionId, [FromRoute][Required]string inputName)
        {
            // Replaced impl in merge
            Task<Models.EventBody> t = module_glue.WaitForInputMessageAsync(connectionId, inputName);
            t.Wait();
            return new ObjectResult(t.Result);
        }

        /// <summary>
        /// Wait for a method call, verify the request, and return the response.
        /// </summary>
        /// <remarks>This is a workaround to deal with SDKs that only have method call operations that are sync.  This function responds to the method with the payload of this function, and then returns the method parameters.  Real-world implemenatations would never do this, but this is the only same way to write our test code right now (because the method handlers for C, Java, and probably Python all return the method response instead of supporting an async method call)</remarks>
        /// <param name="connectionId">Id for the connection</param>
        /// <param name="methodName">name of the method to handle</param>
        /// <param name="requestAndResponse"></param>
        /// <response code="200">OK</response>
        [HttpPut]
        [Route("/module/{connectionId}/waitForMethodAndReturnResponse/{methodName}")]
        [ValidateModelState]
        [SwaggerOperation("ModuleWaitForMethodAndReturnResponse")]
        public virtual IActionResult ModuleWaitForMethodAndReturnResponse([FromRoute][Required]string connectionId, [FromRoute][Required]string methodName, [FromBody]MethodRequestAndResponse requestAndResponse)
        {
            // Replaced impl in merge
            Task<object> t = module_glue.RoundtripMethodCallAsync(connectionId, methodName, requestAndResponse);
            t.Wait();
            return new ObjectResult(t.Result);
        }
    }
}
