using Application.Products;
using Application.Products.AutoMapper;
using Application.Products.Event;
using Domain.Products.Command;
using MediatR;
using MessageBroker;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(ProductCommandHandler));
builder.Services.AddScoped<IProductApplication, ProductApplication>();
builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddScoped<IMessageBroker, MessageBroker.MessageBroker>(x =>
{
    var channel = MessageBrokerConfig.ChannelConfig();
    return new MessageBroker.MessageBroker(channel);
});
builder.Services.AddAutoMapper(typeof(ProductAutoMapperConfig));
builder.Services.AddHostedService<ProductEventListener>();
builder.WebHost.UseUrls("http://localhost:9002");

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
