using System;
using System.Collections.Generic;
using System.Text;
using MicroServices.Banking.Application.Interfaces;
using MicroServices.Banking.Application.Models;
using MicroServices.Banking.Domain.Commands;
using MicroServices.Banking.Domain.Interfaces;
using MicroServices.Banking.Domain.Models;
using MicroServices.Domain.Core.Bus;

namespace MicroServices.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _eventBus;

        public AccountService(IAccountRepository accountRepository , IEventBus eventBus)
        {
            _accountRepository = accountRepository;
            _eventBus = eventBus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                    accountTransfer.FromAccount,
                    accountTransfer.ToAccount,
                    accountTransfer.TransferAmount
                );

            _eventBus.SendCommand(createTransferCommand);
        }
    }
}
