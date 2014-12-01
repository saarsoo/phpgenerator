using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class Class : IStatement
    {
        public readonly string Name;
        public readonly string Extends;
        public readonly string[] Implements = new string[] { };

        public Class(string name)
        {
            this.Name = name;
        }

        public Class(string name, string extends)
        {
            this.Name = name;
            this.Extends = extends;
        }

        public Class(string name, string[] implements)
        {
            this.Name = name;
            this.Implements = implements;
        }

        public Class(string name, string extends, string[] implements)
        {
            this.Name = name;
            this.Extends = extends;
            this.Implements = implements;
        }
    }
}