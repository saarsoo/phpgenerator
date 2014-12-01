using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class MethodGenerator : IMethodGenerator
    {
        public string Generate(Method method)
        {
            return String.Format("function {0}(){{}}", method.Name);
        }
    }
}
