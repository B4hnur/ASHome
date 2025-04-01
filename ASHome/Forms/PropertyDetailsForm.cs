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
using ASHome.Utils;

namespace ASHome.Forms
{
    public partial class PropertyDetailsForm : Form
    {
        private readonly User _currentUser;
        private int _propertyId = 0;
        private Property _property;
        private List<Employee> _employees;
        private List<string> _imagesToUpload = new List<string>();
        private List<int> _imagesToDelete = new List<int>();
        private int _currentImageIndex = 0;

        // Constructor for new property
        public PropertyDetailsForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            Text = "Yeni Əmlak";
            btnDeleteImage.Visible = false;
        }

        // Constructor for existing property
        public PropertyDetailsForm(User currentUser, int propertyId)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _propertyId = propertyId;
            Text = "Əmlak Redaktəsi";
        }

        private void PropertyDetailsForm_Load(object sender, EventArgs e)
        {
            SetupComboBoxes();

            if (_propertyId > 0)
            {
                // Load existing property data
                LoadProperty();
            }
            else
            {
                // Generate new property code
                txtListingCode.Text = GeneratePropertyCode();
                dtpCreatedAt.Value = DateTime.Now;
                dtpUpdatedAt.Value = DateTime.Now;
            }
        }

        private void SetupComboBoxes()
        {
            // Property types
            cmbType.Items.Clear();
            cmbType.Items.Add("Mənzil");
            cmbType.Items.Add("Ev / Villa");
            cmbType.Items.Add("Torpaq");
            cmbType.Items.Add("Obyekt");
            cmbType.Items.Add("Ofis");
            cmbType.SelectedIndex = 0;

            // Property status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Satılır");
            cmbStatus.Items.Add("Kirayə verilir");
            cmbStatus.Items.Add("Satılıb");
            cmbStatus.Items.Add("Kirayə verilib");
            cmbStatus.Items.Add("Rezerv edilib");
            cmbStatus.SelectedIndex = 0;

            // Cities
            cmbCity.Items.Clear();
            cmbCity.Items.Add("Bakı");
            cmbCity.Items.Add("Sumqayıt");
            cmbCity.Items.Add("Gəncə");
            cmbCity.Items.Add("Mingəçevir");
            cmbCity.Items.Add("Şəki");
            cmbCity.Items.Add("Quba");
            cmbCity.Items.Add("Lənkəran");
            cmbCity.Items.Add("Digər");
            cmbCity.SelectedIndex = 0;

            // Employees/Agents
            try
            {
                _employees = DatabaseManager.Instance.GetAllEmployees();
                cmbEmployee.Items.Clear();
                cmbEmployee.Items.Add("- Təyin edilməyib -");

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

        private string GeneratePropertyCode()
        {
            // Generate property code in format: AS-YYMMDD-XXX
            string date = DateTime.Now.ToString("yyMMdd");
            string random = new Random().Next(100, 999).ToString();
            return $"AS-{date}-{random}";
        }

        private void LoadProperty()
        {
            try
            {
                _property = DatabaseManager.Instance.GetPropertyById(_propertyId, true);

                if (_property != null)
                {
                    // Basic info
                    txtListingCode.Text = _property.ListingCode;
                    txtTitle.Text = _property.Title;
                    txtDescription.Text = _property.Description;
                    txtAddress.Text = _property.Address;

                    // Selects
                    cmbCity.SelectedItem = _property.City;
                    cmbType.SelectedItem = _property.Type;
                    cmbStatus.SelectedItem = _property.Status;

                    // Numbers
                    numArea.Value = _property.Area;
                    numPrice.Value = _property.Price;

                    if (_property.Rooms.HasValue)
                        numRooms.Value = _property.Rooms.Value;

                    if (_property.Bathrooms.HasValue)
                        numBathrooms.Value = _property.Bathrooms.Value;

                    if (_property.Floor.HasValue)
                        numFloor.Value = _property.Floor.Value;

                    if (_property.TotalFloors.HasValue)
                        numTotalFloors.Value = _property.TotalFloors.Value;

                    if (_property.BuiltYear.HasValue)
                        numBuiltYear.Value = _property.BuiltYear.Value;

                    txtSourceUrl.Text = _property.SourceUrl;

                    // Dates
                    dtpCreatedAt.Value = _property.CreatedAt;
                    dtpUpdatedAt.Value = _property.UpdatedAt;

                    // Employee
                    if (_property.EmployeeId.HasValue)
                    {
                        var employee = _employees.FirstOrDefault(e => e.Id == _property.EmployeeId.Value);
                        if (employee != null)
                        {
                            int index = _employees.IndexOf(employee) + 1; // +1 for the "Not assigned" item
                            cmbEmployee.SelectedIndex = index;
                        }
                    }

                    // Load images
                    if (_property.Images != null && _property.Images.Count > 0)
                    {
                        LoadPropertyImages();
                    }
                    else
                    {
                        lblImageCount.Text = "Şəkil: 0/0";
                    }
                }
                else
                {
                    MessageBox.Show("Əmlak tapılmadı", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əmlak yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadPropertyImages()
        {
            try
            {
                if (_property.Images != null && _property.Images.Count > 0)
                {
                    lblImageCount.Text = $"Şəkil: 1/{_property.Images.Count}";
                    _currentImageIndex = 0;
                    DisplayCurrentImage();
                    btnDeleteImage.Visible = true;
                }
                else
                {
                    lblImageCount.Text = "Şəkil: 0/0";
                    pictureBox.Image = null;
                    btnDeleteImage.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şəkillər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayCurrentImage()
        {
            if (_property?.Images == null || _property.Images.Count == 0 || _currentImageIndex < 0 || _currentImageIndex >= _property.Images.Count)
            {
                pictureBox.Image = null;
                return;
            }

            try
            {
                // Clear existing image first to free memory
                if (pictureBox.Image != null)
                {
                    pictureBox.Image.Dispose();
                    pictureBox.Image = null;
                }

                string imagePath = _property.Images[_currentImageIndex].ImagePath;
                if (File.Exists(imagePath))
                {
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        pictureBox.Image = Image.FromStream(stream);
                    }
                    lblImageCount.Text = $"Şəkil: {_currentImageIndex + 1}/{_property.Images.Count}";
                }
                else
                {
                    pictureBox.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şəkil göstərilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox.Image = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (_propertyId > 0)
                {
                    UpdateProperty();
                }
                else
                {
                    AddProperty();
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Başlıq daxil edin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Ünvan daxil edin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Qiymət sıfırdan böyük olmalıdır", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numArea.Value <= 0)
            {
                MessageBox.Show("Sahə sıfırdan böyük olmalıdır", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void AddProperty()
        {
            try
            {
                var property = new Property
                {
                    ListingCode = txtListingCode.Text.Trim(),
                    Type = cmbType.SelectedItem.ToString(),
                    Title = txtTitle.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    City = cmbCity.SelectedItem.ToString(),
                    Area = numArea.Value,
                    Price = numPrice.Value,
                    Rooms = numRooms.Value > 0 ? (int?)numRooms.Value : null,
                    Bathrooms = numBathrooms.Value > 0 ? (int?)numBathrooms.Value : null,
                    Floor = numFloor.Value > 0 ? (int?)numFloor.Value : null,
                    TotalFloors = numTotalFloors.Value > 0 ? (int?)numTotalFloors.Value : null,
                    BuiltYear = numBuiltYear.Value > 0 ? (int?)numBuiltYear.Value : null,
                    Status = cmbStatus.SelectedItem.ToString(),
                    EmployeeId = cmbEmployee.SelectedIndex > 0 ? _employees[cmbEmployee.SelectedIndex - 1].Id : (int?)null,
                    SourceUrl = txtSourceUrl.Text.Trim(),
                    CreatedAt = dtpCreatedAt.Value,
                    UpdatedAt = dtpUpdatedAt.Value
                };

                int newId = DatabaseManager.Instance.AddProperty(property);

                if (newId > 0)
                {
                    // Upload images if any
                    if (_imagesToUpload.Count > 0)
                    {
                        var savedPaths = ImageHelper.SavePropertyImages(newId, _imagesToUpload);
                        DatabaseManager.Instance.AddPropertyImages(newId, savedPaths);
                    }

                    MessageBox.Show("Əmlak uğurla əlavə edildi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Əmlak əlavə edilərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əmlak əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProperty()
        {
            try
            {
                var property = new Property
                {
                    Id = _propertyId,
                    ListingCode = txtListingCode.Text.Trim(),
                    Type = cmbType.SelectedItem.ToString(),
                    Title = txtTitle.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    City = cmbCity.SelectedItem.ToString(),
                    Area = numArea.Value,
                    Price = numPrice.Value,
                    Rooms = numRooms.Value > 0 ? (int?)numRooms.Value : null,
                    Bathrooms = numBathrooms.Value > 0 ? (int?)numBathrooms.Value : null,
                    Floor = numFloor.Value > 0 ? (int?)numFloor.Value : null,
                    TotalFloors = numTotalFloors.Value > 0 ? (int?)numTotalFloors.Value : null,
                    BuiltYear = numBuiltYear.Value > 0 ? (int?)numBuiltYear.Value : null,
                    Status = cmbStatus.SelectedItem.ToString(),
                    EmployeeId = cmbEmployee.SelectedIndex > 0 ? _employees[cmbEmployee.SelectedIndex - 1].Id : (int?)null,
                    SourceUrl = txtSourceUrl.Text.Trim(),
                    CreatedAt = dtpCreatedAt.Value,
                    UpdatedAt = DateTime.Now
                };

                bool result = DatabaseManager.Instance.UpdateProperty(property);

                if (result)
                {
                    // Delete marked images
                    foreach (var imageId in _imagesToDelete)
                    {
                        DatabaseManager.Instance.DeletePropertyImage(imageId);
                    }

                    // Upload new images if any
                    if (_imagesToUpload.Count > 0)
                    {
                        var savedPaths = ImageHelper.SavePropertyImages(_propertyId, _imagesToUpload);
                        DatabaseManager.Instance.AddPropertyImages(_propertyId, savedPaths);
                    }

                    MessageBox.Show("Əmlak uğurla yeniləndi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Əmlak yenilənərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əmlak yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Şəkil faylları (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Şəkil faylları seçin";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        _imagesToUpload.Add(file);
                    }

                    MessageBox.Show($"{openFileDialog.FileNames.Length} şəkil seçildi. Dəyişikliklər yadda saxlandıqdan sonra yüklənəcək.", "Məlumat",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şəkil seçilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrevImage_Click(object sender, EventArgs e)
        {
            if (_property?.Images != null && _property.Images.Count > 0)
            {
                _currentImageIndex--;
                if (_currentImageIndex < 0)
                    _currentImageIndex = _property.Images.Count - 1;
                DisplayCurrentImage();
            }
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            if (_property?.Images != null && _property.Images.Count > 0)
            {
                _currentImageIndex++;
                if (_currentImageIndex >= _property.Images.Count)
                    _currentImageIndex = 0;
                DisplayCurrentImage();
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (_property?.Images != null && _property.Images.Count > 0 && _currentImageIndex >= 0 && _currentImageIndex < _property.Images.Count)
            {
                if (MessageBox.Show("Bu şəkli silmək istədiyinizə əminsiniz?", "Silmə təsdiqi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int imageId = _property.Images[_currentImageIndex].Id;
                    _imagesToDelete.Add(imageId);

                    // Remove from current view
                    _property.Images.RemoveAt(_currentImageIndex);

                    if (_property.Images.Count > 0)
                    {
                        if (_currentImageIndex >= _property.Images.Count)
                            _currentImageIndex = _property.Images.Count - 1;
                        DisplayCurrentImage();
                    }
                    else
                    {
                        pictureBox.Image = null;
                        lblImageCount.Text = "Şəkil: 0/0";
                        btnDeleteImage.Visible = false;
                    }
                }
            }
        }
    }
}
