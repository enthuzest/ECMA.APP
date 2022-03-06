using ECMA.APP.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ECMA.APP.Repository
{
    public class ECMARepo : IECMARepo
    {
        private readonly EcmaContext _ecmaContext;
        private readonly ILogger<ECMARepo> _log;

        public ECMARepo(EcmaContext ecmaContext, ILogger<ECMARepo> log)
        {
            _ecmaContext = ecmaContext;
            _log = log;
        }
        public async Task PushContractsToDb(TblContract contractData)
        {
            try
            {
                await _ecmaContext.TblContracts.AddAsync(contractData);
                await _ecmaContext.SaveChangesAsync();
                _log.LogInformation("Contract details saved to the database");
            }
            catch (Exception ex)
            {
                _log.LogError($"Contract details failed to save to the database with error: {ex}");
            }

        }
    }
}
