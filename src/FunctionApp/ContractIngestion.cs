using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using ECMA.APP.Models;
using ECMA.APP.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ECMA.APP
{
    public class ContractIngestion
    {
        private readonly IECMAService _ecmaService;

        public ContractIngestion(IECMAService ecmaService)
        {
            _ecmaService = ecmaService;
        }

        [FunctionName("ContractIngestion")]
        public async Task IngestMessage([ServiceBusTrigger("%EcmaTopicName%", "%EcmaSubscription%", Connection = "servicebusConnection")]
            ServiceBusReceivedMessage message,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {message}");

            var json = Encoding.UTF8.GetString(message.Body);

            try
            {
                Contract contractData = System.Text.Json.JsonSerializer.Deserialize<Contract>(json);
                if(contractData.ContractId != null)
                {
                    log.LogInformation("Sucessfully deserialze the message");

                    await _ecmaService.ProcessMessageAsync(contractData);
                }

                log.LogInformation("Sucessfully deserialze the message, but ContractId is null");

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
