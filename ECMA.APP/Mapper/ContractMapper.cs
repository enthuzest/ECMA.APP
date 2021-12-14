using ECMA.APP.Models;

namespace ECMA.APP.Mapper
{
    public class ContractMapper : IContractMapper
    {
        public TblContract MapToDbRecord(Contract message)
        {

            var contract = new TblContract();
            contract.ContractId = message.ContractId;
            contract.CreatedDate = message.CreatedDate;
            contract.EndDate = message.EndDate;
            contract.UpdateDatetime = message.UpdateDatetime;
            contract.Price = message.Price;
            contract.Owner = message.Owner;

            return contract;

        }
    }
}
