using Xunit;
using ECMA.APP;
using NSubstitute;
using ECMA.APP.Services;
using ECMA.APP.Models;
using Microsoft.Extensions.Logging;
using Azure.Messaging.ServiceBus;
using System;

namespace ECMA.App.Test
{
    public class ContractIngestionTests
    {
        private readonly IECMAService _ecmaServices;
        private readonly ILogger _logger;
        private readonly string json;
        private readonly ServiceBusReceivedMessage _message;
        private BinaryData xx;

        public ContractIngestionTests()
        {
            _ecmaServices = Substitute.For<IECMAService>();
            _logger = Substitute.For<ILogger>();

            json = "{\"ContractId\": \"12458\"}";
            xx = new BinaryData(json);
            _message = ServiceBusModelFactory.ServiceBusReceivedMessage(body: xx);
        }

        [Fact]
        public void ProcessMessageAsync_Success()
        {
            ContractIngestion obj = new ContractIngestion(_ecmaServices);
            var result = obj.IngestMessage(_message, _logger);

            _ecmaServices.Received(1).ProcessMessageAsync(Arg.Any<Contract>());

        }
    }
}