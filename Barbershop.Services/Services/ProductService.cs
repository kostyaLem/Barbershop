using AutoMapper;
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

    public ProductService(IBaseRepository<Product> barberRepository, IMapper mapper)
    {
        _productRepository = barberRepository ?? throw new ArgumentNullException(nameof(barberRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task Create(UpsertProductCommand command)
    {
        var product = _mapper.Map<Product>(command);

        await _productRepository.Add(product);
    }

    public async Task<IReadOnlyList<ProductDto>> GetAll()
    {
        var products = await _productRepository.GetAll();

        return _mapper.Map<IReadOnlyList<ProductDto>>(products);
    }

    public async Task Update(UpsertProductCommand command)
    {
        await _productRepository.Update(_mapper.Map<Product>(command));
    }

    public async Task RemoveById(int id)
    {
        await _productRepository.Remove(id);
    }
}