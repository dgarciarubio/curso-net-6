using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Domain.Exceptions
{
    public class CustomerConfigurationException : Exception
    {
        public CustomerConfigurationException(string property, object value)
            : base($"Value {value} in property {property} is wrong")
        { }
    }
}
