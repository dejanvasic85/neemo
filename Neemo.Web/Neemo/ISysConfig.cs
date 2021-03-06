﻿using System.Configuration;

namespace Neemo
{
    public interface ISysConfig
    {
        string ImageDatabaseFolderName { get; }
        string CompanyName { get; }
        string NotificationSenderEmail { get; }

        /// <summary>
        /// Comma delimited list of emails where the support emails will go
        /// </summary>
        string[] NotificationSupportEmail { get; }

        string NotificationInvoiceEmail { get; }

        decimal Gst { get; }
        string CompanyAddress { get; }
        string CompanyPhone { get; }
        string Currency { get; }
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

        public string NotificationInvoiceEmail
        {
            get { return ConfigurationManager.AppSettings["NotificationInvoiceEmail"]; }
        }

        public decimal Gst
        {
            get { return decimal.Parse(ConfigurationManager.AppSettings["Gst"]); }
        }

        public string CompanyAddress
        {
            get { return ConfigurationManager.AppSettings["CompanyAddress"]; }
        }

        public string CompanyPhone
        {
            get { return ConfigurationManager.AppSettings["CompanyPhone"]; }
        }

        public string Currency
        {
            get { return ConfigurationManager.AppSettings["Currency"]; }
        }

    }
}