using System;
using PHP_Generator.Generators.Interfaces;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class IfStatementGenerator : IIfStatementGenerator, IDependency<IStatementGenerator>
    {
        private IStatementGenerator _statementGenerator;

        public string Generate(IfStatement ifStatement)
        {
            var condition = _statementGenerator.Generate(ifStatement.Condition);
            var trueBody = _statementGenerator.Generate(ifStatement.TrueBody);
            if (!(ifStatement.TrueBody is Block))
            {
                trueBody += ";";
            }

            var code = String.Format("if({0}){{{1}}}", condition, trueBody);

            if (ifStatement.FalseBody != null)
            {
                var falseBody = _statementGenerator.Generate(ifStatement.FalseBody);
                if (!(ifStatement.FalseBody is Block))
                {
                    falseBody += ";";
                }

                code += "else{" + falseBody + "}";
            }

            return code;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }
    }
}
