using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public interface IIfStatementGenerator
    {
        string Generate(IfStatement ifStatement);
    }
}
