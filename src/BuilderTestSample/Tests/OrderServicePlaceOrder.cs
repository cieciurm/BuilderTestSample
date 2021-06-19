using BuilderTestSample.Exceptions;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests
{
    public class OrderServicePlaceOrder
    {
        private readonly OrderService _orderService = new();
        private readonly OrderBuilder _orderBuilder = new();

        [Fact]
        public void ThrowsExceptionGivenOrderWithExistingId()
        {
            var order = _orderBuilder
                            .WithId(123)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_WhenTotalAmountIsZero_ThenThrowsException()
        {
            var order = _orderBuilder
                .WithTotalAmount(0.0m)
                .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_WhenCustomerIsNull_ThenThrowsException()
        {
            var order = _orderBuilder
                .WithCustomer(null)
                .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }

    }
}
