using PHP_Generator.Structures;

namespace PHP_Generator.Generators.Interfaces
{
    public interface IIfStatementGenerator
    {
        string Generate(IfStatement ifStatement);
    }
}
