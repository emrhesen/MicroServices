using System.Collections.Generic;
using MicroServices.Transfer.Domain.Models;

namespace MicroServices.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
