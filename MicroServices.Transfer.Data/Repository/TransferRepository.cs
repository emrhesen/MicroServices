using System.Collections.Generic;
using MicroServices.Transfer.Data.Context;
using MicroServices.Transfer.Domain.Interfaces;
using MicroServices.Transfer.Domain.Models;

namespace MicroServices.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _context;

        public TransferRepository(TransferDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _context.TransferLogs;
        }

        public void Add(TransferLog transferLog)
        {
            _context.TransferLogs.Add(transferLog);
            _context.SaveChanges();
        }
    }
}
