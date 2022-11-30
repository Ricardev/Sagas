using Application.Order;
using Application.Order.AutoMapper;
using Domain.Order;
using Domain.Order.Command;
using Infra.Order;
using Infra.Order.Context;
using MediatR;
using MessageBroker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Steeltoe.Discovery.Client;

namespace Infra.Ioc.Order;

public static class DependencyInjector
{
    public static IServiceCollection AddOrderServices(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDiscoveryClient(configuration);

        services.AddScoped<IMessageBroker, MessageBroker.MessageBroker>(x =>
        {
            var channel = MessageBrokerConfig.ChannelConfig();
            channel.ExchangeDeclare(QueueExchange.CreateProductExchange, ExchangeType.Fanout);
            return new MessageBroker.MessageBroker(channel);
        });

        services.AddScoped<IOrderApplication, OrderApplication>();
        services.AddScoped(x => new OrderContext());
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddAutoMapper(typeof(OrderAutoMapperConfig));
        services.AddMediatR(typeof(OrderCommandHandler));
        return services;
    }
}