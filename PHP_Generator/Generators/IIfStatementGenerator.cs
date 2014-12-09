using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IIfStatementGenerator
    {
        string Generate(IfStatement ifStatement);
    }
}
