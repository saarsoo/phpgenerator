namespace PHP_Generator.Structures
{
    public class File
    {
        public string Namespace { get; set; }
        public Reference[] References { get; set; }
        public Class[] Classes { get; set; }

        public File()
        {
            References = new Reference[] { };
            Classes = new Class[] { };
        }
    }
}