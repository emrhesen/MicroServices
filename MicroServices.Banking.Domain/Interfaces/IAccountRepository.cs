using System;
using System.Collections.Generic;
using System.Text;
using MicroServices.Banking.Domain.Models;

namespace MicroServices.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();

    }
}
