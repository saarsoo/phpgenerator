using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class Constant : IStatement
    {
        public readonly object Value;

        public Constant(object value)
        {
            this.Value = value;
        }
    }
}
