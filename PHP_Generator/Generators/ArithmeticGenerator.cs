using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class ArithmeticGenerator : IArithmeticGenerator, IDependency<IStatementGenerator>, IDependency<IArithmeticOperatorGenerator>
    {
        private IArithmeticOperatorGenerator _arithmeticOperatorGenerator;
        private IStatementGenerator _statementGenerator;

        public string Generate(Arithmetic arithmetic)
        {
            var left = _statementGenerator.Generate(arithmetic.LeftStatement);
            var @operator = _arithmeticOperatorGenerator.Generate(arithmetic.Operator);
            var right = _statementGenerator.Generate(arithmetic.RightStatement);

            return String.Format("{0}{1}{2}", left, @operator, right);
        }

        public void InjectDependency(IArithmeticOperatorGenerator dependency)
        {
            _arithmeticOperatorGenerator = dependency;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }
    }
}