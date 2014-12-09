using PHP_Generator.Generators.Interfaces;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class ConstantGenerator : IConstantGenerator
    {
        public string Generate(Constant constant)
        {
            var value = constant.Value;

            if (value is bool)
            {
                return value.ToString().ToLower();
            }
            if (value == null)
            {
                return "null";
            }
            if (value is string)
            {
                return "\"" + ((string) value).Replace("\"", "\\\"") + "\"";
            }

            return value.ToString();
        }
    }
}
