using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class ParameterGenerator : IParameterGenerator, IDependency<IStatementGenerator>
    {
        private IStatementGenerator statementGenerator;

        public string Generate(Parameter parameter)
        {
            string code = String.Format("${0}", parameter.Name);

            if (parameter.Statement != null)
            {
                code += "=" + this.statementGenerator.Generate(parameter.Statement);
            }

            return code;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            this.statementGenerator = dependency;
        }
    }
}
