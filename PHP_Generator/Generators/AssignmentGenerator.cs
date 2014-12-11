using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class AssignmentGenerator : IAssignmentGenerator, IDependency<IStatementGenerator>, IDependency<IAssignmentTypeGenerator>
    {
        private IStatementGenerator _statementGenerator;
        private IAssignmentTypeGenerator _assignmentTypeGenerator;

        public string Generate(Assignment assignment)
        {
            var from = _statementGenerator.Generate(assignment.From);
            var to = _statementGenerator.Generate(assignment.To);
            var type = _assignmentTypeGenerator.Generate(assignment.Type);

            return String.Format("{0}{1}{2}", from, type, to);
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }

        public void InjectDependency(IAssignmentTypeGenerator dependency)
        {
            _assignmentTypeGenerator = dependency;
        }
    }
}