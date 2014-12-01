using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class ModifierGenerator : IModifierGenerator
    {
        public string Generate(Modifier modifier)
        {
            switch(modifier)
            {
                case Modifier.Public:
                    return "public";
                case Modifier.Protected:
                    return "protected";
                case Modifier.Private:
                    return "private";
            }

            throw new NotImplementedException();
        }
    }
}
