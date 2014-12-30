using System.Configuration;

namespace Neemo
{
    public interface ISysConfig
    {
        string ImageDatabaseFolderName { get; }
    }

    public class SysConfig : ISysConfig
    {
        public string ImageDatabaseFolderName
        {
            get { return ConfigurationManager.AppSettings["ImageDatabaseFolder"]; }
        }
    }
}