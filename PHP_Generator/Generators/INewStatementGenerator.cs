using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface INewStatementGenerator
    {
        string Generate(NewStatement newStatement);
    }
}
