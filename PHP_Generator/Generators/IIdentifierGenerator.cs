using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IIdentifierGenerator
    {
        string Generate(Identifier identifier);
    }
}