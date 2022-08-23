using Application.Products.Models;
using AutoMapper;
using Domain.Products.Command;

namespace Application.Products.AutoMapper;

public class ProductViewModelToDomain : Profile
{
    public ProductViewModelToDomain()
    {
        CreateMap<ProductModel, CreateProductCommand>();
    }
}