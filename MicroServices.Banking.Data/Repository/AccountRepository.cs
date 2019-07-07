using System;
using System.Collections.Generic;
using System.Text;
using MicroServices.Banking.Data.Context;
using MicroServices.Banking.Domain.Interfaces;
using MicroServices.Banking.Domain.Models;

namespace MicroServices.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _context;

        public AccountRepository(BankingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts;
        }
    }
}
