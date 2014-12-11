using System;
using System.Collections.Generic;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class MethodCallGenerator : IMethodCallGenerator, IDependency<IStatementGenerator>
    {
        private IStatementGenerator _statementGenerator;

        public string Generate(MethodCall methodCall)
        {
            var from = _statementGenerator.Generate(methodCall.From);

            var arguments = new List<string>();

            foreach (var argument in methodCall.Arguments)
            {
                arguments.Add(_statementGenerator.Generate(argument));
            }

            return String.Format("{0}({1})", from, String.Join(",", arguments));
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }
    }
}
