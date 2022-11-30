using Application.Products;
using Application.Products.AutoMapper;
using Application.Products.Event;
using Domain.Products;
using Domain.Products.Command;
using Infra.Products;
using Infra.Products.Context;
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
builder.Services.AddSingleton( x=> new ProductContext());
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(typeof(ProductCommandHandler));
builder.Services.AddSingleton<IProductApplication, ProductApplication>();
builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddSingleton<IMessageBroker, MessageBroker.MessageBroker>(x =>
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

builder.Services.AddAutoMapper(typeof(ProductAutoMapperConfig));
builder.Services.AddHostedService<ProductEventListener>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
