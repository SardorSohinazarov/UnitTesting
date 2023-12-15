using MediatR;
using Moq;
using ProductAPI.Repositories;
using ProductAPI.Services;

namespace ProductUnitTest
{
    public partial class ProductServiceUnitTest
    {
        private readonly IProductService _productService;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly IMediator mediator;

        public ProductServiceUnitTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepositoryMock.Object);
        }
    }
}
