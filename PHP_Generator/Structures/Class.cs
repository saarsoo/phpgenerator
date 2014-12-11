using System.Collections.Generic;

namespace PHP_Generator.Structures
{
    public class Class : IStatement
    {
        public string Name { get; set; }

        public string Extends { get; set; }
        public IEnumerable<string> Implements { get; set; }
        public IEnumerable<IMember> Members { get; set; }

        public Class(string name)
        {
            Name = name;
            Implements = new string[] { };
            Members = new IMember[] { };
        }
    }
}