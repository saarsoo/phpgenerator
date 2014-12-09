using PHP_Generator.Structures;

namespace PHP_Generator.Generators.Interfaces
{
    public interface IMethodGenerator
    {
        string Generate(Method method);
    }
}
