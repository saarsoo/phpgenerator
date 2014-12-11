using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class AssignmentTypeGenerator : IAssignmentTypeGenerator
    {
        public string Generate(AssignmentType assignmentType)
        {
            switch (assignmentType)
            {
                case AssignmentType.Set:
                    return "=";
                case AssignmentType.Addition:
                    return "+=";
                case AssignmentType.Subtraction:
                    return "-=";
                case AssignmentType.AppendString:
                    return ".=";
            }

            throw new NotImplementedException();
        }
    }
}
