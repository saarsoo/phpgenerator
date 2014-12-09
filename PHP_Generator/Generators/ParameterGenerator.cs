using System;
using PHP_Generator.Generators.Interfaces;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class ParameterGenerator : IParameterGenerator, IDependency<IStatementGenerator>
    {
        private IStatementGenerator _statementGenerator;

        public string Generate(Parameter parameter)
        {
            var code = String.Format("${0}", parameter.Name);

            if (parameter.Statement != null)
            {
                code += "=" + _statementGenerator.Generate(parameter.Statement);
            }

            return code;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }
    }
}
