using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroServices.Domain.Core.Events;

namespace MicroServices.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
    where TEvent : Event
    {
        Task Handle(TEvent @event);

    }

    public interface IEventHandler 
    {

    }
}
