﻿using BuilderTestSample.Model;
using BuilderTestSample.Services;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class CustomerBuilder
    {
        private int _customerId;
        private Address _homeAddress;
        private string _firstName;
        private string _lastName;
        private int _creditRanking;
        private decimal _totalPurchases;

        public CustomerBuilder()
        {
            _customerId = RandomValue.Int32;
            _firstName = RandomValue.String;
            _lastName = RandomValue.String;
            _creditRanking = RandomValue.Int32WithMinValue(OrderService.MinCreditRanking + 1);
            _totalPurchases = RandomValue.Decimal;
            _homeAddress = new AddressBuilder().Build();
        }

        public CustomerBuilder WithId(int id)
        {
            _customerId = id;
            return this;
        }

        public CustomerBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public CustomerBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public CustomerBuilder WithCreditRanking(int creditRanking)
        {
            _creditRanking = creditRanking;
            return this;
        }
        public CustomerBuilder WithTotalPurchases(decimal totalPurchases)
        {
            _totalPurchases = totalPurchases;
            return this;
        }

        public CustomerBuilder WithHomeAddress(Address homeAddress)
        {
            _homeAddress = homeAddress;
            return this;
        }

        public Customer Build()
        {
            return new Customer(_customerId)
            {
                HomeAddress = _homeAddress,
                FirstName = _firstName,
                LastName = _lastName,
                CreditRating = _creditRanking,
                TotalPurchases = _totalPurchases,
            };
        }
    }
}
