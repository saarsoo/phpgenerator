using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public interface IPropertyGenerator
    {
        string Generate(Property property);
    }
}
