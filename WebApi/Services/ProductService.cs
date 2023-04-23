﻿using WebApi.Models.DTO;
using WebApi.Models.Entities;
using WebApi.Repositories;

namespace WebApi.Services;

public class ProductService
{
    private readonly ProductRepo _productRepo;
    private readonly TagRepo _tagRepo;

    public ProductService(ProductRepo productRepo, TagRepo tagRepo)
    {
        _productRepo = productRepo;
        _tagRepo = tagRepo;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllAsync()
    {
        var products = await _productRepo.GetAllAsync();
        var dto = new List<ProductDTO>();

        foreach (var entity in products)
        {
            ProductDTO product = entity;
            dto.Add(product);
        }

        return dto;
    }

    public async Task<IEnumerable<ProductDTO>> GetByTagAsync(string tag)
    {
        var products = await _productRepo.GetListAsync(x => x.Tag.Name == tag);
        products = products.OrderByDescending(x => x.Id).Take(8);
        var dto = new List<ProductDTO>();

        foreach (var entity in products)
        {
            ProductDTO product = entity;
            dto.Add(product);
        }

        return dto;
    }

    public async Task<ProductDTO> GetByIdAsync(int id)
    {
        var product = await _productRepo.GetAsync(x => x.Id == id);
        ProductDTO dto = product;

        return dto;
    }

    public async Task<bool> CreateAsync(CreateProductDTO dto)
    {
        ProductEntity entity = dto;
        entity.Tag = await _tagRepo.GetAsync(x => x.Name == dto.Tag);

        try
        {
            await _productRepo.AddAsync(entity);
            return true;
        }
        catch
        {
            return false;
        }

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _productRepo.GetAsync(x => x.Id == id);

        try
        {
            await _productRepo.DeleteAsync(entity!);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
