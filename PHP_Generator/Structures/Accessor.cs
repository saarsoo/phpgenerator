using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator.Structures
{
    public class Accessor : IStatement
    {
        public readonly IStatement From;
        public readonly AccessorType Type;
        public readonly IStatement To;

        public Accessor(IStatement @from, AccessorType type, IStatement to)
        {
            From = @from;
            To = to;
            Type = type;
        }
    }
}
