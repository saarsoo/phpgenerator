using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class IfStatementGenerator : IIfStatementGenerator, IDependency<IStatementGenerator>
    {
        private IStatementGenerator statementGenerator;

        public string Generate(IfStatement ifStatement)
        {
            string condition = this.statementGenerator.Generate(ifStatement.Condition);
            string trueBody = this.statementGenerator.Generate(ifStatement.TrueBody);
            if (!(ifStatement.TrueBody is Block))
            {
                trueBody += ";";
            }

            string code = String.Format("if({0}){{{1}}}", condition, trueBody);

            if (ifStatement.FalseBody != null)
            {
                string falseBody = this.statementGenerator.Generate(ifStatement.FalseBody);
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
            this.statementGenerator = dependency;
        }
    }
}
