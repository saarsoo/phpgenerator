using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IReturnStatementGenerator
    {
        string Generate(ReturnStatement returnStatement);
    }
}
