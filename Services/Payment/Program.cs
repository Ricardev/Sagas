using Application.Payment;
using Application.Payment.Automapper;
using Application.Payment.Event;
using Domain.Payment;
using Domain.Payment.Command;
using Infra.Payment;
using Infra.Payment.Context;
using MediatR;
using MessageBroker;
using RabbitMQ.Client;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(PaymentCommandHandler));
builder.Services.AddDiscoveryClient(builder.Configuration);

builder.Services.AddSingleton<IMessageBroker, MessageBroker.MessageBroker>(x =>
{
    var channel = MessageBrokerConfig.ChannelConfig();
    channel.ExchangeDeclare("Payment Exchange", ExchangeType.Fanout, true);
    channel.QueueDeclare(EventQueue.CreatePaymentQueue,true, false, false, null);
    channel.QueueDeclare(EventQueue.RollbackPaymentQueue, true, false, false, null);
    return new MessageBroker.MessageBroker(channel);
});
builder.Services.AddSingleton<IPaymentApplication, PaymentApplication>();
builder.Services.AddAutoMapper(typeof(PaymentAutoMapperConfig));
builder.Services.AddScoped(x => new PaymentContext());
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddHostedService<PaymentEventListener>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
