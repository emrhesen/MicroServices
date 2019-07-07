using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MicroServices.Banking.Domain.Models;

namespace MicroServices.Banking.Data.Context
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
