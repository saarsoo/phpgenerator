using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class NewStatementGenerator : INewStatementGenerator, IDependency<IStatementGenerator>
    {
        private IStatementGenerator _statementGenerator;

        public string Generate(NewStatement newStatement)
        {
            return String.Format("new {0}", _statementGenerator.Generate(newStatement.Statement));
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }
    }
}
