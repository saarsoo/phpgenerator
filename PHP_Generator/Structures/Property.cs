using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class Property
    {
        public readonly Modifier Modifier = Modifier.Private;
        public readonly string Name;
        public readonly IStatement Statement;

        public Property(string name)
        {
            this.Name = name;
        }

        public Property(string name, IStatement statement)
        {
            this.Name = name;
            this.Statement = statement;
        }

        public Property(string name, Modifier modifier)
        {
            this.Name = name;
            this.Modifier = modifier;
        }

        public Property(string name, Modifier modifier, IStatement statement)
        {
            this.Name = name;
            this.Modifier = modifier;
            this.Statement = statement;
        }
    }
}
