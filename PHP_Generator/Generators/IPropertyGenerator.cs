using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IPropertyGenerator
    {
        string Generate(Property property);
    }
}
