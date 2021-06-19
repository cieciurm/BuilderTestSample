using System;
using BuilderTestSample.Model;
using BuilderTestSample.Services;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class CustomerBuilder
    {
        private readonly Random _random = new Random();

        private int _customerId;
        private Address _homeAddress;
        private string _firstName;
        private string _lastName;
        private int _creditRanking;

        public CustomerBuilder()
        {
            _customerId = _random.Next();
            _firstName = Guid.NewGuid().ToString();
            _lastName = Guid.NewGuid().ToString();
            _creditRanking = _random.Next(OrderService.MinCreditRanking + 1, int.MaxValue);
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
            };
        }
    }
}
