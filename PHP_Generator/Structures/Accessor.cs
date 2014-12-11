using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator.Structures
{
    public class Accessor : IStatement
    {
        public IStatement From { get; set; }
        public AccessorType Type { get; set; }
        public IStatement To { get; set; }

        public Accessor(IStatement @from, IStatement to)
        {
            From = @from;
            To = to;
        }
    }
}
