using Application.Order;
using Application.Order.AutoMapper;
using Domain.Order;
using Domain.Order.Command;
using Infra.Order;
using Infra.Order.Context;
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
builder.Services.AddDiscoveryClient(builder.Configuration);

builder.Services.AddScoped<IMessageBroker, MessageBroker.MessageBroker>(x =>
{
    var channel = MessageBrokerConfig.ChannelConfig(); 
    channel.ExchangeDeclare(QueueExchange.OrderExchange, ExchangeType.Fanout,true);
    channel.QueueDeclare(EventQueue.ValidateProductQueue,true, false, false, null);
    channel.QueueBind(queue: EventQueue.ValidateProductQueue, exchange:QueueExchange.OrderExchange, routingKey: "");
    return new MessageBroker.MessageBroker(channel);
});

builder.Services.AddScoped<IOrderApplication, OrderApplication>();
builder.Services.AddScoped(x => new OrderContext());
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddAutoMapper(typeof(OrderAutoMapperConfig));
builder.Services.AddMediatR(typeof(OrderCommandHandler));
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
