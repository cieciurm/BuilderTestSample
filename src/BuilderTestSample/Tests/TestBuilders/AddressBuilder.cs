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

        public AddressBuilder WithStreet1(string val)
        {
            _address.Street1 = val;
            return this;
        }

        public AddressBuilder WithCity(string val)
        {
            _address.City = val;
            return this;
        }

        public AddressBuilder WithState(string val)
        {
            _address.State = val;
            return this;
        }

        public AddressBuilder WithPostalCode(string val)
        {
            _address.PostalCode = val;
            return this;
        }

        public AddressBuilder WithCountry(string val)
        {
            _address.Country = val;
            return this;
        }

        public Address Build() => _address;
    }
}
