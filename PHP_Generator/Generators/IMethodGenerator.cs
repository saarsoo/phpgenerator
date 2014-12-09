using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IMethodGenerator
    {
        string Generate(Method method);
    }
}