using Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace Products.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductApplication _application;

    public ProductsController(IProductApplication application)
    {
        _application = application;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var produtos =_application.ObterProdutos();
        return Ok(produtos);
    }
}
