﻿using System;
using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using Xunit.Sdk;

namespace BuilderTestSample.Services
{
    public class OrderService
    {
        public const int MinCreditRanking = 200;

        public void PlaceOrder(Order order)
        {
            ValidateOrder(order);

            ExpediteOrder(order);

            AddOrderToCustomerHistory(order);
        }

        private void ValidateOrder(Order order)
        {
            // throw InvalidOrderException unless otherwise noted.

            if (order.Id != 0) throw new InvalidOrderException("Order ID must be 0.");

            if (order.TotalAmount == 0)
            {
                throw new InvalidOrderException("TotalAmount has to be greater than 0");
            }

            if (order.Customer == null)
            {
                throw new InvalidOrderException("Customer cannot be empty");
            }

            ValidateCustomer(order.Customer);
        }

        private void ValidateCustomer(Customer customer)
        {
            // throw InvalidCustomerException unless otherwise noted
            // create a CustomerBuilder to implement the tests for these scenarios

            if (customer.Id <= 0)
            {
                throw new InvalidCustomerException("Customer ID has to be greater than 0");
            }

            if (customer.HomeAddress == null)
            {
                throw new InvalidCustomerException("HomeAddress cannot be empty");
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
            // TODO: if customer's total purchases > 5000 and credit rating > 500 set IsExpedited to true
        }

        private void AddOrderToCustomerHistory(Order order)
        {
            // TODO: add the order to the customer

            // TODO: update the customer's total purchases property
        }
    }
}
