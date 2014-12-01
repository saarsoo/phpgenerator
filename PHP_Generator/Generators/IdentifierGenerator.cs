using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class IdentifierGenerator : IIdentifierGenerator
    {
        public string Generate(Identifier identifier)
        {
            return "$" + identifier.Name;
        }
    }
}
