using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class ClassGenerator : IClassGenerator
    {
        public string Generate(Class @class)
        {
            string code = String.Format("class {0}", @class.Name);

            if (@class.Extends != null)
            {
                code += String.Format(" extends {0}", @class.Extends);
            }

            if (@class.Implements.Length > 0)
            {
                code += String.Format(" implements {0}", String.Join(",", @class.Implements));
            }

            code += "{}";

            return code;
        }
    }
}