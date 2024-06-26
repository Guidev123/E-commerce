﻿using YourSneaker.Core.Tools;
using YourSneaker.MessageBus;
using YourSneaker.Pedido.API.Services;

namespace YourSneaker.Pedido.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<PedidoGerenciadorIntegrationHandler>();
        }
    }
}
