using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class ReferenceGenerator : IReferenceGenerator
    {
        public string Generate(Reference reference)
        {
            return String.Format("use {0};", reference.Path);
        }
    }
}
