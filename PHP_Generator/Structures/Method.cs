using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class Method
    {
        public readonly string Name;
        public readonly Modifier Modifier = Modifier.Private;
        public readonly Parameter[] Parameters = new Parameter[] { };
        public readonly IStatement Body;

        public Method(string name)
        {
            this.Name = name;
        }

        public Method(string name, IStatement body)
        {
            this.Name = name;
            this.Body = body;
        }

        public Method(string name, Parameter[] parameters)
        {
            this.Name = name;
            this.Parameters = parameters;
        }
    }
}
