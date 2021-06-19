using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    /// <summary>
    /// Reference: https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    /// </summary>
    public class OrderBuilder
    {
        private Order _order = new();

        public OrderBuilder()
        {
            _order.Id = 0;
            _order.TotalAmount = 100m;

            var homeAddress = new AddressBuilder()
                .Build();

            _order.Customer = new CustomerBuilder()
                .WithHomeAddress(homeAddress)
                .Build();
        }

        public OrderBuilder WithTotalAmount(decimal totalAmount)
        {
            _order.TotalAmount = totalAmount;
            return this;
        }

        public OrderBuilder WithId(int id)
        {
            _order.Id = id;
            return this;
        }

        public OrderBuilder WithCustomer(Customer customer)
        {
            _order.Customer = customer;
            return this;
        }


        public Order Build()
        {
            return _order;
        }
    }
}
