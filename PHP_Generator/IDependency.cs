namespace PHP_Generator
{
    public interface IDependency<in T>
    {
        void InjectDependency(T dependency);
    }
}
