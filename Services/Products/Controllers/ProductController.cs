using Application.Products;
using Microsoft.AspNetCore.Mvc;

namespace Products.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductApplication _application;

    public ProductsController(IProductApplication application)
    {
        _application = application;
    }

    [HttpGet(Name = "ObterProdutos")]
    public IActionResult Get()
    {
        var produtos =_application.ObterProdutos();
        return Ok(produtos);
    }
}
