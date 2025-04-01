using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASHome.Models;
using ASHome.Forms;
using FontAwesome.Sharp;

namespace ASHome.Forms
{
    public partial class MainForm : Form
    {
        private readonly User _currentUser;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        // Buttons for the sidebar
        private IconButton btnDashboard;

        // Labels for displaying user information
        private Label lblUserName;
        private Label lblUserRole;

        public MainForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            // Initialize user info labels
            InitializeUserInfoLabels();
        }

        private void InitializeUserInfoLabels()
        {
            // Create and configure user name label
            lblUserName = new Label();
            lblUserName.Text = _currentUser.FullName;
            lblUserName.ForeColor = Color.White;
            lblUserName.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold);
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(10, 5);

            // Create and configure user role label
            lblUserRole = new Label();
            lblUserRole.Text = _currentUser.IsAdmin ? "Admin" : "İstifadəçi";
            lblUserRole.ForeColor = Color.LightGray;
            lblUserRole.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            lblUserRole.AutoSize = true;
            lblUserRole.Location = new Point(10, 25);

            // Add labels to panel
            Panel userInfoPanel = new Panel();
            userInfoPanel.Dock = DockStyle.Top;
            userInfoPanel.Height = 45;
            userInfoPanel.BackColor = Color.FromArgb(39, 39, 58);
            userInfoPanel.Controls.Add(lblUserName);
            userInfoPanel.Controls.Add(lblUserRole);

            // Add panel to menu
            panelMenu.Controls.Add(userInfoPanel);
        }

        // Down payment button click handler
        private void btnDownPayments_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(172, 126, 241));
            OpenChildForm(new DownPaymentForm(_currentUser));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = _currentUser.FullName;
            lblUserRole.Text = _currentUser.IsAdmin ? "Administrator" : "İstifadəçi";

            // Set permissions based on user role
            btnSettings.Visible = _currentUser.IsAdmin;

            // Open dashboard by default
            OpenChildForm(new DashboardForm(_currentUser));
            ActivateButton(btnDashboard, Color.FromArgb(0, 102, 170));
        }

        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();

                // Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(0, 102, 170);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                // Left border
                leftBorderBtn.BackColor = Color.White;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                // Form title
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                lblTitleChildForm.Text = currentBtn.Text;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(0, 122, 204);
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                // Close previous child form
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardForm(_currentUser));
            ActivateButton(sender, Color.FromArgb(0, 102, 170));
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PropertyListingForm(_currentUser));
            ActivateButton(sender, Color.FromArgb(249, 118, 176));
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CustomersForm(_currentUser));
            ActivateButton(sender, Color.FromArgb(253, 138, 114));
        }

        private void btnContracts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ContractsForm(_currentUser));
            ActivateButton(sender, Color.FromArgb(95, 77, 221));
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DownPaymentForm(_currentUser));
            ActivateButton(sender, Color.FromArgb(172, 126, 241));
        }

        // Designer faylına uyğunlaşdırılıb
        // İki metod eyni funksiyanı yerinə yetirir, Designer faylında btnDownPayments istifadə olunur

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EmployeeManagementForm(_currentUser));
            ActivateButton(sender, Color.FromArgb(24, 161, 151));
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ExpensesForm(_currentUser));
            ActivateButton(sender, Color.FromArgb(249, 88, 155));
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportForm(_currentUser));
            ActivateButton(sender, Color.FromArgb(24, 161, 251));
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SettingsForm(_currentUser));
            ActivateButton(sender, Color.FromArgb(95, 77, 221));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hesabdan çıxmaq istədiyinizə əminsiniz?", "Çıxış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btnMaximize.IconChar = IconChar.WindowRestore;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btnMaximize.IconChar = IconChar.WindowMaximize;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Proqramı bağlamaq istədiyinizə əminsiniz?", "Çıxış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Add methods for dragging the form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Method to activate button with color
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                // Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = color;
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                // Left border
                leftBorderBtn.BackColor = Color.White;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                // Form title
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                lblTitleChildForm.Text = currentBtn.Text;
            }
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm(); // Yeni AboutForm yarat
            aboutForm.ShowDialog(); // Modal da aç
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
