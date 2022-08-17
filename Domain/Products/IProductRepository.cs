﻿namespace Domain.Products;

public interface IProductRepository
{

    public Product GetProduct(int id);
    public void CreateProduct(Product product);

    public void OrderProduct(Product product);
}