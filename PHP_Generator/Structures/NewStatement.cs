using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator.Structures
{
    public class NewStatement : IStatement
    {
        public IStatement Statement { get; set; }

        public NewStatement(IStatement statement)
        {
            Statement = statement;
        }
    }
}
