namespace PHP_Generator.Structures
{
    public class Class : IStatement
    {
        public readonly string Name;
        public readonly string Extends;
        public readonly string[] Implements = { };
        public readonly Property[] Properties = { };
        public readonly Method[] Methods = { };

        public Class(string name)
        {
            Name = name;
        }

        public Class(string name, Property[] properties)
        {
            Name = name;
            Properties = properties;
        }

        public Class(string name, Method[] methods)
        {
            Name = name;
            Methods = methods;
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