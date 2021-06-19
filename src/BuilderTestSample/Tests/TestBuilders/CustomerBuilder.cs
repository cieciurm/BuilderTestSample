using System;
using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class CustomerBuilder
    {
        private readonly Random _random = new Random();

        private int _customerId;
        private Address _homeAddress;

        public CustomerBuilder()
        {
            _customerId = _random.Next();
        }

        public CustomerBuilder WithId(int id)
        {
            _customerId = id;
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
            };
        }
    }
}
