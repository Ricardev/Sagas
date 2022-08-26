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
    channel.ExchangeDeclare("Product Exchange", ExchangeType.Fanout, true);
    channel.QueueDeclare(EventQueue.ValidateProductQueue,true, false, false, null);
    channel.QueueDeclare(EventQueue.RollbackProductQueue, true, false, false, null);
    channel.QueueBind(queue: EventQueue.ValidateProductQueue, exchange: "Product Exchange", routingKey: "");
    return new MessageBroker.MessageBroker(channel);
});

builder.Services.AddAutoMapper(typeof(ProductAutoMapperConfig));
builder.WebHost.UseUrls("http://localhost:9002");
builder.Services.AddHostedService<ProductEventListener>();


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
