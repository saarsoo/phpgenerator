namespace PHP_Generator.Structures
{
    public class File
    {
        public readonly Class[] Classes = {};
        public readonly string Namespace;
        public readonly Reference[] References = {};

        public File()
        {
        }

        public File(string @namespace)
        {
            Namespace = @namespace;
        }

        public File(Class[] @classes)
        {
            Classes = @classes;
        }

        public File(Reference[] references)
        {
            References = references;
        }

        public File(string @namespace, Class[] @classes)
        {
            Namespace = @namespace;
            Classes = @classes;
        }

        public File(string @namespace, Reference[] references, Class[] @classes)
        {
            Namespace = @namespace;
            References = references;
            Classes = @classes;
        }
    }
}