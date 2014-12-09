using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
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
