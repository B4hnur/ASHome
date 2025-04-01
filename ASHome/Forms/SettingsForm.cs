using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASHome.Database;
using ASHome.Models;

namespace ASHome.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly User _currentUser;
        private List<User> _users;
        private bool _isEditMode = false;
        private int _selectedUserId = 0;

        public SettingsForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            tabMain.Selected += TabMain_Selected;

            // Set permissions based on user role
            if (!_currentUser.IsAdmin)
            {
                tabMain.TabPages.Remove(tabUsers);
                tabMain.TabPages.Remove(tabBackup);
            }

            // Load company info
            LoadCompanyInfo();

            // Load current user info
            LoadCurrentUserInfo();

            // Load users data if admin
            if (_currentUser.IsAdmin)
            {
                LoadUsers();
            }
        }

        private void TabMain_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabUsers && _currentUser.IsAdmin)
            {
                LoadUsers();
            }
        }

        private void LoadCompanyInfo()
        {
            try
            {
                var companyInfo = DatabaseManager.Instance.GetCompanyInfo();
                if (companyInfo != null)
                {
                    txtCompanyName.Text = companyInfo.CompanyName;
                    txtAddress.Text = companyInfo.Address;
                    txtPhone.Text = companyInfo.Phone;
                    txtEmail.Text = companyInfo.Email;
                    txtWebsite.Text = companyInfo.Website;
                    txtTaxId.Text = companyInfo.TaxId;
                    txtBankDetails.Text = companyInfo.BankDetails;
                    txtLogoPath.Text = companyInfo.LogoPath;

                    if (!string.IsNullOrEmpty(companyInfo.LogoPath) && File.Exists(companyInfo.LogoPath))
                    {
                        try
                        {
                            pbLogo.Image = Image.FromFile(companyInfo.LogoPath);
                        }
                        catch
                        {
                            pbLogo.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şirkət məlumatları yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCurrentUserInfo()
        {
            txtCurrentUsername.Text = _currentUser.Username;
            txtCurrentFullName.Text = _currentUser.FullName;
            txtCurrentEmail.Text = _currentUser.Email ?? string.Empty;
            txtCurrentPhone.Text = _currentUser.Phone ?? string.Empty;
        }

        private void LoadUsers()
        {
            try
            {
                _users = DatabaseManager.Instance.GetAllUsers();
                dgvUsers.Rows.Clear();

                foreach (var user in _users)
                {
                    dgvUsers.Rows.Add(
                        user.Id,
                        user.Username,
                        user.FullName,
                        user.Email ?? "-",
                        user.Phone ?? "-",
                        user.IsAdmin ? "Admin" : "İstifadəçi",
                        user.IsActive ? "Aktiv" : "Deaktiv",
                        user.LastLogin?.ToString("dd.MM.yyyy HH:mm") ?? "-"
                    );
                }

                lblUserCount.Text = $"Cəmi: {_users.Count} istifadəçi";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstifadəçilər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveCompanyInfo_Click(object sender, EventArgs e)
        {
            try
            {
                var companyInfo = new CompanyInfo
                {
                    CompanyName = txtCompanyName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Website = txtWebsite.Text.Trim(),
                    TaxId = txtTaxId.Text.Trim(),
                    BankDetails = txtBankDetails.Text.Trim(),
                    LogoPath = txtLogoPath.Text.Trim()
                };

                bool result = DatabaseManager.Instance.SaveCompanyInfo(companyInfo);

                if (result)
                {
                    MessageBox.Show("Şirkət məlumatları uğurla yeniləndi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Şirkət məlumatları yenilənərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şirkət məlumatları saxlanılarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCurrentFullName.Text))
                {
                    MessageBox.Show("Ad və soyad daxil edilməlidir", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if password should be updated
                bool changePassword = !string.IsNullOrWhiteSpace(txtNewPassword.Text);

                if (changePassword)
                {
                    if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
                    {
                        MessageBox.Show("Cari şifrə daxil edilməlidir", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (txtNewPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show("Yeni şifrə və təsdiq şifrəsi eyni olmalıdır", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Verify current password
                    bool isPasswordValid = DatabaseManager.Instance.VerifyUserPassword(_currentUser.Id, txtCurrentPassword.Text);
                    if (!isPasswordValid)
                    {
                        MessageBox.Show("Cari şifrə düzgün deyil", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var updatedUser = new User
                {
                    Id = _currentUser.Id,
                    Username = _currentUser.Username, // Cannot change username
                    FullName = txtCurrentFullName.Text.Trim(),
                    Email = txtCurrentEmail.Text.Trim(),
                    Phone = txtCurrentPhone.Text.Trim(),
                    IsAdmin = _currentUser.IsAdmin, // Cannot change role
                    IsActive = _currentUser.IsActive
                };

                bool result = DatabaseManager.Instance.UpdateUser(updatedUser, changePassword ? txtNewPassword.Text : null);

                if (result)
                {
                    MessageBox.Show("Profil məlumatları uğurla yeniləndi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear password fields
                    txtCurrentPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Profil məlumatları yenilənərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Profil məlumatları saxlanılarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                // Update user
                if (ValidateUserInput())
                {
                    try
                    {
                        bool changePassword = !string.IsNullOrWhiteSpace(txtUserPassword.Text);

                        var user = new User
                        {
                            Id = _selectedUserId,
                            Username = txtUsername.Text.Trim(),
                            FullName = txtUserFullName.Text.Trim(),
                            Email = txtUserEmail.Text.Trim(),
                            Phone = txtUserPhone.Text.Trim(),
                            IsAdmin = chkIsAdmin.Checked,
                            IsActive = chkIsActive.Checked
                        };

                        bool result = DatabaseManager.Instance.UpdateUser(user, changePassword ? txtUserPassword.Text : null);

                        if (result)
                        {
                            MessageBox.Show("İstifadəçi uğurla yeniləndi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearUserForm();
                            LoadUsers();
                            _isEditMode = false;
                            _selectedUserId = 0;
                            btnAddUser.Text = "Əlavə et";
                            btnCancelEdit.Visible = false;
                            txtUsername.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("İstifadəçi yenilənərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"İstifadəçi yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Add new user
                if (ValidateUserInput(true))
                {
                    try
                    {
                        var user = new User
                        {
                            Username = txtUsername.Text.Trim(),
                            FullName = txtUserFullName.Text.Trim(),
                            Email = txtUserEmail.Text.Trim(),
                            Phone = txtUserPhone.Text.Trim(),
                            IsAdmin = chkIsAdmin.Checked,
                            IsActive = chkIsActive.Checked
                        };

                        int newId = DatabaseManager.Instance.AddUser(user, txtUserPassword.Text);

                        if (newId > 0)
                        {
                            MessageBox.Show("İstifadəçi uğurla əlavə edildi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearUserForm();
                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("İstifadəçi əlavə edilərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"İstifadəçi əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                _selectedUserId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
                string username = dgvUsers.SelectedRows[0].Cells[1].Value.ToString();

                // Prevent editing of current user from this panel
                if (_selectedUserId == _currentUser.Id)
                {
                    MessageBox.Show("Öz profiliniz üçün 'Profil' tabını istifadə edin", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var user = _users.FirstOrDefault(u => u.Id == _selectedUserId);
                if (user != null)
                {
                    txtUsername.Text = user.Username;
                    txtUserFullName.Text = user.FullName;
                    txtUserEmail.Text = user.Email ?? string.Empty;
                    txtUserPhone.Text = user.Phone ?? string.Empty;
                    chkIsAdmin.Checked = user.IsAdmin;
                    chkIsActive.Checked = user.IsActive;

                    txtUsername.Enabled = false; // Cannot change username in edit mode
                    txtUserPassword.Clear();
                    lblPasswordNote.Visible = true;

                    _isEditMode = true;
                    btnAddUser.Text = "Yadda saxla";
                    btnCancelEdit.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Redaktə etmək üçün istifadəçi seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);
                string username = dgvUsers.SelectedRows[0].Cells[1].Value.ToString();

                // Prevent deleting of current user
                if (userId == _currentUser.Id)
                {
                    MessageBox.Show("Öz istifadəçi hesabınızı silə bilməzsiniz", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"'{username}' istifadəçisini silmək istədiyinizə əminsiniz?", "Silmə təsdiqi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bool result = DatabaseManager.Instance.DeleteUser(userId);

                        if (result)
                        {
                            MessageBox.Show("İstifadəçi uğurla silindi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("İstifadəçi silinərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"İstifadəçi silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silmək üçün istifadəçi seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            ClearUserForm();
            _isEditMode = false;
            _selectedUserId = 0;
            btnAddUser.Text = "Əlavə et";
            btnCancelEdit.Visible = false;
            txtUsername.Enabled = true;
            lblPasswordNote.Visible = false;
        }

        private void btnSelectLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Select Logo Image";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                txtLogoPath.Text = fileName;

                try
                {
                    // If existing image, dispose it
                    if (pbLogo.Image != null)
                    {
                        pbLogo.Image.Dispose();
                        pbLogo.Image = null;
                    }

                    // Load new image
                    pbLogo.Image = Image.FromFile(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Logo yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Backup Files (*.bak)|*.bak";
                saveDialog.Title = "Save Database Backup";
                saveDialog.FileName = $"ASHome_Backup_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string backupPath = DatabaseManager.Instance.CreateBackup(saveDialog.FileName);

                    if (!string.IsNullOrEmpty(backupPath))
                    {
                        MessageBox.Show("Verilənlər bazası uğurla yedəkləndi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Verilənlər bazası yedəklənərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yedəkləmə zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Filter = "Backup Files (*.bak)|*.bak";
                openDialog.Title = "Select Database Backup File";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    if (MessageBox.Show("Diqqət! Yedək bərpa edilərkən mövcud məlumatlar silinəcək. Davam etmək istəyirsiniz?",
                        "Xəbərdarlıq", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        bool result = DatabaseManager.Instance.RestoreBackup(openDialog.FileName);

                        if (result)
                        {
                            MessageBox.Show("Verilənlər bazası uğurla bərpa edildi. Proqram yenidən başladılacaq.",
                                "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Restart application
                            Application.Restart();
                        }
                        else
                        {
                            MessageBox.Show("Verilənlər bazası bərpa edilərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bərpa zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateUserInput(bool isNewUser = false)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("İstifadəçi adı daxil edin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUserFullName.Text))
            {
                MessageBox.Show("Ad və soyad daxil edin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (isNewUser && string.IsNullOrWhiteSpace(txtUserPassword.Text))
            {
                MessageBox.Show("Şifrə daxil edin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if username already exists (for new users)
            if (isNewUser && _users.Any(u => u.Username.Equals(txtUsername.Text, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Bu istifadəçi adı artıq mövcuddur", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearUserForm()
        {
            txtUsername.Clear();
            txtUserFullName.Clear();
            txtUserEmail.Clear();
            txtUserPhone.Clear();
            txtUserPassword.Clear();
            chkIsAdmin.Checked = false;
            chkIsActive.Checked = true;
        }
    }
}
