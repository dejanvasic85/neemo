using System.Configuration;

namespace Neemo
{
    public interface ISysConfig
    {
        string ImageDatabaseFolderName { get; }
        string NotificationSenderEmail { get; }
        string[] NotificationSupportEmail { get; }
    }

    public class SysConfig : ISysConfig
    {
        public string ImageDatabaseFolderName
        {
            get { return ConfigurationManager.AppSettings["ImageDatabaseFolder"]; }
        }

        public string NotificationSenderEmail
        {
            get { return ConfigurationManager.AppSettings["NotificationSenderEmail"]; }
        }

        public string[] NotificationSupportEmail
        {
            get { return ConfigurationManager.AppSettings["NotificationSupportEmail"].Split(','); }
        }
    }
}