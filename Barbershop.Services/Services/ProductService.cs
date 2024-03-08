﻿using AutoMapper;
using Barbershop.Contracts.Commands;
using Barbershop.Contracts.Models;
using Barbershop.Domain.Models;
using Barbershop.Domain.Repositories;
using Barbershop.Services.Abstractions;

namespace Barbershop.Services;

public class ProductService : IProductService
{
    private readonly IBaseRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IBaseRepository<Product> barberRepo, IMapper mapper)
    {
        _productRepository = barberRepo ?? throw new ArgumentNullException(nameof(barberRepo));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Create(CreateProductCommand command)
    {
        var product = _mapper.Map<Product>(command);

        await _productRepository.Add(product);
    }

    public async Task<ProductDto> GetById(int id)
    {
        var product = await _productRepository.GetById(id);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<IReadOnlyList<ProductDto>> GetAll()
    {
        var products = await _productRepository.GetAll();

        return _mapper.Map<IReadOnlyList<ProductDto>>(products);
    }

    public async Task RemoveById(int id)
    {
        await _productRepository.Remove(id);
    }
}