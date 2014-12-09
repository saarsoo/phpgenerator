using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IAssignmentGenerator
    {
        string Generate(Assignment assignment);
    }
}
