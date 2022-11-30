using Application.Payment;
using Application.Payment.Automapper;
using Application.Payment.Event;
using Domain.Payment;
using Domain.Payment.Command;
using Infra.Payment;
using Infra.Payment.Context;
using MediatR;
using MessageBroker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Steeltoe.Discovery.Client;

namespace Infra.Ioc.Payment;

public static class DependencyInjector
{
    public static IServiceCollection AddPaymentServices(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddMediatR(typeof(PaymentCommandHandler));
        services.AddDiscoveryClient(configuration);

        services.AddSingleton<IMessageBroker, MessageBroker.MessageBroker>(x =>
        {
            var channel = MessageBrokerConfig.ChannelConfig();
            channel.ExchangeDeclare(QueueExchange.CreatePaymentExchange, ExchangeType.Fanout);
            channel.ExchangeDeclare(QueueExchange.RollbackProductExchange, ExchangeType.Fanout);
            channel.QueueDeclare(EventQueue.CreatePaymentQueue,false, false, false, null);
            channel.QueueBind(queue: EventQueue.CreatePaymentQueue, exchange: QueueExchange.CreatePaymentExchange, routingKey: "");
            return new MessageBroker.MessageBroker(channel);
        });
        services.AddSingleton<IPaymentApplication, PaymentApplication>();
        services.AddAutoMapper(typeof(PaymentAutoMapperConfig));
        services.AddScoped(x => new PaymentContext());
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddHostedService<PaymentEventListener>();
        
        return services;
    }
}