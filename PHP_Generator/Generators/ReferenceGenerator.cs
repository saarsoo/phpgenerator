using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class ReferenceGenerator : IReferenceGenerator
    {
        public string Generate(Reference reference)
        {
            return String.Format("use {0};", reference.Path);
        }
    }
}
