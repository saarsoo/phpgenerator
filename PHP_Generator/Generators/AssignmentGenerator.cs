using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class AssignmentGenerator : IAssignmentGenerator, IDependency<IIdentifierGenerator>, IDependency<IStatementGenerator>
    {
        private IIdentifierGenerator identifierGenerator;
        private IStatementGenerator statementGenerator;

        public string Generate(Assignment assignment)
        {
            string identifier = this.identifierGenerator.Generate(assignment.Identifier);
            string statement = this.statementGenerator.Generate(assignment.Statement);

            return String.Format("{0}={1}", identifier, statement);
        }

        public void InjectDependency(IIdentifierGenerator dependency)
        {
            this.identifierGenerator = dependency;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            this.statementGenerator = dependency;
        }
    }
}
