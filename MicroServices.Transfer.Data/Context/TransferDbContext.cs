using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MicroServices.Transfer.Domain.Models;

namespace MicroServices.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}
