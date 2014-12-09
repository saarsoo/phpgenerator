using PHP_Generator.Structures;

namespace PHP_Generator.Generators.Interfaces
{
    public interface IClassGenerator
    {
        string Generate(Class @class);
    }
}
