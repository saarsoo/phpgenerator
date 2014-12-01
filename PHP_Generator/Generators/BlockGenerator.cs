using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class BlockGenerator : IBlockGenerator, IDependency<IStatementGenerator>
    {
        private IStatementGenerator statementGenerator;

        public string Generate(Block block)
        {
            string code = "";

            foreach (IStatement statement in block.Statements)
            {
                code += this.statementGenerator.Generate(statement);
                code += ";";
            }

            return code;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            this.statementGenerator = dependency;
        }
    }
}
