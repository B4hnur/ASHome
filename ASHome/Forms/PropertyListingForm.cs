using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ASHome.Database;
using ASHome.Models;
using ASHome.Utils;

namespace ASHome.Forms
{
    public partial class PropertyListingForm : Form
    {
        private readonly User _currentUser;
        private List<Property> _properties;
        private List<Employee> _employees;

        public PropertyListingForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void PropertyListingForm_Load(object sender, EventArgs e)
        {
            // Set control access based on user role
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = _currentUser.IsAdmin;

            // Setup comboboxes
            SetupComboBoxes();

            // Load data
            LoadProperties();
        }

        private void SetupComboBoxes()
        {
            // Property types
            cmbPropertyType.Items.Clear();
            cmbPropertyType.Items.Add("Hamısı");
            cmbPropertyType.Items.Add("Mənzil");
            cmbPropertyType.Items.Add("Ev / Villa");
            cmbPropertyType.Items.Add("Torpaq");
            cmbPropertyType.Items.Add("Obyekt");
            cmbPropertyType.Items.Add("Ofis");
            cmbPropertyType.SelectedIndex = 0;

            // Property status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Hamısı");
            cmbStatus.Items.Add("Satılır");
            cmbStatus.Items.Add("Kirayə verilir");
            cmbStatus.Items.Add("Satılıb");
            cmbStatus.Items.Add("Kirayə verilib");
            cmbStatus.Items.Add("Rezerv edilib");
            cmbStatus.SelectedIndex = 0;

            // Agents/Employees
            try
            {
                _employees = DatabaseManager.Instance.GetAllEmployees();
                cmbAgent.Items.Clear();
                cmbAgent.Items.Add("Hamısı");

                foreach (var employee in _employees)
                {
                    cmbAgent.Items.Add(employee.FullName);
                }

                cmbAgent.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProperties()
        {
            try
            {
                _properties = DatabaseManager.Instance.GetAllProperties() ?? new List<Property>();
                ApplyFilters();
            }
            catch (Exception ex)
            {
                _properties = new List<Property>();
                MessageBox.Show($"Əmlaklar yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ApplyFilters(); // Yenə də UI-yi gündəm əsaslı olaraq yeniləyin
            }
        }

        private void ApplyFilters()
        {
            try
            {
                // Apply filters
                string propertyType = cmbPropertyType.SelectedIndex > 0 ? cmbPropertyType.SelectedItem.ToString() : null;
                string status = cmbStatus.SelectedIndex > 0 ? cmbStatus.SelectedItem.ToString() : null;
                string agent = cmbAgent.SelectedIndex > 0 ? cmbAgent.SelectedItem.ToString() : null;
                string searchText = txtSearch.Text.Trim().ToLower();

                var filteredProperties = _properties ?? new List<Property>();

                // Filter by type
                if (!string.IsNullOrEmpty(propertyType))
                {
                    filteredProperties = filteredProperties.FindAll(p => p.Type == propertyType);
                }

                // Filter by status
                if (!string.IsNullOrEmpty(status))
                {
                    filteredProperties = filteredProperties.FindAll(p => p.Status == status);
                }

                // Filter by agent
                if (!string.IsNullOrEmpty(agent))
                {
                    filteredProperties = filteredProperties.FindAll(p => p.EmployeeName == agent);
                }

                // Filter by search text
                if (!string.IsNullOrEmpty(searchText))
                {
                    filteredProperties = filteredProperties.FindAll(p =>
                        p.Title.ToLower().Contains(searchText) ||
                        p.Address.ToLower().Contains(searchText) ||
                        p.ListingCode.ToLower().Contains(searchText) ||
                        (p.Description != null && p.Description.ToLower().Contains(searchText)));
                }

                // Update UI
                dgvProperties.DataSource = null;
                dgvProperties.Rows.Clear();

                foreach (var property in filteredProperties)
                {
                    int rowIndex = dgvProperties.Rows.Add();
                    var row = dgvProperties.Rows[rowIndex];

                    row.Cells["colId"].Value = property.Id;
                    row.Cells["colCode"].Value = property.ListingCode;
                    row.Cells["colTitle"].Value = property.Title;
                    row.Cells["colType"].Value = property.Type;
                    row.Cells["colAddress"].Value = property.Address;
                    row.Cells["colRooms"].Value = property.Rooms?.ToString() ?? "-";
                    row.Cells["colArea"].Value = property.Area;
                    row.Cells["colPrice"].Value = property.Price;
                    row.Cells["colStatus"].Value = property.Status;
                    row.Cells["colAgentName"].Value = property.EmployeeName ?? "-";
                    row.Cells["colImageCount"].Value = property.ImageCount;
                }

                lblTotal.Text = $"Cəmi: {filteredProperties.Count} əmlak";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Filtrlər tətbiq edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbPropertyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbPropertyType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbAgent.SelectedIndex = 0;
            ApplyFilters();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PropertyDetailsForm detailsForm = new PropertyDetailsForm(_currentUser);
            detailsForm.ShowDialog();
            LoadProperties();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProperties.SelectedRows.Count > 0)
            {
                int propertyId = Convert.ToInt32(dgvProperties.SelectedRows[0].Cells["colId"].Value);
                PropertyDetailsForm detailsForm = new PropertyDetailsForm(_currentUser, propertyId);
                detailsForm.ShowDialog();
                LoadProperties();
            }
            else
            {
                MessageBox.Show("Redaktə etmək üçün bir əmlak seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_currentUser.IsAdmin)
            {
                MessageBox.Show("Bu əməliyyat üçün admin hüquqları tələb olunur", "İcazə yoxdur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvProperties.SelectedRows.Count > 0)
            {
                int propertyId = Convert.ToInt32(dgvProperties.SelectedRows[0].Cells["colId"].Value);
                string propertyTitle = dgvProperties.SelectedRows[0].Cells["colTitle"].Value.ToString();

                if (MessageBox.Show($"'{propertyTitle}' əmlakını silmək istədiyinizə əminsiniz?", "Silmə təsdiqi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bool result = DatabaseManager.Instance.DeleteProperty(propertyId);
                        if (result)
                        {
                            MessageBox.Show("Əmlak uğurla silindi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadProperties();
                        }
                        else
                        {
                            MessageBox.Show("Əmlak silinərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Əmlak silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silmək üçün bir əmlak seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProperties.Rows.Count > 0)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel Faylı (*.xlsx)|*.xlsx";
                    saveDialog.Title = "Excel Faylını Saxla";
                    saveDialog.FileName = $"Emlaklar_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportHelper.ExportToExcel(dgvProperties, saveDialog.FileName, "Əmlaklar");
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

        private void dgvProperties_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int propertyId = Convert.ToInt32(dgvProperties.Rows[e.RowIndex].Cells["colId"].Value);
                PropertyDetailsForm detailsForm = new PropertyDetailsForm(_currentUser, propertyId);
                detailsForm.ShowDialog();
                LoadProperties();
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

        private void dgvProperties_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
