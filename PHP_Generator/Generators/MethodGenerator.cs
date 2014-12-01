using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class MethodGenerator : IMethodGenerator, IDependency<IModifierGenerator>, IDependency<IParameterGenerator>, IDependency<IStatementGenerator>
    {
        private IModifierGenerator modifierGenerator;
        private IParameterGenerator parameterGenerator;
        private IStatementGenerator statementGenerator;

        public string Generate(Method method)
        {
            string modifier = this.modifierGenerator.Generate(method.Modifier);

            string parameters = String.Join(",", method.Parameters.Select(p => this.parameterGenerator.Generate(p)));

            string body = "";

            if (method.Body != null)
            {
                body = this.statementGenerator.Generate(method.Body);
                if (!(method.Body is Block))
                {
                    body += ";";
                }
            }

            return String.Format("{0} function {1}({2}){{{3}}}", modifier, method.Name, parameters, body);
        }

        public void InjectDependency(IModifierGenerator dependency)
        {
            this.modifierGenerator = dependency;
        }

        public void InjectDependency(IParameterGenerator dependency)
        {
            this.parameterGenerator = dependency;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            this.statementGenerator = dependency;
        }
    }
}
