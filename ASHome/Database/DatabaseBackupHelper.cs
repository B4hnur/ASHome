using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASHome.Database
{
    /// <summary>
    /// Helper class for database backup and restore operations
    /// </summary>
    public static class DatabaseBackupHelper
    {
        private static readonly string BackupFolder = Path.Combine(Application.StartupPath, "Backups");
        private static readonly string DbFileName = "ashome.db";
        private static readonly string AppFolder = "ASHome";
        private static readonly string DbFolderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            AppFolder);
        private static readonly string DbPath = Path.Combine(DbFolderPath, DbFileName);

        /// <summary>
        /// Ensure backup directory exists
        /// </summary>
        static DatabaseBackupHelper()
        {
            if (!Directory.Exists(BackupFolder))
            {
                Directory.CreateDirectory(BackupFolder);
            }
        }

        /// <summary>
        /// Create a backup of the database
        /// </summary>
        /// <param name="backupName">Optional backup name</param>
        /// <returns>Backup file path if successful, null otherwise</returns>
        public static string CreateBackup(string backupName = null)
        {
            try
            {
                // Check if database file exists
                if (!File.Exists(DbPath))
                {
                    MessageBox.Show("Verilənlər bazası faylı tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                // Generate backup file name
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string backupFileName = string.IsNullOrEmpty(backupName)
                    ? $"backup_{timestamp}.db"
                    : $"{backupName}_{timestamp}.db";

                string backupPath = Path.Combine(BackupFolder, backupFileName);

                // Copy database file to backup location
                File.Copy(DbPath, backupPath, true);

                return backupPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yedəkləmə yaradılarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Restore a database backup
        /// </summary>
        /// <param name="backupPath">Backup file path</param>
        /// <returns>True if successful, false otherwise</returns>
        public static bool RestoreBackup(string backupPath)
        {
            try
            {
                // Check if backup file exists
                if (!File.Exists(backupPath))
                {
                    MessageBox.Show("Yedək faylı tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Confirm restoration
                DialogResult result = MessageBox.Show(
                    "Yedəyi bərpa etmək mövcud verilənlər bazasını əvəz edəcək. Davam etmək istəyirsiniz?",
                    "Təsdiq",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                {
                    return false;
                }

                // Create backup of current database before restoring
                string currentBackup = CreateBackup("pre_restore");

                // Copy backup file to database location
                File.Copy(backupPath, DbPath, true);

                MessageBox.Show("Yedək uğurla bərpa edildi.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yedək bərpa edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get list of available backups
        /// </summary>
        /// <returns>List of backup files with creation dates</returns>
        public static List<KeyValuePair<string, DateTime>> GetBackupsList()
        {
            List<KeyValuePair<string, DateTime>> backups = new List<KeyValuePair<string, DateTime>>();

            try
            {
                if (Directory.Exists(BackupFolder))
                {
                    DirectoryInfo dir = new DirectoryInfo(BackupFolder);
                    FileInfo[] files = dir.GetFiles("*.db").OrderByDescending(f => f.CreationTime).ToArray();

                    foreach (FileInfo file in files)
                    {
                        backups.Add(new KeyValuePair<string, DateTime>(file.FullName, file.CreationTime));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yedəklər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return backups;
        }
    }
}