using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class AccessorTypeGenerator : IAccessorTypeGenerator
    {
        public string Generate(AccessorType type)
        {
            switch (type)
            {
                case AccessorType.Pointer:
                    return "->";
                case AccessorType.Static:
                    return "::";
            }

            throw new NotImplementedException();
        }
    }
}
