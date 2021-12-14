using ECMA.APP.Models;

namespace ECMA.APP.Mapper
{
    public interface IContractMapper
    {
        TblContract MapToDbRecord(Contract message);
    }
}
