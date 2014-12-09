using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IConditionalOperatorGenerator
    {
        string Generate(ConditionalOperator @operator);
    }
}
