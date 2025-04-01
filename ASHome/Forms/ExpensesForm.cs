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
    public partial class ExpensesForm : Form
    {
        private readonly User _currentUser;
        private List<Expense> _expenses;
        private List<Employee> _employees;
        private List<Property> _properties;
        private bool _isEditMode = false;
        private int _currentExpenseId = 0;

        public ExpensesForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void ExpensesForm_Load(object sender, EventArgs e)
        {
            // Set permissions based on user role
            btnDelete.Enabled = _currentUser.IsAdmin;

            // Load lookup data
            LoadEmployees();
            LoadProperties();

            // Setup combo boxes
            SetupComboBoxes();

            // Load expenses
            LoadExpenses();
        }

        private void LoadEmployees()
        {
            try
            {
                _employees = DatabaseManager.Instance.GetAllEmployees();
                cmbEmployee.Items.Clear();
                cmbEmployee.Items.Add("- Seçin -");

                foreach (var employee in _employees)
                {
                    cmbEmployee.Items.Add(employee.FullName);
                }
                cmbEmployee.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşçilər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProperties()
        {
            try
            {
                _properties = DatabaseManager.Instance.GetAllProperties();
                cmbProperty.Items.Clear();
                cmbProperty.Items.Add("- Seçin -");

                foreach (var property in _properties)
                {
                    cmbProperty.Items.Add(property.Title);
                }
                cmbProperty.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əmlaklar yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupComboBoxes()
        {
            // Expense categories
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Əməliyyat xərcləri");
            cmbCategory.Items.Add("Ofis xərcləri");
            cmbCategory.Items.Add("Maaş");
            cmbCategory.Items.Add("Kommunal");
            cmbCategory.Items.Add("İcarə");
            cmbCategory.Items.Add("Nəqliyyat");
            cmbCategory.Items.Add("Reklam");
            cmbCategory.Items.Add("Digər");
            cmbCategory.SelectedIndex = 0;

            // Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Ödənilib");
            cmbStatus.Items.Add("Gözləmədə");
            cmbStatus.Items.Add("Ləğv edilib");
            cmbStatus.SelectedIndex = 0;

            // Report filter categories
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("Hamısı");
            cmbFilterCategory.Items.AddRange(cmbCategory.Items.Cast<string>().ToArray());
            cmbFilterCategory.SelectedIndex = 0;
        }

        private void LoadExpenses()
        {
            try
            {
                _expenses = DatabaseManager.Instance.GetAllExpenses();
                FilterExpenses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xərclər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterExpenses()
        {
            try
            {
                string categoryFilter = cmbFilterCategory.SelectedIndex > 0 ? cmbFilterCategory.SelectedItem.ToString() : null;
                string searchText = txtSearch.Text.Trim().ToLower();
                DateTime startDate = dtpFilterStart.Value.Date;
                DateTime endDate = dtpFilterEnd.Value.Date.AddDays(1).AddSeconds(-1);

                var filteredExpenses = _expenses.Where(e => e.ExpenseDate >= startDate && e.ExpenseDate <= endDate).ToList();

                if (!string.IsNullOrEmpty(categoryFilter))
                {
                    filteredExpenses = filteredExpenses.Where(e => e.Category == categoryFilter).ToList();
                }

                if (!string.IsNullOrEmpty(searchText))
                {
                    filteredExpenses = filteredExpenses.Where(e =>
                        (e.Description != null && e.Description.ToLower().Contains(searchText)) ||
                        (e.EmployeeName != null && e.EmployeeName.ToLower().Contains(searchText)) ||
                        (e.PropertyTitle != null && e.PropertyTitle.ToLower().Contains(searchText)) ||
                        (e.Note != null && e.Note.ToLower().Contains(searchText))).ToList();
                }

                dgvExpenses.Rows.Clear();
                decimal totalAmount = 0;

                foreach (var expense in filteredExpenses)
                {
                    dgvExpenses.Rows.Add(
                        expense.Id,
                        expense.Category,
                        expense.Description,
                        expense.Amount.ToString("N2"),
                        expense.ExpenseDate.ToString("dd.MM.yyyy"),
                        expense.EmployeeName ?? "-",
                        expense.PropertyTitle ?? "-",
                        expense.Status,
                        expense.Note
                    );

                    totalAmount += expense.Amount;
                }

                lblTotal.Text = $"Cəmi: {filteredExpenses.Count} xərc / {totalAmount.ToString("N2")} AZN";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xərclər filterlənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                // Update expense
                if (ValidateInput())
                {
                    try
                    {
                        var expense = new Expense
                        {
                            Id = _currentExpenseId,
                            Category = cmbCategory.SelectedItem.ToString(),
                            Description = txtDescription.Text.Trim(),
                            Amount = decimal.Parse(txtAmount.Text.Trim()),
                            ExpenseDate = dtpExpenseDate.Value,
                            EmployeeId = cmbEmployee.SelectedIndex > 0 ? _employees[cmbEmployee.SelectedIndex - 1].Id : (int?)null,
                            PropertyId = cmbProperty.SelectedIndex > 0 ? _properties[cmbProperty.SelectedIndex - 1].Id : (int?)null,
                            Status = cmbStatus.SelectedItem.ToString(),
                            Note = txtNotes.Text.Trim()
                        };

                        bool result = DatabaseManager.Instance.UpdateExpense(expense);

                        if (result)
                        {
                            MessageBox.Show("Xərc uğurla yeniləndi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadExpenses();
                            _isEditMode = false;
                            _currentExpenseId = 0;
                            btnAdd.Text = "Əlavə et";
                            btnCancel.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Xərc yenilənərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Xərc yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Add new expense
                if (ValidateInput())
                {
                    try
                    {
                        var expense = new Expense
                        {
                            Category = cmbCategory.SelectedItem.ToString(),
                            Description = txtDescription.Text.Trim(),
                            Amount = decimal.Parse(txtAmount.Text.Trim()),
                            ExpenseDate = dtpExpenseDate.Value,
                            EmployeeId = cmbEmployee.SelectedIndex > 0 ? _employees[cmbEmployee.SelectedIndex - 1].Id : (int?)null,
                            PropertyId = cmbProperty.SelectedIndex > 0 ? _properties[cmbProperty.SelectedIndex - 1].Id : (int?)null,
                            Status = cmbStatus.SelectedItem.ToString(),
                            Note = txtNotes.Text.Trim()
                        };

                        int newId = DatabaseManager.Instance.AddExpense(expense);

                        if (newId > 0)
                        {
                            MessageBox.Show("Xərc uğurla əlavə edildi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadExpenses();
                        }
                        else
                        {
                            MessageBox.Show("Xərc əlavə edilərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Xərc əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows.Count > 0)
            {
                _currentExpenseId = Convert.ToInt32(dgvExpenses.SelectedRows[0].Cells[0].Value);

                // Find the expense
                var expense = _expenses.FirstOrDefault(exp => exp.Id == _currentExpenseId);

                if (expense != null)
                {
                    // Fill form with expense data
                    cmbCategory.SelectedItem = expense.Category;
                    txtDescription.Text = expense.Description;
                    txtAmount.Text = expense.Amount.ToString();
                    dtpExpenseDate.Value = expense.ExpenseDate;

                    if (expense.EmployeeId.HasValue)
                    {
                        var employee = _employees.FirstOrDefault(emp => emp.Id == expense.EmployeeId.Value);
                        if (employee != null)
                        {
                            cmbEmployee.SelectedIndex = _employees.IndexOf(employee) + 1; // +1 for the first "Select" item
                        }
                    }
                    else
                    {
                        cmbEmployee.SelectedIndex = 0;
                    }

                    if (expense.PropertyId.HasValue)
                    {
                        var property = _properties.FirstOrDefault(p => p.Id == expense.PropertyId.Value);
                        if (property != null)
                        {
                            cmbProperty.SelectedIndex = _properties.IndexOf(property) + 1; // +1 for the first "Select" item
                        }
                    }
                    else
                    {
                        cmbProperty.SelectedIndex = 0;
                    }

                    cmbStatus.SelectedItem = expense.Status;
                    txtNotes.Text = expense.Note ?? string.Empty;

                    // Switch to edit mode
                    _isEditMode = true;
                    btnAdd.Text = "Yadda saxla";
                    btnCancel.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Redaktə etmək üçün xərc seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel edit mode
            _isEditMode = false;
            _currentExpenseId = 0;

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

            if (dgvExpenses.SelectedRows.Count > 0)
            {
                int expenseId = Convert.ToInt32(dgvExpenses.SelectedRows[0].Cells[0].Value);
                string expenseDesc = dgvExpenses.SelectedRows[0].Cells[2].Value.ToString();

                if (MessageBox.Show($"'{expenseDesc}' xərcini silmək istədiyinizə əminsiniz?", "Silmə təsdiqi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bool result = DatabaseManager.Instance.DeleteExpense(expenseId);

                        if (result)
                        {
                            MessageBox.Show("Xərc uğurla silindi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadExpenses();
                        }
                        else
                        {
                            MessageBox.Show("Xərc silinərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Xərc silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silmək üçün xərc seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterExpenses();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterCategory.SelectedIndex = 0;
            dtpFilterStart.Value = DateTime.Now.AddMonths(-1);
            dtpFilterEnd.Value = DateTime.Now;

            FilterExpenses();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadExpenses();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpenses.Rows.Count > 0)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel Faylı (*.xlsx)|*.xlsx";
                    saveDialog.Title = "Excel Faylını Saxla";
                    saveDialog.FileName = $"Xercler_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportHelper.ExportToExcel(dgvExpenses, saveDialog.FileName);
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
            cmbCategory.SelectedIndex = 0;
            txtDescription.Clear();
            txtAmount.Text = "0";
            dtpExpenseDate.Value = DateTime.Now;
            cmbEmployee.SelectedIndex = 0;
            cmbProperty.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            txtNotes.Clear();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Təsvir daxil edin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Məbləğ düzgün daxil edilməyib", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void dgvExpenses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpenses.Rows.Count > 0)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "PDF Faylı (*.pdf)|*.pdf";
                    saveDialog.Title = "PDF Faylını Saxla";
                    saveDialog.FileName = $"Xercler_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportHelper.ExportToPdf(dgvExpenses, saveDialog.FileName);
                        MessageBox.Show("PDF faylı uğurla yaradıldı!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
