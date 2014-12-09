using PHP_Generator.Structures;

namespace PHP_Generator.Generators.Interfaces
{
    public interface IStatementGenerator
    {
        string Generate(IStatement statement);
    }
}
