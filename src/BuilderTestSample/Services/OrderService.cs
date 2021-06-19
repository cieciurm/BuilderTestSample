using System.Data;
using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;

namespace BuilderTestSample.Services
{
    public class OrderService
    {
        public const int MinCreditRanking = 200;
        private const int MinTotalPurchasesToBeExpedited = 5000;
        private const int MinCreditRankingToBeExpedited = 500;

        public Order PlaceOrder(Order order)
        {
            ValidateOrder(order);

            ExpediteOrder(order);

            AddOrderToCustomerHistory(order);

            return order;
        }

        private void ValidateOrder(Order order)
        {
            // throw InvalidOrderException unless otherwise noted.

            if (order.Id != 0)
            {
                throw new InvalidOrderException("Order ID must be 0.");
            }

            if (order.TotalAmount == 0)
            {
                throw new InvalidOrderException("Order amount must be greater than zero");
            }

            if (order.Customer == null)
            {
                throw new InvalidOrderException("Order must have a customer");
            }

            ValidateCustomer(order.Customer);
        }

        private void ValidateCustomer(Customer customer)
        {
            // throw InvalidCustomerException unless otherwise noted

            if (customer.Id <= 0)
            {
                throw new InvalidCustomerException("Customer must have an ID > 0");
            }

            if (customer.HomeAddress == null)
            {
                throw new InvalidCustomerException("Customer must have an address");
            }

            if (string.IsNullOrWhiteSpace(customer.FirstName) || string.IsNullOrWhiteSpace(customer.LastName))
            {
                throw new InvalidCustomerException("Customer must have a first and last name");
            }

            if (customer.CreditRating <= MinCreditRanking)
            {
                throw new InsufficientCreditException("Customer must have credit rating > 200");
            }

            if (customer.TotalPurchases < 0)
            {
                throw new InvalidCustomerException("Customer must have total purchases >= 0");
            }

            ValidateAddress(customer.HomeAddress);
        }

        private void ValidateAddress(Address homeAddress)
        {
            // throw InvalidAddressException unless otherwise noted
            // create an AddressBuilder to implement the tests for these scenarios

            // TODO: street1 is required (not null or empty)
            // TODO: city is required (not null or empty)
            // TODO: state is required (not null or empty)
            // TODO: postalcode is required (not null or empty)
            // TODO: country is required (not null or empty)
        }

        private void ExpediteOrder(Order order)
        {
            var customer = order.Customer;

            if (customer.TotalPurchases > MinTotalPurchasesToBeExpedited && customer.CreditRating > MinCreditRankingToBeExpedited)
            {
                order.IsExpedited = true;
            }
        }

        private void AddOrderToCustomerHistory(Order order)
        {
            order.Customer.OrderHistory.Add(order);

            // TODO: update the customer's total purchases property
        }
    }
}
