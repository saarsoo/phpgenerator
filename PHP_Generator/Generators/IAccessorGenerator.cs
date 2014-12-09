using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IAccessorGenerator
    {
        string Generate(Accessor accessor);
    }
}
