using ECMA.APP.Mapper;
using ECMA.APP.Models;
using ECMA.APP.Repository;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ECMA.APP.Services
{
    public class ECMAService : IECMAService
    {
        private readonly IECMARepo _ecmaRepo;
        private readonly IContractMapper _contractMapper;
        private readonly ILogger<ECMAService> _log;

        public ECMAService(IECMARepo ecmaRepo, IContractMapper contractMapper, ILogger<ECMAService> log)
        {
            _ecmaRepo = ecmaRepo;
            _contractMapper = contractMapper;
            _log = log;
        }
        public async Task ProcessMessageAsync(Contract message)
        {
            var mappedContractData = _contractMapper.MapToDbRecord(message);
            _log.LogInformation("Mapping from SB to DB done sucessfully");

            await _ecmaRepo.PushContractsToDb(mappedContractData);
        }
    }
}
