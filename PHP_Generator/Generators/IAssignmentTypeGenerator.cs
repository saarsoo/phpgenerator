using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IAssignmentTypeGenerator
    {
        string Generate(AssignmentType assignmentType);
    }
}
