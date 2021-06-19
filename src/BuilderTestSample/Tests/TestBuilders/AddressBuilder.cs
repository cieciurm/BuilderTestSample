using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            };
        }

        public Address Build() => _address;
    }
}
