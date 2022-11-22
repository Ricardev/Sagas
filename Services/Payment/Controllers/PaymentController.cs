using Application.Payment;
using Microsoft.AspNetCore.Mvc;

namespace Payment.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentApplication _application;
    public PaymentController(IPaymentApplication application)
    {
        _application = application;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int id)
    {
        return Ok();
    }
}
