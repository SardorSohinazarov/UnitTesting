using Moq;
using ProductAPI.Entities;

namespace ProductUnitTest
{
    public partial class ProductServiceUnitTest
    {
        [Fact]
        public async Task ShouldAddProduct()
        {
            var inputProduct = new Product()
            {
                Id = 1,
                Name = "TestProduct",
            };
            
            var resultProduct = new Product()
            {
                Id = 1,
                Name = "TestProduct",
            };

            _productRepositoryMock.Setup(x => x.InsertAsync(inputProduct))
                .ReturnsAsync(resultProduct);

            var outputProduct = await _productService.AddAsync(inputProduct);

            Assert.Equal(resultProduct.Name, outputProduct.Name);
            Assert.Equal(resultProduct.Id, outputProduct.Id);

            _productRepositoryMock.Verify(x => x.InsertAsync(inputProduct),
                Times.Once());

            _productRepositoryMock.VerifyNoOtherCalls();
        }
    }
}
