using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class ConstantGenerator : IConstantGenerator
    {
        public string Generate(Constant constant)
        {
            object value = constant.Value;

            if (value is bool)
            {
                return value.ToString().ToLower();
            }
            else if (value == null)
            {
                return "null";
            }
            else if (value is string)
            {
                return "\"" + (value as string).Replace("\"", "\\\"") + "\"";
            }

            return value.ToString();
        }
    }
}
