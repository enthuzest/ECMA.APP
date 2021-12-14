using ECMA.APP.Mapper;
using ECMA.APP.Models;
using ECMA.APP.Repository;
using System.Threading.Tasks;

namespace ECMA.APP.Services
{
    public class ECMAService : IECMAService
    {
        private readonly IECMARepo _ecmaRepo;
        private readonly IContractMapper _contractMapper;

        public ECMAService(IECMARepo ecmaRepo, IContractMapper contractMapper)
        {
            _ecmaRepo = ecmaRepo;
            _contractMapper = contractMapper;
        }
        public async Task ProcessMessageAsync(Contract message)
        {
            var mappedContractData = _contractMapper.MapToDbRecord(message);
            //_log.LogInformation("Mapping from SB to DB done sucessfully");

            await _ecmaRepo.PushContractsToDb(mappedContractData);
        }
    }
}
