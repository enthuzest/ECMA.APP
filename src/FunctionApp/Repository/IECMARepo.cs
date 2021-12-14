using ECMA.APP.Models;
using System.Threading.Tasks;

namespace ECMA.APP.Repository
{
    public interface IECMARepo
    {
        Task PushContractsToDb(TblContract contract);
    }
}
