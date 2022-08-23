using Application.Products.Models;
using AutoMapper;
using Domain.Products;

namespace Application.Products.AutoMapper;

public class ProductDomainToViewModel : Profile
{
    public ProductDomainToViewModel()
    {
        CreateMap<Product, ProductModel>();
    }
}