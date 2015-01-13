namespace Neemo
{
    /// <summary>
    /// Used 
    /// </summary>
    public interface IMappingConfig
    {
        void RegisterConfigs<TMapper>(TMapper mapper);
    }
}