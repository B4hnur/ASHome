using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASHome.Database;
using ASHome.Forms;

namespace ASHome
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Create necessary directories
                CreateDirectories();

                // Initialize database
                var db = DatabaseManager.Instance;

                try
                {
                    db.InitializeDatabase();
                }
                catch (Exception dbEx)
                {
                    string dbPath = Path.Combine(Application.StartupPath, "ashome.db");
                    MessageBox.Show($"Verilənlər bazası yaradılarkən xəta: {dbEx.Message}\nVB yolu: {dbPath}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Start with login form
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Proqram işə salınarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Create necessary directories for the application
        /// </summary>
        static void CreateDirectories()
        {
            try
            {
                // Create Images directory
                string imagesDir = Path.Combine(Application.StartupPath, "Images");
                if (!Directory.Exists(imagesDir))
                {
                    Directory.CreateDirectory(imagesDir);
                }

                // Create Properties directory within Images
                string propertiesDir = Path.Combine(imagesDir, "Properties");
                if (!Directory.Exists(propertiesDir))
                {
                    Directory.CreateDirectory(propertiesDir);
                }

                // Create Exports directory
                string exportsDir = Path.Combine(Application.StartupPath, "Exports");
                if (!Directory.Exists(exportsDir))
                {
                    Directory.CreateDirectory(exportsDir);
                }

                // Create Contracts directory
                string contractsDir = Path.Combine(Application.StartupPath, "Contracts");
                if (!Directory.Exists(contractsDir))
                {
                    Directory.CreateDirectory(contractsDir);
                }

                // Create Backups directory
                string backupsDir = Path.Combine(Application.StartupPath, "Backups");
                if (!Directory.Exists(backupsDir))
                {
                    Directory.CreateDirectory(backupsDir);
                }

                // Display application directory for debugging
                if (!Directory.Exists(Application.StartupPath))
                {
                    MessageBox.Show($"Proqram qovluğu mövcud deyil: {Application.StartupPath}", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Qovluqlar yaradılarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
