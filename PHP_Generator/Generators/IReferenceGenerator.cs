using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IReferenceGenerator
    {
        string Generate(Reference reference);
    }
}