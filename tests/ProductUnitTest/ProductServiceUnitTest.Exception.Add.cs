using Moq;
using ProductAPI.Entities;
using ProductAPI.Exceptions;

namespace ProductUnitTest
{
    public partial class ProductServiceUnitTest
    {
        [Fact]
        public async Task ShouldThrowDoclicateKeyExceptionOnAdd()
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

            var ex = new DublicateKeyException();

            _productRepositoryMock.Setup(x => x.InsertAsync(inputProduct))
                .ThrowsAsync(ex);

            var addTask = _productService.AddAsync(inputProduct);

            var actualEx = await Assert.ThrowsAsync<DublicateKeyException>(addTask.AsTask);

            Assert.Equal(ex.Message, actualEx.Message);

            _productRepositoryMock.Verify(x => x.InsertAsync(inputProduct),
                Times.Once);

            _productRepositoryMock.VerifyNoOtherCalls();
        }
    }
}
