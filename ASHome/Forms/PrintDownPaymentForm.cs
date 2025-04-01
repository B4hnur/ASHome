using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // LinearGradientBrush üçün əlavə edildi
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASHome.Models;
using ASHome.Database;

namespace ASHome.Forms
{
    public partial class PrintDownPaymentForm : Form
    {
        private readonly DownPayment _downPayment;
        private readonly User _currentUser;
        private readonly PrintDocument _printDocument = new PrintDocument();
        private string _companyName = "AS Home";

        public PrintDownPaymentForm(DownPayment downPayment, User currentUser)
        {
            InitializeComponent();
            _downPayment = downPayment;
            _currentUser = currentUser;

            // Configure print document
            _printDocument.PrintPage += PrintDocument_PrintPage;

            // Load company info
            LoadCompanyInfo();

            // Load down payment details
            LoadDownPaymentDetails();
        }

        private void LoadCompanyInfo()
        {
            try
            {
                CompanyInfo companyInfo = DatabaseManager.Instance.GetCompanyInfo();
                if (companyInfo != null)
                {
                    _companyName = companyInfo.CompanyName;
                    lblCompanyName.Text = companyInfo.CompanyName;
                    lblCompanyAddress.Text = companyInfo.Address;
                    lblCompanyPhone.Text = companyInfo.Phone;
                    lblCompanyEmail.Text = companyInfo.Email;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şirkət məlumatlarını yükləyərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDownPaymentDetails()
        {
            try
            {
                // Load customer info
                Customer customer = DatabaseManager.Instance.GetCustomerById(_downPayment.CustomerId);
                if (customer != null)
                {
                    lblCustomerName.Text = customer.FullName;
                    lblCustomerPhone.Text = customer.Phone;
                    lblCustomerEmail.Text = customer.Email;
                }

                // Load property info
                Property property = DatabaseManager.Instance.GetPropertyById(_downPayment.PropertyId);
                if (property != null)
                {
                    lblPropertyAddress.Text = property.Address;
                    lblPropertyDetails.Text = $"{property.RoomCount} otaqlı, {property.Area} m²";
                }

                // Load down payment info
                lblDownPaymentId.Text = _downPayment.Id.ToString();
                lblDownPaymentDate.Text = _downPayment.PaymentDate.ToString("dd.MM.yyyy");
                lblDownPaymentAmount.Text = $"{_downPayment.Amount:N2} AZN";
                lblPaymentMethod.Text = _downPayment.PaymentMethod;
                lblDownPaymentNote.Text = _downPayment.Note;

                // Load user info
                lblCreatedBy.Text = _currentUser.FullName;
                lblCreatedDate.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beh məlumatlarını yükləyərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                // Print the entire form content
                Bitmap bitmap = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Çap edərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = _printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    _printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Çap edərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printPreviewDialog.Document = _printDocument;
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Çap önizləməsini açarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            // Paint top panel gradient
            LinearGradientBrush brush = new LinearGradientBrush(
                panelTop.ClientRectangle,
                Color.FromArgb(0, 122, 204),
                Color.FromArgb(0, 102, 170),
                90F);
            e.Graphics.FillRectangle(brush, panelTop.ClientRectangle);
        }

        private void groupBoxProperty_Enter(object sender, EventArgs e)
        {

        }
    }
}