using System;
using System.Collections.Generic;
using System.Text;
using MicroServices.Transfer.Domain.Models;

namespace MicroServices.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();
        void Add(TransferLog transferLog);
    }
}
