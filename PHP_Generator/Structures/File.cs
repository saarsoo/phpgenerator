using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class File
    {
        public readonly string Namespace;
        public readonly Reference[] References = new Reference[] { };
        public readonly Class[] Classes = new Class[] { };

        public File()
        {
        }

        public File(string @namespace)
        {
            this.Namespace = @namespace;
        }

        public File(Class[] @classes)
        {
            this.Classes = @classes;
        }

        public File(Reference[] references)
        {
            this.References = references;
        }

        public File(string @namespace, Class[] @classes)
        {
            this.Namespace = @namespace;
            this.Classes = @classes;
        }

        public File(string @namespace, Reference[] references, Class[] @classes)
        {
            this.Namespace = @namespace;
            this.References = references;
            this.Classes = @classes;
        }
    }
}