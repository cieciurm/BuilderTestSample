using System;
using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class AddressBuilder
    {
        private readonly Address _address;

        public AddressBuilder()
        {
            _address = new Address
            {
                City = RandomValue.String,
                Country = RandomValue.String,
                PostalCode = RandomValue.String,
                State = RandomValue.String,
                Street1 = RandomValue.String,
                Street2 = RandomValue.String,
                Street3 = RandomValue.String,
            };
        }

        public Address Build() => _address;
    }
}
