using System;
using System.Linq;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class MethodGenerator : IMethodGenerator, IDependency<IModifierGenerator>, IDependency<IParameterGenerator>,
        IDependency<IStatementGenerator>
    {
        private IModifierGenerator _modifierGenerator;
        private IParameterGenerator _parameterGenerator;
        private IStatementGenerator _statementGenerator;

        public void InjectDependency(IModifierGenerator dependency)
        {
            _modifierGenerator = dependency;
        }

        public void InjectDependency(IParameterGenerator dependency)
        {
            _parameterGenerator = dependency;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }

        public string Generate(Method method)
        {
            var modifier = _modifierGenerator.Generate(method.Modifier);

            var parameters = String.Join(",", method.Parameters.Select(p => _parameterGenerator.Generate(p)));

            var body = "";

            if (method.Body != null)
            {
                body = _statementGenerator.Generate(method.Body);
                if (!(method.Body is Block))
                {
                    body += ";";
                }
            }

            return String.Format("{0} function {1}({2}){{{3}}}", modifier, method.Name, parameters, body);
        }
    }
}