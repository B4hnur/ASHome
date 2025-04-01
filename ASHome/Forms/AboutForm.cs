using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ASHome.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            // Set logo and version info
            lblVersion.Text = $"Versiya: {Application.ProductVersion}";
            lblBuildDate.Text = $"Yaradılma tarixi: {File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToString("dd.MM.yyyy")}";

            // Set copyright and developer info
            lblDeveloper.Text = "© Bahnur Baghirov tərəfindən hazırlanıb";
            lblCopyright.Text = "AS Home Daşınmaz Əmlak Agentliyi üçün kiçik bir hədiyyə";
            lblRights.Text = "Bütün hüquqlar qorunur. Heç bir şəxs tərəfindən izlənilə və hücum edilə bilməz!";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.ashome.az");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblRights_Click(object sender, EventArgs e)
        {

        }
    }
}