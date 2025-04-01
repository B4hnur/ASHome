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
    public partial class DownPaymentForm : Form
    {
        private readonly User _currentUser;
        private List<DownPayment> _downPayments;
        private List<Contract> _contracts;
        private bool _isEditMode = false;
        private int _currentPaymentId = 0;

        public DownPaymentForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void DownPaymentForm_Load(object sender, EventArgs e)
        {
            // Set permissions based on user role
            btnDelete.Enabled = _currentUser.IsAdmin;

            // Load contracts
            LoadContracts();

            // Setup combo boxes
            SetupComboBoxes();

            // Load down payments
            LoadDownPayments();

            // Set default dates
            dtpFilterStart.Value = DateTime.Now.AddMonths(-1);
            dtpFilterEnd.Value = DateTime.Now;
            dtpPaymentDate.Value = DateTime.Now;
        }

        private void LoadContracts()
        {
            try
            {
                _contracts = DatabaseManager.Instance.GetAllContracts();
                cmbContract.Items.Clear();
                cmbContract.Items.Add("- Seçin -");

                foreach (var contract in _contracts)
                {
                    cmbContract.Items.Add($"{contract.ContractNumber} - {contract.CustomerName}");
                }
                cmbContract.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müqavilələr yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupComboBoxes()
        {
            // Payment methods
            cmbPaymentType.Items.Clear();
            cmbPaymentType.Items.Add("Nağd");
            cmbPaymentType.Items.Add("Bank köçürməsi");
            cmbPaymentType.Items.Add("Kredit kartı");
            cmbPaymentType.Items.Add("Digər");
            cmbPaymentType.SelectedIndex = 0;

            // Payment status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Ödənilib");
            cmbStatus.Items.Add("Gözləyir");
            cmbStatus.Items.Add("Ləğv edilib");
            cmbStatus.SelectedIndex = 0;

            // Filter status
            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.Add("Hamısı");
            cmbFilterStatus.Items.AddRange(cmbStatus.Items.Cast<string>().ToArray());
            cmbFilterStatus.SelectedIndex = 0;
        }

        private void LoadDownPayments()
        {
            try
            {
                _downPayments = DatabaseManager.Instance.GetAllDownPayments();
                FilterDownPayments();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Avans ödənişləri yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterDownPayments()
        {
            try
            {
                string statusFilter = cmbFilterStatus.SelectedIndex > 0 ? cmbFilterStatus.SelectedItem.ToString() : null;
                string searchText = txtSearch.Text.Trim().ToLower();
                DateTime startDate = dtpFilterStart.Value.Date;
                DateTime endDate = dtpFilterEnd.Value.Date.AddDays(1).AddSeconds(-1);

                var filteredPayments = _downPayments.Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate).ToList();

                if (!string.IsNullOrEmpty(statusFilter))
                {
                    filteredPayments = filteredPayments.Where(p => p.Status == statusFilter).ToList();
                }

                if (!string.IsNullOrEmpty(searchText))
                {
                    filteredPayments = filteredPayments.Where(p =>
                        p.PaymentNumber.ToLower().Contains(searchText) ||
                        (p.ContractNumber != null && p.ContractNumber.ToLower().Contains(searchText)) ||
                        (p.CustomerName != null && p.CustomerName.ToLower().Contains(searchText)) ||
                        (p.Note != null && p.Note.ToLower().Contains(searchText))).ToList();
                }

                dgvDownPayments.Rows.Clear();
                decimal totalAmount = 0;

                foreach (var payment in filteredPayments)
                {
                    dgvDownPayments.Rows.Add(
                        payment.Id,
                        payment.PaymentNumber,
                        payment.ContractNumber,
                        payment.CustomerName,
                        payment.Amount.ToString("N2"),
                        payment.PaymentType,
                        payment.PaymentDate.ToString("dd.MM.yyyy"),
                        payment.Status,
                        payment.Note
                    );

                    totalAmount += payment.Amount;
                }

                lblTotal.Text = $"Cəmi: {filteredPayments.Count} ödəniş / {totalAmount.ToString("N2")} AZN";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödənişlər filterlənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_isEditMode)
            {
                // Update payment
                if (ValidateInput())
                {
                    try
                    {
                        var payment = new DownPayment
                        {
                            Id = _currentPaymentId,
                            PaymentNumber = txtPaymentNumber.Text.Trim(),
                            ContractId = cmbContract.SelectedIndex > 0 ? _contracts[cmbContract.SelectedIndex - 1].Id : 0,
                            Amount = numAmount.Value,
                            PaymentType = cmbPaymentType.SelectedItem.ToString(),
                            PaymentDate = dtpPaymentDate.Value,
                            Status = cmbStatus.SelectedItem.ToString(),
                            Note = txtNotes.Text.Trim(),
                            UpdatedAt = DateTime.Now
                        };

                        bool result = DatabaseManager.Instance.UpdateDownPayment(payment);

                        if (result)
                        {
                            MessageBox.Show("Avans ödənişi uğurla yeniləndi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadDownPayments();
                            _isEditMode = false;
                            _currentPaymentId = 0;
                            btnAdd.Text = "Əlavə et";
                            btnCancel.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Avans ödənişi yenilənərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Avans ödənişi yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Add new payment
                if (ValidateInput())
                {
                    try
                    {
                        var payment = new DownPayment
                        {
                            PaymentNumber = txtPaymentNumber.Text.Trim(),
                            ContractId = cmbContract.SelectedIndex > 0 ? _contracts[cmbContract.SelectedIndex - 1].Id : 0,
                            Amount = numAmount.Value,
                            PaymentType = "Avans",  // Default payment type as "Avans"
                            PaymentMethod = cmbPaymentType.SelectedItem.ToString(), // Use the payment method from combobox
                            PaymentDate = dtpPaymentDate.Value,
                            Status = cmbStatus.SelectedItem.ToString(),
                            Note = txtNotes.Text.Trim(),
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        };

                        int newId = DatabaseManager.Instance.AddDownPayment(payment);

                        if (newId > 0)
                        {
                            MessageBox.Show("Avans ödənişi uğurla əlavə edildi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadDownPayments();
                        }
                        else
                        {
                            MessageBox.Show("Avans ödənişi əlavə edilərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Avans ödənişi əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDownPayments.SelectedRows.Count > 0)
            {
                _currentPaymentId = Convert.ToInt32(dgvDownPayments.SelectedRows[0].Cells[0].Value);

                // Find the payment
                var payment = _downPayments.FirstOrDefault(p => p.Id == _currentPaymentId);

                if (payment != null)
                {
                    // Fill form with payment data
                    txtPaymentNumber.Text = payment.PaymentNumber;

                    // Contract
                    if (payment.ContractId > 0)
                    {
                        var contract = _contracts.FirstOrDefault(c => c.Id == payment.ContractId);
                        if (contract != null)
                        {
                            cmbContract.SelectedIndex = _contracts.IndexOf(contract) + 1; // +1 for the "Select" item
                        }
                    }

                    // Other fields
                    numAmount.Value = payment.Amount;
                    cmbPaymentType.SelectedItem = payment.PaymentType;
                    dtpPaymentDate.Value = payment.PaymentDate;
                    cmbStatus.SelectedItem = payment.Status;
                    txtNotes.Text = payment.Note ?? string.Empty;

                    // Switch to edit mode
                    _isEditMode = true;
                    btnAdd.Text = "Yadda saxla";
                    btnCancel.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Redaktə etmək üçün ödəniş seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel edit mode
            _isEditMode = false;
            _currentPaymentId = 0;

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

            if (dgvDownPayments.SelectedRows.Count > 0)
            {
                int paymentId = Convert.ToInt32(dgvDownPayments.SelectedRows[0].Cells[0].Value);
                string paymentNumber = dgvDownPayments.SelectedRows[0].Cells[1].Value.ToString();

                if (MessageBox.Show($"'{paymentNumber}' nömrəli avans ödənişini silmək istədiyinizə əminsiniz?", "Silmə təsdiqi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        bool result = DatabaseManager.Instance.DeleteDownPayment(paymentId);

                        if (result)
                        {
                            MessageBox.Show("Avans ödənişi uğurla silindi", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDownPayments();
                        }
                        else
                        {
                            MessageBox.Show("Avans ödənişi silinərkən xəta baş verdi", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Avans ödənişi silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silmək üçün ödəniş seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvDownPayments.SelectedRows.Count > 0)
            {
                int paymentId = Convert.ToInt32(dgvDownPayments.SelectedRows[0].Cells[0].Value);

                // Önce ödeme detaylarını getir
                DownPayment payment = DatabaseManager.Instance.GetDownPaymentById(paymentId);

                // PrintDownPaymentForm constructor'ına güncel kullanıcıyı da gönder
                PrintDownPaymentForm printForm = new PrintDownPaymentForm(payment, _currentUser);
                printForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Çap etmək üçün ödəniş seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterDownPayments();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterStatus.SelectedIndex = 0;
            dtpFilterStart.Value = DateTime.Now.AddMonths(-1);
            dtpFilterEnd.Value = DateTime.Now;

            FilterDownPayments();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDownPayments();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDownPayments.Rows.Count > 0)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel Faylı (*.xlsx)|*.xlsx";
                    saveDialog.Title = "Excel Faylını Saxla";
                    saveDialog.FileName = $"AvansOdenisleri_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportHelper.ExportToExcel(dgvDownPayments, saveDialog.FileName);
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
                if (dgvDownPayments.Rows.Count > 0)
                {
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "PDF Faylı (*.pdf)|*.pdf";
                    saveDialog.Title = "PDF Faylını Saxla";
                    saveDialog.FileName = $"AvansOdenisleri_{DateTime.Now:yyyyMMdd_HHmmss}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportHelper.ExportToPdf(dgvDownPayments, saveDialog.FileName);
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
            txtPaymentNumber.Text = GeneratePaymentNumber();
            cmbContract.SelectedIndex = 0;
            numAmount.Value = 0;
            cmbPaymentType.SelectedIndex = 0;
            dtpPaymentDate.Value = DateTime.Now;
            cmbStatus.SelectedIndex = 0;
            txtNotes.Clear();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtPaymentNumber.Text))
            {
                MessageBox.Show("Ödəniş nömrəsi daxil edin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbContract.SelectedIndex <= 0)
            {
                MessageBox.Show("Müqavilə seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numAmount.Value <= 0)
            {
                MessageBox.Show("Ödəniş məbləği sıfırdan böyük olmalıdır", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private string GeneratePaymentNumber()
        {
            // Generate payment number in format: DP-YYMMDD-XXXX
            string date = DateTime.Now.ToString("yyMMdd");
            int count = _downPayments != null ? _downPayments.Count + 1 : 1;
            return $"DP-{date}-{count:D4}";
        }

        private void dgvDownPayments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
