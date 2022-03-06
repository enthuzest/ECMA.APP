using Xunit;
using ECMA.APP;
using NSubstitute;
using ECMA.APP.Services;
using ECMA.APP.Models;
using Microsoft.Extensions.Logging;
using Azure.Messaging.ServiceBus;
using System;
using ECMA.APP.Repository;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ECMA.App.Test
{
    public class ContractIngestionTests
    {
        private readonly IECMAService _ecmaServices;
        private readonly ILogger _logger;
        private readonly IECMARepo _repo;
        private readonly string json;
        private readonly string wrongJson;
        private readonly ServiceBusReceivedMessage _message;
        private readonly BinaryData xx;
        private readonly BinaryData yy;
        private readonly ServiceBusReceivedMessage _wrongMessage;

        public ContractIngestionTests()
        {
            _ecmaServices = Substitute.For<IECMAService>();
            _logger = Substitute.For<ILogger>();
            _repo = Substitute.For<IECMARepo>();

            json = "{\"ContractId\": \"12458\"}";         
            xx = new BinaryData(json);
            _message = ServiceBusModelFactory.ServiceBusReceivedMessage(body: xx);

            wrongJson = "{\"ContractId\": 12459}";
            yy = new BinaryData(wrongJson);
            _wrongMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(body: yy);
        }

        [Fact]
        public async Task ProcessMessageAsync_Success()
        {
            //Arrange
            ContractIngestion obj = new(_ecmaServices);

            //Act
            await obj.IngestMessage(_message, _logger);

            //Assert
            await _ecmaServices.Received(1).ProcessMessageAsync(Arg.Any<Contract>());
            //_repo.Received(1).PushContractsToDb(Arg.Any<TblContract>());

        }

        [Fact]
        public async Task getErrorAsync()
        {
            ContractIngestion obj = new(_ecmaServices);

            await Assert.ThrowsAsync<System.Text.Json.JsonException>(() => obj.IngestMessage(_wrongMessage, _logger));

        }
    }
}