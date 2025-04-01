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
using iTextSharp.text;
using iTextSharp.text.pdf;
// Qarışıqlığın qarşısını almaq üçün iTextSharp və System.Drawing üçün alias istifadə edirik
using FontType = iTextSharp.text.Font;
using PDFStyle = iTextSharp.text.Font;
using SysFont = System.Drawing.Font;

namespace ASHome.Forms
{
    public partial class PrintContractForm : Form
    {
        private int _contractId;
        private Contract _contract;

        /// <summary>
        /// Panel paint event handler
        /// </summary>
        private void panelTop_Paint(object sender, PaintEventArgs e)
        {
            // Custom painting for panel top if needed
        }

        public PrintContractForm(int contractId)
        {
            InitializeComponent();
            _contractId = contractId;
        }

        private void PrintContractForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadContract();
                LoadPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müqavilə məlumatları yüklənərkən xəta baş verdi: {ex.Message}",
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadContract()
        {
            _contract = DatabaseManager.Instance.GetContractById(_contractId);

            if (_contract == null)
            {
                MessageBox.Show("Müqavilə tapılmadı", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Fill form data
            txtContractNumber.Text = _contract.ContractNumber;
            txtCustomer.Text = _contract.CustomerName;
            txtProperty.Text = _contract.PropertyTitle;
            txtAmount.Text = _contract.ContractAmount.ToString("N2");
            dtpSignDate.Value = _contract.SignDate;

            // Populate ComboBox
            cmbTemplates.Items.Clear();
            cmbTemplates.Items.Add("Standart müqavilə");
            cmbTemplates.Items.Add("Satış müqaviləsi");
            cmbTemplates.Items.Add("Kirayə müqaviləsi");

            if (_contract.ContractType.Contains("Satış"))
            {
                cmbTemplates.SelectedIndex = 1;
            }
            else if (_contract.ContractType.Contains("Kirayə"))
            {
                cmbTemplates.SelectedIndex = 2;
            }
            else
            {
                cmbTemplates.SelectedIndex = 0;
            }
        }

        private void LoadPreview()
        {
            try
            {
                // Generate a temporary PDF
                string tempFile = Path.GetTempFileName() + ".pdf";
                GenerateContractPdf(tempFile);

                // Load to WebBrowser
                webBrowser.Navigate(tempFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Önbaxış yaradılarkən xəta baş verdi: {ex.Message}",
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPreview();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Faylı (*.pdf)|*.pdf";
                saveDialog.Title = "Müqaviləni saxla";
                saveDialog.FileName = $"Muqavile_{_contract.ContractNumber}_{DateTime.Now:yyyyMMdd}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Generate PDF to the selected file
                    GenerateContractPdf(saveDialog.FileName);

                    MessageBox.Show("Müqavilə uğurla yaradıldı!", "Məlumat",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Ask if user wants to open the file
                    if (MessageBox.Show("Yaradılan faylı açmaq istəyirsinizmi?", "Sual",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müqavilə yaradılarkən xəta baş verdi: {ex.Message}",
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateContractPdf(string filePath)
        {
            // Create a document
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Add logo if exists
            string logoPath = Path.Combine(Application.StartupPath, "logo.png");
            if (File.Exists(logoPath))
            {
                try
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.ScaleToFit(100, 100);
                    logo.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                    document.Add(logo);
                    document.Add(new Paragraph(" "));
                }
                catch { /* Ignore if logo cannot be added */ }
            }

            // Font settings for Azerbaijani characters
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            FontType titleFont = new FontType(baseFont, 16, FontType.BOLD);
            FontType subtitleFont = new FontType(baseFont, 12, FontType.BOLD);
            FontType normalFont = new FontType(baseFont, 11, FontType.NORMAL);
            FontType smallFont = new FontType(baseFont, 9, FontType.NORMAL);
            FontType boldFont = new FontType(baseFont, 11, FontType.BOLD);

            // Title
            Paragraph title = new Paragraph("AS HOME ƏMLAK ŞİRKƏTİ", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Subtitle - Contract Type
            Paragraph subtitle = new Paragraph($"{cmbTemplates.SelectedItem}", subtitleFont);
            subtitle.Alignment = Element.ALIGN_CENTER;
            document.Add(subtitle);

            // Date and number
            Paragraph dateInfo = new Paragraph($"Tarix: {dtpSignDate.Value:dd.MM.yyyy}", normalFont);
            dateInfo.Alignment = Element.ALIGN_RIGHT;
            document.Add(dateInfo);

            Paragraph numberInfo = new Paragraph($"№: {_contract.ContractNumber}", normalFont);
            numberInfo.Alignment = Element.ALIGN_RIGHT;
            document.Add(numberInfo);

            document.Add(new Paragraph(" "));

            // Contract content - vary by template
            switch (cmbTemplates.SelectedIndex)
            {
                case 1: // Sales Contract
                    GenerateSalesContract(document, normalFont, boldFont);
                    break;
                case 2: // Rental Contract
                    GenerateRentalContract(document, normalFont, boldFont);
                    break;
                default: // Standard Contract
                    GenerateStandardContract(document, normalFont, boldFont);
                    break;
            }

            // Footer
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

            PdfPTable signaturesTable = new PdfPTable(2);
            signaturesTable.WidthPercentage = 100;

            PdfPCell cell1 = new PdfPCell(new Phrase("Satıcı / İcarəyə verən:", boldFont));
            cell1.Border = 0;
            signaturesTable.AddCell(cell1);

            PdfPCell cell2 = new PdfPCell(new Phrase("Alıcı / İcarəçi:", boldFont));
            cell2.Border = 0;
            signaturesTable.AddCell(cell2);

            PdfPCell cell3 = new PdfPCell(new Phrase("AS HOME ƏMLAK", normalFont));
            cell3.Border = 0;
            signaturesTable.AddCell(cell3);

            PdfPCell cell4 = new PdfPCell(new Phrase(_contract.CustomerName, normalFont));
            cell4.Border = 0;
            signaturesTable.AddCell(cell4);

            PdfPCell cell5 = new PdfPCell(new Phrase("İmza: ____________________", normalFont));
            cell5.Border = 0;
            signaturesTable.AddCell(cell5);

            PdfPCell cell6 = new PdfPCell(new Phrase("İmza: ____________________", normalFont));
            cell6.Border = 0;
            signaturesTable.AddCell(cell6);

            document.Add(signaturesTable);

            // Footer with company info
            document.Add(new Paragraph(" "));
            Paragraph footerInfo = new Paragraph("AS HOME ƏMLAK ŞİRKƏTİ - Əlaqə: +994 XX XXX XX XX, Email: info@ashome.az", smallFont);
            footerInfo.Alignment = Element.ALIGN_CENTER;
            document.Add(footerInfo);

            // Close document
            document.Close();
        }

        private void GenerateStandardContract(Document document, FontType normalFont, FontType boldFont)
        {
            document.Add(new Paragraph("TƏRƏFLƏRİN RƏSMİ RAZILAŞMASI", boldFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph($"Bu razılaşma bir tərəfdən AS HOME ƏMLAK ŞİRKƏTİ (bundan sonra \"Satıcı\" adlandırılacaq) və digər tərəfdən {_contract.CustomerName} (bundan sonra \"Alıcı\" adlandırılacaq) arasında aşağıdakı şərtlərlə bağlanmışdır:", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("1. Razılaşmanın predmeti", boldFont));
            document.Add(new Paragraph($"1.1. Satıcı, {_contract.PropertyTitle} ünvanında yerləşən əmlakı (bundan sonra \"Əmlak\" adlandırılacaq) Alıcıya satmağı / icarəyə verməyi öhdəsinə götürür.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("2. Razılaşma məbləği", boldFont));
            document.Add(new Paragraph($"2.1. Tərəflər razılaşıblar ki, Əmlakın dəyəri {_contract.ContractAmount:N2} (yazı ilə: {NumberToWords((double)_contract.ContractAmount)}) Azərbaycan Manatı təşkil edir.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("3. Ödəniş şərtləri", boldFont));
            document.Add(new Paragraph("3.1. Alıcı razılaşdırılmış məbləği aşağıdakı qaydada ödəməyi öhdəsinə götürür:", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("4. Tərəflərin öhdəlikləri", boldFont));
            document.Add(new Paragraph("4.1. Satıcı Əmlakı Alıcının mülkiyyətinə / istifadəsinə satmağı / verməyi öhdəsinə götürür.", normalFont));
            document.Add(new Paragraph("4.2. Alıcı razılaşdırılmış məbləği tam şəkildə ödəməyi öhdəsinə götürür.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("5. Yekun müddəalar", boldFont));
            document.Add(new Paragraph("5.1. Bu razılaşma imzalandığı tarixdən qüvvəyə minir.", normalFont));
            document.Add(new Paragraph("5.2. Razılaşma Azərbaycan Respublikasının qanunvericiliyinə uyğun olaraq tənzimlənir.", normalFont));
            document.Add(new Paragraph("5.3. Bu razılaşma iki nüsxədə tərtib edilmişdir və hər iki nüsxə eyni hüquqi qüvvəyə malikdir.", normalFont));
        }

        /// <summary>
        /// Convert number to words in Azerbaijani language
        /// </summary>
        /// <param name="number">Number to convert</param>
        /// <returns>Number in words</returns>

        private void GenerateSalesContract(Document document, FontType normalFont, FontType boldFont)
        {
            document.Add(new Paragraph("SATIŞ MÜQAVİLƏSİ", boldFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph($"Bu müqavilə bir tərəfdən AS HOME ƏMLAK ŞİRKƏTİ (bundan sonra \"Satıcı\" adlandırılacaq) və digər tərəfdən {_contract.CustomerName} (bundan sonra \"Alıcı\" adlandırılacaq) arasında aşağıdakı şərtlərlə bağlanmışdır:", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("1. Müqavilənin predmeti", boldFont));
            document.Add(new Paragraph($"1.1. Satıcı, {_contract.PropertyTitle} ünvanında yerləşən əmlakı (bundan sonra \"Əmlak\" adlandırılacaq) Alıcıya satmağı, Alıcı isə həmin Əmlakı satın almağı və onun dəyərini ödəməyi öhdəsinə götürür.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("2. Əmlakın xüsusiyyətləri", boldFont));
            document.Add(new Paragraph("2.1. Əmlakın dəqiq ünvanı, sahəsi, otaqların sayı və digər xüsusiyyətləri müqaviləyə əlavə edilən sənədlərdə əks olunmuşdur.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("3. Müqavilə məbləği və ödəniş şərtləri", boldFont));
            document.Add(new Paragraph($"3.1. Tərəflər razılaşıblar ki, Əmlakın satış qiyməti {_contract.ContractAmount:N2} (yazı ilə: {NumberToWords((double)_contract.ContractAmount)}) Azərbaycan Manatı təşkil edir.", normalFont));
            document.Add(new Paragraph("3.2. Ödəniş aşağıdakı qaydada həyata keçiriləcək:", normalFont));
            document.Add(new Paragraph("    - Müqavilə imzalandığı gün: 30% məbləğ", normalFont));
            document.Add(new Paragraph("    - Qalan məbləğ: Əmlakın təhvil verildiyi gün", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("4. Tərəflərin hüquq və öhdəlikləri", boldFont));
            document.Add(new Paragraph("4.1. Satıcı:", normalFont));
            document.Add(new Paragraph("    - Əmlakı razılaşdırılmış müddətdə və şərtlərlə Alıcıya təhvil verməyi öhdəsinə götürür.", normalFont));
            document.Add(new Paragraph("    - Əmlakın hüquqi cəhətdən təmiz olduğunu təmin edir.", normalFont));
            document.Add(new Paragraph("4.2. Alıcı:", normalFont));
            document.Add(new Paragraph("    - Razılaşdırılmış məbləği müqavilə şərtlərinə uyğun ödəməyi öhdəsinə götürür.", normalFont));
            document.Add(new Paragraph("    - Əmlakı qəbul etdikdən sonra onunla bağlı bütün xərcləri ödəməyi öhdəsinə götürür.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("5. Müqavilənin müddəti", boldFont));
            document.Add(new Paragraph("5.1. Bu müqavilə imzalandığı tarixdən qüvvəyə minir və tərəflərin bütün öhdəliklərini tam yerinə yetirdiyi tarixə qədər qüvvədədir.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("6. Yekun müddəalar", boldFont));
            document.Add(new Paragraph("6.1. Müqavilə Azərbaycan Respublikasının qanunvericiliyinə uyğun olaraq tənzimlənir.", normalFont));
            document.Add(new Paragraph("6.2. Tərəflər arasında yaranan bütün mübahisələr danışıqlar yolu ilə həll ediləcək. Razılıq əldə edilmədiyi təqdirdə, mübahisələr Azərbaycan Respublikasının qanunvericiliyinə uyğun olaraq məhkəmə qaydasında həll ediləcək.", normalFont));
            document.Add(new Paragraph("6.3. Bu müqavilə iki nüsxədə tərtib edilmişdir və hər iki nüsxə eyni hüquqi qüvvəyə malikdir.", normalFont));
        }

        private void GenerateRentalContract(Document document, FontType normalFont, FontType boldFont)
        {
            document.Add(new Paragraph("İCARƏ MÜQAVİLƏSİ", boldFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph($"Bu müqavilə bir tərəfdən AS HOME ƏMLAK ŞİRKƏTİ (bundan sonra \"İcarəyə verən\" adlandırılacaq) və digər tərəfdən {_contract.CustomerName} (bundan sonra \"İcarəçi\" adlandırılacaq) arasında aşağıdakı şərtlərlə bağlanmışdır:", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("1. Müqavilənin predmeti", boldFont));
            document.Add(new Paragraph($"1.1. İcarəyə verən, {_contract.PropertyTitle} ünvanında yerləşən əmlakı (bundan sonra \"Əmlak\" adlandırılacaq) İcarəçiyə müvəqqəti istifadə üçün verməyi, İcarəçi isə həmin Əmlakı qəbul etməyi və icarə haqqını ödəməyi öhdəsinə götürür.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("2. İcarə müddəti", boldFont));
            string endDateText = _contract.EndDate.HasValue ? $"{_contract.EndDate.Value:dd.MM.yyyy}" : "qeyri-müəyyən müddətə";
            document.Add(new Paragraph($"2.1. İcarə müddəti {_contract.StartDate:dd.MM.yyyy} tarixindən başlayaraq {endDateText} qədər davam edir.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("3. İcarə haqqı və ödəniş şərtləri", boldFont));
            document.Add(new Paragraph($"3.1. Aylıq icarə haqqı {_contract.ContractAmount:N2} (yazı ilə: {NumberToWords((double)_contract.ContractAmount)}) Azərbaycan Manatı təşkil edir.", normalFont));
            document.Add(new Paragraph("3.2. İcarə haqqı hər ayın 5-dən gec olmayaraq ödənilməlidir.", normalFont));
            document.Add(new Paragraph("3.3. İcarəçi müqavilə imzalandığı gün ilkin ödəniş olaraq 1 (bir) aylıq icarə haqqını və təminat depoziti olaraq 1 (bir) aylıq icarə haqqını ödəyir.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("4. Tərəflərin hüquq və öhdəlikləri", boldFont));
            document.Add(new Paragraph("4.1. İcarəyə verən:", normalFont));
            document.Add(new Paragraph("    - Əmlakı istifadəyə yararlı vəziyyətdə İcarəçiyə təhvil verməlidir.", normalFont));
            document.Add(new Paragraph("    - İcarəçinin normal istifadəsinə mane olan problemləri aradan qaldırmalıdır.", normalFont));
            document.Add(new Paragraph("4.2. İcarəçi:", normalFont));
            document.Add(new Paragraph("    - İcarə haqqını vaxtında ödəməlidir.", normalFont));
            document.Add(new Paragraph("    - Əmlakdan təyinatı üzrə istifadə etməli və onu yaxşı vəziyyətdə saxlamalıdır.", normalFont));
            document.Add(new Paragraph("    - Əmlaka dəyən hər hansı zərəri öz hesabına aradan qaldırmalıdır.", normalFont));
            document.Add(new Paragraph("    - İcarəyə verənin yazılı razılığı olmadan Əmlakda heç bir əsaslı dəyişiklik etməməlidir.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("5. Müqavilənin ləğvi şərtləri", boldFont));
            document.Add(new Paragraph("5.1. Tərəflərdən hər hansı biri müqaviləni ləğv etmək istədikdə, digər tərəfə ən azı 1 (bir) ay əvvəl yazılı bildiriş verməlidir.", normalFont));
            document.Add(new Paragraph("5.2. İcarəçi icarə haqqını 15 gündən artıq gecikdirdikdə, İcarəyə verən müqaviləni birtərəfli qaydada ləğv edə bilər.", normalFont));
            document.Add(new Paragraph(" "));

            document.Add(new Paragraph("6. Yekun müddəalar", boldFont));
            document.Add(new Paragraph("6.1. Müqavilə Azərbaycan Respublikasının qanunvericiliyinə uyğun olaraq tənzimlənir.", normalFont));
            document.Add(new Paragraph("6.2. Tərəflər arasında yaranan bütün mübahisələr danışıqlar yolu ilə həll ediləcək. Razılıq əldə edilmədiyi təqdirdə, mübahisələr Azərbaycan Respublikasının qanunvericiliyinə uyğun olaraq məhkəmə qaydasında həll ediləcək.", normalFont));
            document.Add(new Paragraph("6.3. Bu müqavilə iki nüsxədə tərtib edilmişdir və hər iki nüsxə eyni hüquqi qüvvəyə malikdir.", normalFont));
        }

        private string NumberToWords(double number)
        {
            if (number == 0) return "sıfır";

            string words = "";

            // Split into integer and decimal parts
            int intPart = (int)number;
            int decimalPart = (int)((number - intPart) * 100);

            // Convert integer part
            if (intPart > 0)
            {
                words = IntegerToWords(intPart) + " manat";
            }

            // Add decimal part if not zero
            if (decimalPart > 0)
            {
                if (words.Length > 0) words += " ";
                words += IntegerToWords(decimalPart) + " qəpik";
            }

            return words;
        }

        private string IntegerToWords(int number)
        {
            if (number == 0) return "sıfır";

            string[] ones = { "", "bir", "iki", "üç", "dörd", "beş", "altı", "yeddi", "səkkiz", "doqquz" };
            string[] teens = { "on", "on bir", "on iki", "on üç", "on dörd", "on beş", "on altı", "on yeddi", "on səkkiz", "on doqquz" };
            string[] tens = { "", "on", "iyirmi", "otuz", "qırx", "əlli", "altmış", "yetmiş", "səksən", "doxsan" };

            string words = "";

            if (number >= 1000000000)
            {
                words += IntegerToWords(number / 1000000000) + " milyard ";
                number %= 1000000000;
            }

            if (number >= 1000000)
            {
                words += IntegerToWords(number / 1000000) + " milyon ";
                number %= 1000000;
            }

            if (number >= 1000)
            {
                words += IntegerToWords(number / 1000) + " min ";
                number %= 1000;
            }

            if (number >= 100)
            {
                words += ones[number / 100] + " yüz ";
                number %= 100;
            }

            if (number >= 20)
            {
                words += tens[number / 10] + " ";
                number %= 10;
            }
            else if (number >= 10)
            {
                words += teens[number - 10] + " ";
                number = 0;
            }

            if (number > 0)
            {
                words += ones[number] + " ";
            }

            return words.Trim();
        }
    }
}
