using ECMA.APP.Models;
using System.Threading.Tasks;

namespace ECMA.APP.Services
{
    public interface IECMAService
    {
        Task ProcessMessageAsync(Contract message);
    }
}
