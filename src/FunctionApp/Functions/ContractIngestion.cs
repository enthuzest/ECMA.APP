using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using ECMA.APP.Exceptions;
using ECMA.APP.Models;
using ECMA.APP.Services;
using ECMA.APP.Validations.SchemaValidation;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ECMA.APP.Functions
{
    public class ContractIngestion
    {
        private readonly IECMAService _ecmaService;
        private readonly ISchemaValidation _schemaValidation;

        public ContractIngestion(IECMAService ecmaService, ISchemaValidation schemaValidation)
        {
            _ecmaService = ecmaService;
            _schemaValidation = schemaValidation;
        }

        [FunctionName("ContractIngestion")]
        public async Task IngestMessage([ServiceBusTrigger(
            "%EcmaTopicName%",
            "%EcmaSubscription%",
            Connection = "servicebusConnection")]
            ServiceBusReceivedMessage message,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {message}");

            var json = Encoding.UTF8.GetString(message.Body);

            try
            {
                //validate
                log.LogInformation("Schema Validation Started");
                _schemaValidation.ValidateAndThrow(json);
                log.LogInformation("Schema Validation Completed");

                //deserialize
                log.LogInformation("Deserialization Started");
                Contract contractData = JsonConvert.DeserializeObject<Contract>(json);
                log.LogInformation("Deserialization Completed");

                if (contractData.ContractId != null)
                {
                    log.LogInformation("Successfully deserialze the message");

                    await _ecmaService.ProcessMessageAsync(contractData);
                    return;
                }

                log.LogInformation("Successfully deserialze the message, but ContractId is null");

            }
            catch(JsonSchemaException ex)
            {
                log.LogError(ex, "Schema Exception");
                throw;
            }
            catch (JsonSerializationException ex)
            {
                log.LogError(ex, "Failed to deserialize the message");
                throw;
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Failed to process the message");
                throw;
            }
        }
    }
}
