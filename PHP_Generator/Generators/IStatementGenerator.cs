using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IStatementGenerator
    {
        string Generate(IStatement statement);
    }
}
