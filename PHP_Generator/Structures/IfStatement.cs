using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class IfStatement : IStatement
    {
        public readonly IStatement Condition;
        public readonly IStatement TrueBody;
        public readonly IStatement FalseBody;

        public IfStatement(IStatement condition, IStatement trueBody)
        {
            this.Condition = condition;
            this.TrueBody = trueBody;
        }

        public IfStatement(IStatement condition, IStatement trueBody, IStatement falseBody)
        {
            this.Condition = condition;
            this.TrueBody = trueBody;
            this.FalseBody = falseBody;
        }
    }
}
