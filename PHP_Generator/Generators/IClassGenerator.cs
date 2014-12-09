using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IClassGenerator
    {
        string Generate(Class @class);
    }
}
