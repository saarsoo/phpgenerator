using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class ConditionGenerator : IConditionGenerator, IDependency<IStatementGenerator>, IDependency<IConditionalOperatorGenerator>
    {
        private IConditionalOperatorGenerator _conditionalOperatorGenerator;
        private IStatementGenerator _statementGenerator;

        public string Generate(Condition condition)
        {
            var left = _statementGenerator.Generate(condition.LeftCondition);
            var @operator = _conditionalOperatorGenerator.Generate(condition.Operator);
            var right = _statementGenerator.Generate(condition.RightCondition);

            return String.Format("{0}{1}{2}", left, @operator, right);
        }

        public void InjectDependency(IConditionalOperatorGenerator dependency)
        {
            _conditionalOperatorGenerator = dependency;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }
    }
}
