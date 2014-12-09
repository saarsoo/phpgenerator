using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IMethodCallGenerator
    {
        string Generate(MethodCall methodCall);
    }
}
