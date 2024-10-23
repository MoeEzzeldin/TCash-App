using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO.Interfaces
{
    public interface ITransferDao
    {
        //public Transfer CreateNewTransfer(Transfer transfer);
        public Transfer CreateNewTransfer(int accountTo, int accountFrom, decimal amount);
        public Transfer GetTransferById(int transferId);
        public List<TransferHistoryDTO> UserTransferHistory(string me);

    }
}
