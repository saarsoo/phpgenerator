using System.Collections.Generic;

namespace PHP_Generator.Structures
{
    public class File
    {
        public string Namespace { get; set; }
        public IEnumerable<Reference> References { get; set; }
        public IEnumerable<Class> Classes { get; set; }

        public File()
        {
            References = new Reference[] { };
            Classes = new Class[] { };
        }
    }
}