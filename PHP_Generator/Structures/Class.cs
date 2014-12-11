namespace PHP_Generator.Structures
{
    public class Class : IStatement
    {
        public readonly string Extends;
        public readonly string[] Implements = {};
        public readonly IMember[] Members = {};
        public readonly string Name;

        public Class(string name)
        {
            Name = name;
        }

        public Class(string name, IMember[] members)
        {
            Name = name;
            Members = members;
        }

        public Class(string name, string extends, IMember[] members)
        {
            Name = name;
            Extends = extends;
            Members = members;
        }

        public Class(string name, string extends)
        {
            Name = name;
            Extends = extends;
        }

        public Class(string name, string[] implements)
        {
            Name = name;
            Implements = implements;
        }

        public Class(string name, string extends, string[] implements)
        {
            Name = name;
            Extends = extends;
            Implements = implements;
        }
    }
}