using System;
using System.Collections.Generic;
using System.Text;
using MicroServices.Banking.Application.Models;
using MicroServices.Banking.Domain.Models;

namespace MicroServices.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
