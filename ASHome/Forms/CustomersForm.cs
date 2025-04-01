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
    public partial class CustomersForm : Form
    {
        private readonly User _currentUser;
        private List<Customer> _customers;
        private bool _isEditMode = false;
        private int _currentCustomerId = 0;

        public CustomersForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            // Set permissions based on user role
            btnDelete.Enabled = _currentUser.IsAdmin;

            // Load customers
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                _customers = DatabaseManager.Instance.GetAllCustomers();
                FilterCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müştərilər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterCustomers()
        {
            try
            {
                string searchText = txtSearch.Text.Trim().ToLower();

                var filteredCustomers = _customers;

                if (!string.IsNullOrEmpty(searchText))
                {
                    filteredCustomers = filteredCustomers.Where(c =>
                        c.FullName.ToLower().Contains(searchText) ||
                        c.PhoneNumber.ToLower().Contains(searchText) ||
                        (c.Email != null && c.Email.ToLower().Contains(searchText)) ||
                        (c.IdNumber != null && c.IdNumber.ToLower().Contains(searchText)) ||
                        (c.Address != null && c.Address.ToLower().Contains(searchText))).ToList();
                }

                dgvCustomers.Rows.Clear();
                foreach (var customer in filteredCustomers)
                {
                    dgvCustomers.Rows.Add(
                        customer.Id,
                        customer.FullName,
                        customer.PhoneNumber,
                        customer.Email ?? "-",
                        customer.IdNumber ?? "-",
                        customer.Address ?? "-",
                        customer.Note ?? "-",
                        customer.CreatedAt.ToString("dd.MM.yyyy")
                    );
                }

                lblTotal.Text = $"Cəmi: {filteredCustomers.Count} müştəri";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müştərilər filterlənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                // Update customer
                if (ValidateInput())
                {
                    try
                    {
                        var customer = new Customer
                        {
                            Id = _currentCustomerId,
                            FullName = txtFullName.Text.Trim(),
                            PhoneNumber = txtPhone.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            IdNumber = txtIdNumber.Text.Trim(),
                            Address = txtAddress.Text.Trim(),
                            Note = txtNotes.Text.Trim(),
                            UpdatedAt = DateTime.Now
                        };

                        bool result = DatabaseManager.Instance.UpdateCustomer(customer);

                        if (result)
                        {
                            MessageBox.Show("Müştəri uğurla yeniləndi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadCustomers();
                            _isEditMode = false;
                            _currentCustomerId = 0;
                            btnAdd.Text = "Əlavə et";
                            btnCancel.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Müştəri yenilənərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Müştəri yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Add new customer
                if (ValidateInput())
                {
                    try
                    {
                        var customer = new Customer
                        {
                            FullName = txtFullName.Text.Trim(),
                            PhoneNumber = txtPhone.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            IdNumber = txtIdNumber.Text.Trim(),
                            Address = txtAddress.Text.Trim(),
                            Note = txtNotes.Text.Trim(),
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        };

                        int newId = DatabaseManager.Instance.AddCustomer(customer);

                        if (newId > 0)
                        {
                            MessageBox.Show("Müştəri uğurla əlavə edildi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadCustomers();
                        }
                        else
                        {
                            MessageBox.Show("Müştəri əlavə edilərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Müştəri əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                _currentCustomerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells[0].Value);

                // Find the customer
                var customer = _customers.FirstOrDefault(c => c.Id == _currentCustomerId);

                if (customer != null)
                {
                    // Fill form with customer data
                    txtFullName.Text = customer.FullName;
                    txtPhone.Text = customer.PhoneNumber;
                    txtEmail.Text = customer.Email ?? string.Empty;
                    txtIdNumber.Text = customer.IdNumber ?? string.Empty;
                    txtAddress.Text = customer.Address ?? string.Empty;
                    txtNotes.Text = customer.Note ?? string.Empty;

                    // Switch to edit mode
                    _isEditMode = true;
                    btnAdd.Text = "Yadda saxla";
                    btnCancel.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Redaktə etmək üçün müştəri seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel edit mode
            _isEditMode = false;
            _currentCustomerId = 0;

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

            if (dgvCustomers.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells[0].Value);
                string customerName = dgvCustomers.SelectedRows[0].Cells[1].Value.ToString();

                if (MessageBox.Show($"'{customerName}' müştərisini silmək istədiyinizə əminsiniz?", "Silmə təsdiqi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bool result = DatabaseManager.Instance.DeleteCustomer(customerId);

                        if (result)
                        {
                            MessageBox.Show("Müştəri uğurla silindi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomers();
                        }
                        else
                        {
                            MessageBox.Show("Müştəri silinərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Müştəri silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silmək üçün müştəri seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterCustomers();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            FilterCustomers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers.Rows.Count > 0)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel Faylı (*.xlsx)|*.xlsx";
                    saveDialog.Title = "Excel Faylını Saxla";
                    saveDialog.FileName = $"Musteriler_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportHelper.ExportToExcel(dgvCustomers, saveDialog.FileName);
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
                if (dgvCustomers.Rows.Count > 0)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "PDF Faylı (*.pdf)|*.pdf";
                    saveDialog.Title = "PDF Faylını Saxla";
                    saveDialog.FileName = $"Musteriler_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportHelper.ExportToPdf(dgvCustomers, saveDialog.FileName);
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
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtIdNumber.Clear();
            txtAddress.Clear();
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

            return true;
        }

        private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                btnSearch_Click(sender, e);
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
