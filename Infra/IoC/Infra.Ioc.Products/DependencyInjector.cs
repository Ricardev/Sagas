using Application.Products;
using Application.Products.AutoMapper;
using Application.Products.Event;
using Domain.Products;
using Domain.Products.Command;
using Infra.Products;
using Infra.Products.Context;
using MediatR;
using MessageBroker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Steeltoe.Discovery.Client;

namespace Infra.Ioc.Products;

public static class DependencyInjector
{
    public static IServiceCollection AddProductsServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddSingleton( x=> new ProductContext());
        services.AddSingleton<IProductRepository, ProductRepository>();
        services.AddSingleton<IProductApplication, ProductApplication>();
        services.AddMediatR(typeof(ProductCommandHandler));
        services.AddDiscoveryClient(configuration);
        services.AddSingleton<IMessageBroker, MessageBroker.MessageBroker>(x =>
        {
            var channel = MessageBrokerConfig.ChannelConfig();
            channel.ExchangeDeclare(QueueExchange.CreateProductExchange, ExchangeType.Fanout);
            channel.ExchangeDeclare(QueueExchange.RollbackProductExchange, ExchangeType.Fanout);
            channel.ExchangeDeclare(QueueExchange.CreatePaymentExchange, ExchangeType.Fanout);
            channel.QueueDeclare(EventQueue.ValidateProductQueue,false, false, false, null);
            channel.QueueDeclare(EventQueue.RollbackProductQueue, false, false, false, null);
            channel.QueueBind(queue: EventQueue.ValidateProductQueue, exchange: QueueExchange.CreateProductExchange, routingKey: "");
            channel.QueueBind(queue: EventQueue.RollbackProductQueue, exchange: QueueExchange.RollbackProductExchange, routingKey: "");

            return new MessageBroker.MessageBroker(channel);
        });

        services.AddAutoMapper(typeof(ProductAutoMapperConfig));
        services.AddHostedService<ProductEventListener>();
        return services;
    }
}