namespace Neemo
{
    /// <summary>
    /// Used 
    /// </summary>
    public interface IMappingConfig
    {
        void RegisterMapping<TMapper>(TMapper mapper);
    }
}