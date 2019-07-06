using System;
using System.Collections.Generic;
using System.Text;
using MicroServices.Domain.Core.Events;

namespace MicroServices.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
            
        }
    }
}
