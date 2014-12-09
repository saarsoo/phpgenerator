using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IParameterGenerator
    {
        string Generate(Parameter parameter);
    }
}
