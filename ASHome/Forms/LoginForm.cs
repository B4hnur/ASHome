using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASHome.Database;
using ASHome.Models;

namespace ASHome.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Properties.Settings.Default.RememberUsername;
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                chkRememberMe.Checked = true;
                txtPassword.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    // Authenticate user
                    User user = DatabaseManager.Instance.AuthenticateUser(txtUsername.Text, txtPassword.Text);

                    if (user != null)
                    {
                        // Save username if remember me is checked
                        Properties.Settings.Default.RememberUsername = chkRememberMe.Checked ? txtUsername.Text : string.Empty;
                        Properties.Settings.Default.Save();

                        // Open main form
                        MainForm mainForm = new MainForm(user);
                        this.Hide();
                        mainForm.FormClosed += (s, args) => this.Close();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("İstifadəçi adı və ya şifrə yanlışdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Giriş zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("İstifadəçi adı daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Şifrə daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
