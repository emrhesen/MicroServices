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

namespace MicroServices.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand,bool>,TransferCommandHandler>();

            // Application Services
            services.AddTransient<IAccountService , AccountService>();

            // Data 
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}
