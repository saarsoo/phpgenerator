using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IModifierGenerator
    {
        string Generate(Modifier modifier);
    }
}