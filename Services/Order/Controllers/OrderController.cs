using Application.Order;
using Application.Order.Models;
using Microsoft.AspNetCore.Mvc;

namespace Order.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderApplication _application;
    public OrderController(IOrderApplication application)
    {
        _application = application;
    }
    
    [HttpPost("MakeOrder")]
    public async Task<IActionResult> MakeOrder([FromBody] MakeOrderModel orderModel)
    {
        await _application.MakeOrder(orderModel);
        return Ok();
    }
}
