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
    public partial class ContractsForm : Form
    {
        private readonly User _currentUser;
        private List<Contract> _contracts;
        private List<Customer> _customers;
        private List<Employee> _employees;
        private List<Property> _properties;
        private bool _isEditMode = false;
        private int _currentContractId = 0;

        public ContractsForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void ContractsForm_Load(object sender, EventArgs e)
        {
            // Set permissions based on user role
            btnDelete.Enabled = _currentUser.IsAdmin;

            // Load lookup data
            LoadCustomers();
            LoadEmployees();
            LoadProperties();

            // Setup combo boxes
            SetupComboBoxes();

            // Load contracts
            LoadContracts();
        }

        private void LoadCustomers()
        {
            try
            {
                _customers = DatabaseManager.Instance.GetAllCustomers();
                cmbCustomer.Items.Clear();
                cmbCustomer.Items.Add("- Seçin -");

                foreach (var customer in _customers)
                {
                    cmbCustomer.Items.Add(customer.FullName);
                }
                cmbCustomer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müştərilər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    cmbProperty.Items.Add($"{property.ListingCode} - {property.Title}");
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
            // Contract types
            cmbType.Items.Clear();
            cmbType.Items.Add("Satış");
            cmbType.Items.Add("Kirayə");
            cmbType.Items.Add("İlkin razılaşma");
            cmbType.Items.Add("Digər");
            cmbType.SelectedIndex = 0;

            // Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Aktiv");
            cmbStatus.Items.Add("Bitmiş");
            cmbStatus.Items.Add("Ləğv edilmiş");
            cmbStatus.SelectedIndex = 0;

            // Filter status
            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.Add("Hamısı");
            cmbFilterStatus.Items.AddRange(cmbStatus.Items.Cast<string>().ToArray());
            cmbFilterStatus.SelectedIndex = 0;
        }

        private void LoadContracts()
        {
            try
            {
                _contracts = DatabaseManager.Instance.GetAllContracts();
                FilterContracts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müqavilələr yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterContracts()
        {
            try
            {
                string statusFilter = cmbFilterStatus.SelectedIndex > 0 ? cmbFilterStatus.SelectedItem.ToString() : null;
                string searchText = txtSearch.Text.Trim().ToLower();
                DateTime startDate = dtpFilterStart.Value.Date;
                DateTime endDate = dtpFilterEnd.Value.Date.AddDays(1).AddSeconds(-1);

                var filteredContracts = _contracts.Where(c => c.SignDate >= startDate && c.SignDate <= endDate).ToList();

                if (!string.IsNullOrEmpty(statusFilter))
                {
                    filteredContracts = filteredContracts.Where(c => c.Status == statusFilter).ToList();
                }

                if (!string.IsNullOrEmpty(searchText))
                {
                    filteredContracts = filteredContracts.Where(c =>
                        c.ContractNumber.ToLower().Contains(searchText) ||
                        (c.CustomerName != null && c.CustomerName.ToLower().Contains(searchText)) ||
                        (c.EmployeeName != null && c.EmployeeName.ToLower().Contains(searchText)) ||
                        (c.PropertyTitle != null && c.PropertyTitle.ToLower().Contains(searchText)) ||
                        (c.Note != null && c.Note.ToLower().Contains(searchText))).ToList();
                }

                dgvContracts.Rows.Clear();
                decimal totalAmount = 0;

                foreach (var contract in filteredContracts)
                {
                    dgvContracts.Rows.Add(
                        contract.Id,
                        contract.ContractNumber,
                        contract.PropertyTitle,
                        contract.CustomerName,
                        contract.EmployeeName,
                        contract.ContractType,
                        contract.ContractAmount.ToString("N2"),
                        contract.SignDate.ToString("dd.MM.yyyy"),
                        contract.Status,
                        contract.Note
                    );

                    totalAmount += contract.ContractAmount;
                }

                lblTotal.Text = $"Cəmi: {filteredContracts.Count} müqavilə / {totalAmount.ToString("N2")} AZN";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müqavilələr filterlənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                // Update contract
                if (ValidateInput())
                {
                    try
                    {
                        var contract = new Contract
                        {
                            Id = _currentContractId,
                            ContractNumber = txtContractNumber.Text.Trim(),
                            PropertyId = cmbProperty.SelectedIndex > 0 ? _properties[cmbProperty.SelectedIndex - 1].Id : 0,
                            CustomerId = cmbCustomer.SelectedIndex > 0 ? _customers[cmbCustomer.SelectedIndex - 1].Id : 0,
                            EmployeeId = cmbEmployee.SelectedIndex > 0 ? _employees[cmbEmployee.SelectedIndex - 1].Id : 0,
                            ContractType = cmbType.SelectedItem.ToString(),
                            ContractAmount = numAmount.Value,
                            StartDate = dtpStartDate.Value,
                            EndDate = cbxHasEndDate.Checked ? dtpEndDate.Value : (DateTime?)null,
                            SignDate = dtpSignDate.Value,
                            Status = cmbStatus.SelectedItem.ToString(),
                            Note = txtNotes.Text.Trim(),
                            UpdatedAt = DateTime.Now
                        };

                        bool result = DatabaseManager.Instance.UpdateContract(contract);

                        if (result)
                        {
                            MessageBox.Show("Müqavilə uğurla yeniləndi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadContracts();
                            _isEditMode = false;
                            _currentContractId = 0;
                            btnAdd.Text = "Əlavə et";
                            btnCancel.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Müqavilə yenilənərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Müqavilə yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Add new contract
                if (ValidateInput())
                {
                    try
                    {
                        var contract = new Contract
                        {
                            ContractNumber = txtContractNumber.Text.Trim(),
                            PropertyId = cmbProperty.SelectedIndex > 0 ? _properties[cmbProperty.SelectedIndex - 1].Id : 0,
                            CustomerId = cmbCustomer.SelectedIndex > 0 ? _customers[cmbCustomer.SelectedIndex - 1].Id : 0,
                            EmployeeId = cmbEmployee.SelectedIndex > 0 ? _employees[cmbEmployee.SelectedIndex - 1].Id : 0,
                            ContractType = cmbType.SelectedItem.ToString(),
                            ContractAmount = numAmount.Value,
                            StartDate = dtpStartDate.Value,
                            EndDate = cbxHasEndDate.Checked ? dtpEndDate.Value : (DateTime?)null,
                            SignDate = dtpSignDate.Value,
                            Status = cmbStatus.SelectedItem.ToString(),
                            Note = txtNotes.Text.Trim(),
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        };

                        int newId = DatabaseManager.Instance.AddContract(contract);

                        if (newId > 0)
                        {
                            MessageBox.Show("Müqavilə uğurla əlavə edildi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadContracts();
                        }
                        else
                        {
                            MessageBox.Show("Müqavilə əlavə edilərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Müqavilə əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvContracts.SelectedRows.Count > 0)
            {
                _currentContractId = Convert.ToInt32(dgvContracts.SelectedRows[0].Cells[0].Value);

                // Find the contract
                var contract = _contracts.FirstOrDefault(c => c.Id == _currentContractId);

                if (contract != null)
                {
                    // Fill form with contract data
                    txtContractNumber.Text = contract.ContractNumber;

                    // Property
                    if (contract.PropertyId > 0)
                    {
                        var property = _properties.FirstOrDefault(p => p.Id == contract.PropertyId);
                        if (property != null)
                        {
                            cmbProperty.SelectedIndex = _properties.IndexOf(property) + 1; // +1 for the "Select" item
                        }
                    }

                    // Customer
                    if (contract.CustomerId > 0)
                    {
                        var customer = _customers.FirstOrDefault(cust => cust.Id == contract.CustomerId);
                        if (customer != null)
                        {
                            cmbCustomer.SelectedIndex = _customers.IndexOf(customer) + 1; // +1 for the "Select" item
                        }
                    }

                    // Employee
                    if (contract.EmployeeId > 0)
                    {
                        var employee = _employees.FirstOrDefault(emp => emp.Id == contract.EmployeeId);
                        if (employee != null)
                        {
                            cmbEmployee.SelectedIndex = _employees.IndexOf(employee) + 1; // +1 for the "Select" item
                        }
                    }

                    // Other fields
                    cmbType.SelectedItem = contract.ContractType;
                    numAmount.Value = contract.ContractAmount;
                    dtpStartDate.Value = contract.StartDate;

                    cbxHasEndDate.Checked = contract.EndDate.HasValue;
                    if (contract.EndDate.HasValue)
                    {
                        dtpEndDate.Value = contract.EndDate.Value;
                    }

                    dtpSignDate.Value = contract.SignDate;
                    cmbStatus.SelectedItem = contract.Status;
                    txtNotes.Text = contract.Note ?? string.Empty;

                    // Switch to edit mode
                    _isEditMode = true;
                    btnAdd.Text = "Yadda saxla";
                    btnCancel.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Redaktə etmək üçün müqavilə seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel edit mode
            _isEditMode = false;
            _currentContractId = 0;

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

            if (dgvContracts.SelectedRows.Count > 0)
            {
                int contractId = Convert.ToInt32(dgvContracts.SelectedRows[0].Cells[0].Value);
                string contractNumber = dgvContracts.SelectedRows[0].Cells[1].Value.ToString();

                if (MessageBox.Show($"'{contractNumber}' müqaviləsini silmək istədiyinizə əminsiniz?", "Silmə təsdiqi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bool result = DatabaseManager.Instance.DeleteContract(contractId);

                        if (result)
                        {
                            MessageBox.Show("Müqavilə uğurla silindi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadContracts();
                        }
                        else
                        {
                            MessageBox.Show("Müqavilə silinərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Müqavilə silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silmək üçün müqavilə seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvContracts.SelectedRows.Count > 0)
            {
                int contractId = Convert.ToInt32(dgvContracts.SelectedRows[0].Cells[0].Value);
                PrintContractForm printForm = new PrintContractForm(contractId);
                printForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Çap etmək üçün müqavilə seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterContracts();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterStatus.SelectedIndex = 0;
            dtpFilterStart.Value = DateTime.Now.AddMonths(-1);
            dtpFilterEnd.Value = DateTime.Now;

            FilterContracts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadContracts();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContracts.Rows.Count > 0)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel Faylı (*.xlsx)|*.xlsx";
                    saveDialog.Title = "Excel Faylını Saxla";
                    saveDialog.FileName = $"Muqavileler_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportHelper.ExportToExcel(dgvContracts, saveDialog.FileName);
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

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContracts.Rows.Count > 0)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "PDF Faylı (*.pdf)|*.pdf";
                    saveDialog.Title = "PDF Faylını Saxla";
                    saveDialog.FileName = $"Muqavileler_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportHelper.ExportToPdf(dgvContracts, saveDialog.FileName);
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

        private void ClearForm()
        {
            txtContractNumber.Text = GenerateContractNumber();
            cmbProperty.SelectedIndex = 0;
            cmbCustomer.SelectedIndex = 0;
            cmbEmployee.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;
            numAmount.Value = 0;
            dtpStartDate.Value = DateTime.Now;
            cbxHasEndDate.Checked = false;
            dtpEndDate.Value = DateTime.Now.AddYears(1);
            dtpSignDate.Value = DateTime.Now;
            cmbStatus.SelectedIndex = 0;
            txtNotes.Clear();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtContractNumber.Text))
            {
                MessageBox.Show("Müqavilə nömrəsi daxil edin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbProperty.SelectedIndex <= 0)
            {
                MessageBox.Show("Əmlak seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbCustomer.SelectedIndex <= 0)
            {
                MessageBox.Show("Müştəri seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbEmployee.SelectedIndex <= 0)
            {
                MessageBox.Show("Əməkdaş seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Müqavilə məbləği sıfırdan böyük olmalıdır", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private string GenerateContractNumber()
        {
            // Generate contract number in format: C-YYMMDD-XXXX
            string date = DateTime.Now.ToString("yyMMdd");
            int count = _contracts != null ? _contracts.Count + 1 : 1;
            return $"C-{date}-{count:D4}";
        }

        private void dgvContracts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFilter_Click(sender, e);
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void cbxHasEndDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = cbxHasEndDate.Checked;
        }
    }
}
