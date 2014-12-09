using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IBlockGenerator
    {
        string Generate(Block block);
    }
}