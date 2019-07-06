using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroServices.Domain.Core.Commands;
using MicroServices.Domain.Core.Events;

namespace MicroServices.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TEventHandler>()
            where T : Event
            where TEventHandler : IEventHandler<T>;
    }
}
