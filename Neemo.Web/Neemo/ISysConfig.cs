using System.Configuration;

namespace Neemo
{
    public interface ISysConfig
    {
        string ImageDatabaseFolderName { get; }
        string CompanyName { get; }
        string NotificationSenderEmail { get; }
        string[] NotificationSupportEmail { get; }
    }

    public class SysConfig : ISysConfig
    {
        public string ImageDatabaseFolderName
        {
            get { return ConfigurationManager.AppSettings["ImageDatabaseFolder"]; }
        }

        public string CompanyName
        {
            get { return ConfigurationManager.AppSettings["CompanyName"]; }
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