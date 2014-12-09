using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IArithmeticOperatorGenerator
    {
        string Generate(ArithmeticOperator @operator);
    }
}
