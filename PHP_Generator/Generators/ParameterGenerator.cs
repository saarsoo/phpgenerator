using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class ParameterGenerator : IParameterGenerator, IDependency<IStatementGenerator>
    {
        private IStatementGenerator _statementGenerator;

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }

        public string Generate(Parameter parameter)
        {
            var code = "";

            if (parameter.Type != null)
            {
                code += parameter.Type + " ";
            }

            code += String.Format("${0}", parameter.Name);


            if (parameter.DefaultValue != null)
            {
                code += "=" + _statementGenerator.Generate(parameter.DefaultValue);
            }

            return code;
        }
    }
}