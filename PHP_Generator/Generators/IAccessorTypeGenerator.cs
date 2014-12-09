using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IAccessorTypeGenerator
    {
        string Generate(AccessorType type);
    }
}
