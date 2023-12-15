using MediatR;
using ProductAPI.DTOs;
using ProductAPI.Entities;
using ProductAPI.Exceptions;
using ProductAPI.Repositories;

namespace ProductAPI.Services.useCases
{
    public class ProductCreateCommand:IRequest<Product>
    {
        public Product Product { get; set; }
    }

    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductCreateCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken = default)
        {
            //logic

            if (request.Product == null)
            {
                throw new InputNullException();
            }

            var newproduct = await _repository.InsertAsync(request.Product);

            return newproduct;
        }
    }
}
