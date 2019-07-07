using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroServices.Domain.Core.Bus;
using MicroServices.Transfer.Domain.Events;
using MicroServices.Transfer.Domain.Interfaces;
using MicroServices.Transfer.Domain.Models;

namespace MicroServices.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amount
            });

            return Task.CompletedTask;
        }
    }
}
