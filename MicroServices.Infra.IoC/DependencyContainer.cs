using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MicroServices.Banking.Application.Interfaces;
using MicroServices.Banking.Application.Services;
using MicroServices.Banking.Data.Context;
using MicroServices.Banking.Data.Repository;
using MicroServices.Banking.Domain.CommandHandlers;
using MicroServices.Banking.Domain.Commands;
using MicroServices.Banking.Domain.Interfaces;
using MicroServices.Domain.Core.Bus;
using MicroServices.Infra.Bus;
using MicroServices.Transfer.Application.Interfaces;
using MicroServices.Transfer.Application.Services;
using MicroServices.Transfer.Data.Context;
using MicroServices.Transfer.Data.Repository;
using MicroServices.Transfer.Domain.EventHandlers;
using MicroServices.Transfer.Domain.Events;
using MicroServices.Transfer.Domain.Interfaces;

namespace MicroServices.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}
