using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class IdentifierGenerator : IIdentifierGenerator
    {
        public string Generate(Identifier identifier)
        {
            var code = "";

            if (!identifier.Accessed)
            {
                code += "$";
            }

            code += identifier.Name;

            return code;
        }
    }
}