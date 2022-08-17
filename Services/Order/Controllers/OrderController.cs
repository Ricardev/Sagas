using Application.Order;
using Application.Order.Models;
using Microsoft.AspNetCore.Mvc;

namespace Order.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderApplication _application;
    public OrderController(IOrderApplication application)
    {
        _application = application;
    }
    
    [Route("MakeOrder")]
    [HttpPost]
    public async Task<IActionResult> MakeOrder([FromBody] MakeOrderModel orderModel)
    {
        await _application.MakeOrder(orderModel);
        return Ok();
    }
}
