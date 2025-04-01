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
using ASHome.Utils;

namespace ASHome.Forms
{
    public partial class EmployeeManagementForm : Form
    {
        private readonly User _currentUser;
        private List<Employee> _employees;
        private bool _isEditMode = false;
        private int _currentEmployeeId = 0;

        public EmployeeManagementForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void EmployeeManagementForm_Load(object sender, EventArgs e)
        {
            // Set permissions based on user role
            btnDelete.Enabled = _currentUser.IsAdmin;

            // Setup combo boxes
            SetupComboBoxes();

            // Load data
            LoadEmployees();
        }

        private void SetupComboBoxes()
        {
            // Employee positions
            cmbPosition.Items.Clear();
            cmbPosition.Items.Add("Agent");
            cmbPosition.Items.Add("Menecer");
            cmbPosition.Items.Add("Ofis işçisi");
            cmbPosition.Items.Add("Administrator");
            cmbPosition.SelectedIndex = 0;

            // Employee status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Aktiv");
            cmbStatus.Items.Add("Qeyri-aktiv");
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadEmployees()
        {
            try
            {
                _employees = DatabaseManager.Instance.GetAllEmployees();

                dgvEmployees.Rows.Clear();
                foreach (var employee in _employees)
                {
                    dgvEmployees.Rows.Add(
                        employee.Id,
                        employee.FullName,
                        employee.Position,
                        employee.PhoneNumber,
                        employee.Email,
                        employee.Salary,
                        employee.HireDate.ToString("dd.MM.yyyy"),
                        employee.Status,
                        employee.UserId.HasValue ? "Bəli" : "Xeyr"
                    );
                }

                lblTotal.Text = $"Cəmi: {_employees.Count} işçi";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşçilər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                // Cancel edit mode
                _isEditMode = false;
                _currentEmployeeId = 0;

                // Reset form
                ClearForm();
                btnAdd.Text = "Əlavə et";
                btnCancel.Visible = false;
            }
            else
            {
                // Add new employee
                if (ValidateInput())
                {
                    try
                    {
                        var employee = new Employee
                        {
                            FullName = txtFullName.Text.Trim(),
                            Position = cmbPosition.SelectedItem.ToString(),
                            PhoneNumber = txtPhone.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Salary = decimal.Parse(txtSalary.Text.Trim()),
                            HireDate = dtpHireDate.Value,
                            Status = cmbStatus.SelectedItem.ToString(),
                            Note = txtNotes.Text.Trim()
                        };

                        int newId = DatabaseManager.Instance.AddEmployee(employee);

                        if (newId > 0)
                        {
                            MessageBox.Show("İşçi uğurla əlavə edildi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadEmployees();
                        }
                        else
                        {
                            MessageBox.Show("İşçi əlavə edilərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"İşçi əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                _currentEmployeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[0].Value);

                // Find the employee
                var employee = _employees.FirstOrDefault(emp => emp.Id == _currentEmployeeId);

                if (employee != null)
                {
                    // Fill form with employee data
                    txtFullName.Text = employee.FullName;
                    cmbPosition.SelectedItem = employee.Position;
                    txtPhone.Text = employee.PhoneNumber;
                    txtEmail.Text = employee.Email ?? string.Empty;
                    txtSalary.Text = employee.Salary.ToString();
                    dtpHireDate.Value = employee.HireDate;
                    cmbStatus.SelectedItem = employee.Status;
                    txtNotes.Text = employee.Note ?? string.Empty;

                    // Switch to edit mode
                    _isEditMode = true;
                    btnAdd.Text = "Yadda saxla";
                    btnCancel.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Redaktə etmək üçün işçi seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel edit mode
            _isEditMode = false;
            _currentEmployeeId = 0;

            // Reset form
            ClearForm();
            btnAdd.Text = "Əlavə et";
            btnCancel.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_currentUser.IsAdmin)
            {
                MessageBox.Show("Bu əməliyyat üçün admin hüquqları tələb olunur", "İcazə yoxdur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvEmployees.SelectedRows.Count > 0)
            {
                int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[0].Value);
                string employeeName = dgvEmployees.SelectedRows[0].Cells[1].Value.ToString();

                if (MessageBox.Show($"'{employeeName}' işçisini silmək istədiyinizə əminsiniz?", "Silmə təsdiqi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bool result = DatabaseManager.Instance.DeleteEmployee(employeeId);

                        if (result)
                        {
                            MessageBox.Show("İşçi uğurla silindi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployees();
                        }
                        else
                        {
                            MessageBox.Show("İşçi silinərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"İşçi silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silmək üçün işçi seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnAssignUser_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[0].Value);
                var employee = _employees.FirstOrDefault(emp => emp.Id == employeeId);

                if (employee != null)
                {
                    using (var form = new UserAssignmentForm(employee))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadEmployees();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("İstifadəçi təyin etmək üçün işçi seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployees.Rows.Count > 0)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel Faylı (*.xlsx)|*.xlsx";
                    saveDialog.Title = "Excel Faylını Saxla";
                    saveDialog.FileName = $"Isciler_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportHelper.ExportToExcel(dgvEmployees, saveDialog.FileName);
                        MessageBox.Show("Excel faylı uğurla yaradıldı!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("İxrac etmək üçün məlumat yoxdur", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İxrac zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtFullName.Clear();
            cmbPosition.SelectedIndex = 0;
            txtPhone.Clear();
            txtEmail.Clear();
            txtSalary.Text = "0";
            dtpHireDate.Value = DateTime.Now;
            cmbStatus.SelectedIndex = 0;
            txtNotes.Clear();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Ad və soyad daxil edin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Telefon nömrəsi daxil edin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal salary;
            if (!decimal.TryParse(txtSalary.Text, out salary) || salary < 0)
            {
                MessageBox.Show("Maaş düzgün daxil edilməyib", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            // Apply filter
            dgvEmployees.Rows.Clear();

            var filteredEmployees = string.IsNullOrEmpty(searchText)
                ? _employees
                : _employees.Where(emp =>
                    emp.FullName.ToLower().Contains(searchText) ||
                    emp.Position.ToLower().Contains(searchText) ||
                    emp.PhoneNumber.ToLower().Contains(searchText) ||
                    (emp.Email != null && emp.Email.ToLower().Contains(searchText))).ToList();

            foreach (var employee in filteredEmployees)
            {
                dgvEmployees.Rows.Add(
                    employee.Id,
                    employee.FullName,
                    employee.Position,
                    employee.PhoneNumber,
                    employee.Email,
                    employee.Salary,
                    employee.HireDate.ToString("dd.MM.yyyy"),
                    employee.Status,
                    employee.UserId.HasValue ? "Bəli" : "Xeyr"
                );
            }

            lblTotal.Text = $"Cəmi: {filteredEmployees.Count} işçi";
        }
    }

    // Additional internal form for user assignment
    public class UserAssignmentForm : Form
    {
        private Employee _employee;
        private List<User> _users;

        public UserAssignmentForm(Employee employee)
        {
            _employee = employee;
            InitializeComponent();
        }

        private void UserAssignmentForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{_employee.FullName} - İstifadəçi Təyinatı";
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                _users = DatabaseManager.Instance.GetAllUsers();
                cmbUsers.Items.Clear();
                cmbUsers.Items.Add("- İstifadəçi seçin -");

                foreach (var user in _users)
                {
                    cmbUsers.Items.Add($"{user.Username} ({user.FullName})");
                }

                cmbUsers.SelectedIndex = 0;

                // If employee already has a user assigned
                if (_employee.UserId.HasValue)
                {
                    var assignedUser = _users.FirstOrDefault(u => u.Id == _employee.UserId.Value);
                    if (assignedUser != null)
                    {
                        int index = _users.IndexOf(assignedUser) + 1; // +1 for the first "Select user" item
                        cmbUsers.SelectedIndex = index;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstifadəçilər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUsers.SelectedIndex > 0)
                {
                    int selectedUserIndex = cmbUsers.SelectedIndex - 1; // -1 for the first "Select user" item
                    int userId = _users[selectedUserIndex].Id;

                    // Update employee with user
                    _employee.UserId = userId;
                    bool result = DatabaseManager.Instance.UpdateEmployee(_employee);

                    if (result)
                    {
                        MessageBox.Show("İstifadəçi təyinatı uğurla yeniləndi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("İstifadəçi təyinatı yenilənərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Remove user assignment
                    _employee.UserId = null;
                    bool result = DatabaseManager.Instance.UpdateEmployee(_employee);

                    if (result)
                    {
                        MessageBox.Show("İstifadəçi təyinatı uğurla silindi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("İstifadəçi təyinatı silinərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstifadəçi təyinatı yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "İstifadəçi:";
            // 
            // cmbUsers
            // 
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(76, 12);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(247, 21);
            this.cmbUsers.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(139, 51);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Yadda saxla";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(234, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Ləğv et";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UserAssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 91);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserAssignmentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "İstifadəçi Təyinatı";
            this.Load += new System.EventHandler(this.UserAssignmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
