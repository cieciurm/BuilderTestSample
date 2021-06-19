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
        private readonly CustomerBuilder _customerBuilder = new();

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

        [Fact]
        public void PlaceOrder_WhenCustomerIdIsZero_ThenThrowsException()
        {
            var customer = _customerBuilder
                .WithId(0)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_WhenCustomerAddressIsNull_ThenThrowsException()
        {
            var customer = _customerBuilder
                .WithId(0)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("John", "")]
        [InlineData("", "Doe")]
        public void PlaceOrder_WhenCustomerFirstOrLastNameIsNull_ThenThrowsException(string firstName, string lastName)
        {
            var customer = _customerBuilder
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        [InlineData(200)]
        public void PlaceOrder_WhenCustomerHasCreditRankingLowerOrEqualToMin_ThenThrowsException(int creditRanking)
        {
            var customer = _customerBuilder
                .WithCreditRanking(creditRanking)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            Assert.Throws<InsufficientCreditException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-1)]
        public void PlaceOrder_ThenCustomerHasLessOrEqualToZeroTotalPurchases_ThenThrowsException(decimal totalPurchases)
        {
            var customer = _customerBuilder
                .WithTotalPurchases(totalPurchases)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Theory]
        [InlineData(100, 300, false)]
        [InlineData(5000, 500, false)]
        [InlineData(5001, 501, true)]
        public void PlaceOrder_WhenCustomerHasCertainTotalPurchasesAndCreditRanking_ThenIsExpeditedIsSetAccordingly(
            decimal totalPurchases, int creditRanking, bool expectedIsExpedited)
        {
            // Arrange
            var customer = _customerBuilder
                .WithTotalPurchases(totalPurchases)
                .WithCreditRanking(creditRanking)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            // Act
            var placedOrder = _orderService.PlaceOrder(order);

            // Assert
            Assert.Equal(expectedIsExpedited, placedOrder.IsExpedited);
        }

        [Fact]
        public void PlaceOrder_WhenOrderPlaced_ThenItIsAddedToCustomersOrderHistory()
        {
            // Arrange
            var order = _orderBuilder
                .Build();

            // Act
            var placedOrder = _orderService.PlaceOrder(order);

            // Assert
            Assert.Contains(placedOrder.Customer.OrderHistory, x => x.Id == placedOrder.Id);
        }

        [Theory]
        [InlineData(1000, 100, 1100)]
        [InlineData(0, 100, 100)]
        public void PlaceOrder_WhenOrderPlaced_ThenItIncreasesTotalPurchases(decimal totalPurchases, decimal totalAmount, decimal expectedTotalPurchases)
        {
            // Arrange
            var customer = _customerBuilder
                .WithTotalPurchases(totalPurchases)
                .Build();

            var order = _orderBuilder
                .WithCustomer(customer)
                .WithTotalAmount(totalAmount)
                .Build();

            // Act
            _orderService.PlaceOrder(order);

            // Assert
            Assert.Equal(expectedTotalPurchases, customer.TotalPurchases);
        }

        [Fact]
        public void PlaceOrder_WhenAddressStreet1IsNullOrEmpty_ThenThrowsException()
        {
            var address = new AddressBuilder()
                .WithStreet1(string.Empty)
                .Build();

            var customer = new CustomerBuilder()
                .WithHomeAddress(address)
                .Build();

            var order = new OrderBuilder().WithCustomer(customer).Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_WhenAddressCityIsNullOrEmpty_ThenThrowsException()
        {
            var address = new AddressBuilder()
                .WithCity(string.Empty)
                .Build();

            var customer = new CustomerBuilder()
                .WithHomeAddress(address)
                .Build();

            var order = new OrderBuilder().WithCustomer(customer).Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_WhenAddressCountryIsNullOrEmpty_ThenThrowsException()
        {
            var address = new AddressBuilder()
                .WithCountry(string.Empty)
                .Build();

            var customer = new CustomerBuilder()
                .WithHomeAddress(address)
                .Build();

            var order = new OrderBuilder().WithCustomer(customer).Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_WhenAddressStateIsNullOrEmpty_ThenThrowsException()
        {
            var address = new AddressBuilder()
                .WithState(string.Empty)
                .Build();

            var customer = new CustomerBuilder()
                .WithHomeAddress(address)
                .Build();

            var order = new OrderBuilder().WithCustomer(customer).Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void PlaceOrder_WhenAddressPostalCodeIsNullOrEmpty_ThenThrowsException()
        {
            var address = new AddressBuilder()
                .WithPostalCode(string.Empty)
                .Build();

            var customer = new CustomerBuilder()
                .WithHomeAddress(address)
                .Build();

            var order = new OrderBuilder().WithCustomer(customer).Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }
    }
}
