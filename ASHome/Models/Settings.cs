using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHome.Models
{
    /// <summary>
    /// Settings model class for application settings
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Setting ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Setting key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Setting value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Setting description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Remember username setting
        /// </summary>
        public bool RememberUsername { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Updated date
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Static class for application settings with default values
    /// </summary>
    public static class ApplicationSettings
    {
        /// <summary>
        /// Remember username setting
        /// </summary>
        public static bool RememberUsername { get; set; } = false;

        /// <summary>
        /// Company name setting
        /// </summary>
        public static string CompanyName { get; set; } = "AS Home";

        /// <summary>
        /// Company address setting
        /// </summary>
        public static string CompanyAddress { get; set; } = "";

        /// <summary>
        /// Company phone setting
        /// </summary>
        public static string CompanyPhone { get; set; } = "";

        /// <summary>
        /// Company email setting
        /// </summary>
        public static string CompanyEmail { get; set; } = "";

        /// <summary>
        /// Company website setting
        /// </summary>
        public static string CompanyWebsite { get; set; } = "";

        /// <summary>
        /// Application theme setting
        /// </summary>
        public static string Theme { get; set; } = "Light";

        /// <summary>
        /// Database backup location setting
        /// </summary>
        public static string BackupLocation { get; set; } = "";

        /// <summary>
        /// Auto backup setting
        /// </summary>
        public static bool AutoBackup { get; set; } = false;

        /// <summary>
        /// Backup frequency in days setting
        /// </summary>
        public static int BackupFrequency { get; set; } = 7;
    }
}