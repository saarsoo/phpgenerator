using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class AssignmentGenerator : IAssignmentGenerator, IDependency<IIdentifierGenerator>,
        IDependency<IStatementGenerator>
    {
        private IIdentifierGenerator _identifierGenerator;
        private IStatementGenerator _statementGenerator;

        public string Generate(Assignment assignment)
        {
            var identifier = _identifierGenerator.Generate(assignment.Identifier);
            var statement = _statementGenerator.Generate(assignment.Statement);

            return String.Format("{0}={1}", identifier, statement);
        }

        public void InjectDependency(IIdentifierGenerator dependency)
        {
            _identifierGenerator = dependency;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }
    }
}