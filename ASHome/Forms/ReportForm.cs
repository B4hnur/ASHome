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
    public partial class ReportForm : Form
    {
        private readonly User _currentUser;
        private List<Property> _properties;
        private List<Contract> _contracts;
        private List<Employee> _employees;
        private List<Customer> _customers;
        private List<DownPayment> _downPayments;
        private List<Expense> _expenses;

        public ReportForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // Set initial dates
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEndDate.Value = DateTime.Now;

            // Load data from database
            LoadAllData();

            // Setup the UI
            SetupCharts();
            SetupSummary();
        }

        private void LoadAllData()
        {
            try
            {
                _properties = DatabaseManager.Instance.GetAllProperties();
                _contracts = DatabaseManager.Instance.GetAllContracts();
                _employees = DatabaseManager.Instance.GetAllEmployees();
                _customers = DatabaseManager.Instance.GetAllCustomers();
                _downPayments = DatabaseManager.Instance.GetAllDownPayments();
                _expenses = DatabaseManager.Instance.GetAllExpenses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məlumatlar yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupCharts()
        {
            // Clear charts
            chartRevenue.Series[0].Points.Clear();
            chartExpenses.Series[0].Points.Clear();
            chartContracts.Series[0].Points.Clear();
            chartPropertyTypes.Series[0].Points.Clear();

            // Setup Revenue Chart
            if (_downPayments != null && _downPayments.Count > 0)
            {
                var filteredPayments = FilterByDateRange(_downPayments);
                var paymentsGroupedByMonth = filteredPayments
                    .GroupBy(p => new { p.PaymentDate.Year, p.PaymentDate.Month })
                    .Select(g => new
                    {
                        Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                        Total = g.Sum(p => p.Amount)
                    })
                    .OrderBy(x => x.Date)
                    .ToList();

                foreach (var item in paymentsGroupedByMonth)
                {
                    chartRevenue.Series[0].Points.AddXY(item.Date.ToString("MMM yyyy"), (double)item.Total);
                }
            }

            // Setup Expenses Chart
            if (_expenses != null && _expenses.Count > 0)
            {
                var filteredExpenses = FilterByDateRange(_expenses);
                var expensesGroupedByMonth = filteredExpenses
                    .GroupBy(e => new { e.ExpenseDate.Year, e.ExpenseDate.Month })
                    .Select(g => new
                    {
                        Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                        Total = g.Sum(e => e.Amount)
                    })
                    .OrderBy(x => x.Date)
                    .ToList();

                foreach (var item in expensesGroupedByMonth)
                {
                    chartExpenses.Series[0].Points.AddXY(item.Date.ToString("MMM yyyy"), (double)item.Total);
                }
            }

            // Setup Contracts Chart
            if (_contracts != null && _contracts.Count > 0)
            {
                var filteredContracts = FilterByDateRange(_contracts);
                var contractsGroupedByType = filteredContracts
                    .GroupBy(c => c.ContractType)
                    .Select(g => new
                    {
                        Type = g.Key,
                        Count = g.Count()
                    })
                    .OrderByDescending(x => x.Count)
                    .ToList();

                foreach (var item in contractsGroupedByType)
                {
                    chartContracts.Series[0].Points.AddXY(item.Type, item.Count);
                }
            }

            // Setup Property Types Chart
            if (_properties != null && _properties.Count > 0)
            {
                var propertiesGroupedByType = _properties
                    .GroupBy(p => p.Type)
                    .Select(g => new
                    {
                        Type = g.Key,
                        Count = g.Count()
                    })
                    .OrderByDescending(x => x.Count)
                    .ToList();

                foreach (var item in propertiesGroupedByType)
                {
                    chartPropertyTypes.Series[0].Points.AddXY(item.Type, item.Count);
                }
            }
        }

        private void SetupSummary()
        {
            // Calculate financial summary
            decimal totalRevenue = _downPayments != null ? FilterByDateRange(_downPayments).Sum(p => p.Amount) : 0;
            decimal totalExpenses = _expenses != null ? FilterByDateRange(_expenses).Sum(e => e.Amount) : 0;
            decimal netProfit = totalRevenue - totalExpenses;

            lblTotalRevenue.Text = $"{totalRevenue:N2} AZN";
            lblTotalExpenses.Text = $"{totalExpenses:N2} AZN";
            lblNetProfit.Text = $"{netProfit:N2} AZN";

            // Property statistics
            int totalProperties = _properties != null ? _properties.Count : 0;
            int availableProperties = _properties != null ? _properties.Count(p => p.Status == "Satılır" || p.Status == "Kirayə verilir") : 0;
            int soldProperties = _properties != null ? _properties.Count(p => p.Status == "Satılıb") : 0;
            int rentedProperties = _properties != null ? _properties.Count(p => p.Status == "Kirayə verilib") : 0;

            lblTotalProperties.Text = totalProperties.ToString();
            lblAvailableProperties.Text = availableProperties.ToString();
            lblSoldProperties.Text = soldProperties.ToString();
            lblRentedProperties.Text = rentedProperties.ToString();

            // Customer and contract metrics
            int totalCustomers = _customers != null ? _customers.Count : 0;
            int newCustomers = _customers != null ? FilterByDateRange(_customers).Count : 0;
            int totalContracts = _contracts != null ? _contracts.Count : 0;
            int newContracts = _contracts != null ? FilterByDateRange(_contracts).Count : 0;

            lblTotalCustomers.Text = totalCustomers.ToString();
            lblNewCustomers.Text = newCustomers.ToString();
            lblTotalContracts.Text = totalContracts.ToString();
            lblNewContracts.Text = newContracts.ToString();

            // Calculate top performers
            PopulateTopPerformersGrid();

            // Set report period
            lblReportPeriod.Text = $"Hesabat dövrü: {dtpStartDate.Value:dd.MM.yyyy} - {dtpEndDate.Value:dd.MM.yyyy}";
        }

        private void PopulateTopPerformersGrid()
        {
            if (_contracts != null && _contracts.Count > 0 && _employees != null && _employees.Count > 0)
            {
                var filteredContracts = FilterByDateRange(_contracts);

                var topPerformers = filteredContracts
                    .GroupBy(c => c.EmployeeId)
                    .Select(g => new
                    {
                        EmployeeId = g.Key,
                        EmployeeName = g.First().EmployeeName,
                        ContractsCount = g.Count(),
                        TotalAmount = g.Sum(c => c.ContractAmount)
                    })
                    .OrderByDescending(x => x.TotalAmount)
                    .Take(5)
                    .ToList();

                dgvTopPerformers.Rows.Clear();

                foreach (var performer in topPerformers)
                {
                    dgvTopPerformers.Rows.Add(
                        performer.EmployeeName,
                        performer.ContractsCount,
                        performer.TotalAmount.ToString("N2")
                    );
                }
            }
        }

        private List<T> FilterByDateRange<T>(List<T> items) where T : class
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1);

            if (typeof(T) == typeof(Contract))
            {
                return items
                    .Cast<Contract>()
                    .Where(c => c.SignDate >= startDate && c.SignDate <= endDate)
                    .Cast<T>()
                    .ToList();
            }
            else if (typeof(T) == typeof(DownPayment))
            {
                return items
                    .Cast<DownPayment>()
                    .Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate)
                    .Cast<T>()
                    .ToList();
            }
            else if (typeof(T) == typeof(Expense))
            {
                return items
                    .Cast<Expense>()
                    .Where(e => e.ExpenseDate >= startDate && e.ExpenseDate <= endDate)
                    .Cast<T>()
                    .ToList();
            }
            else if (typeof(T) == typeof(Customer))
            {
                return items
                    .Cast<Customer>()
                    .Where(c => c.CreatedAt >= startDate && c.CreatedAt <= endDate)
                    .Cast<T>()
                    .ToList();
            }

            return items;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            LoadAllData();
            SetupCharts();
            SetupSummary();
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF Faylı (*.pdf)|*.pdf";
                saveDialog.Title = "Hesabatı PDF kimi saxla";
                saveDialog.FileName = $"ASHome_Hesabat_{DateTime.Now:yyyyMMdd}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // First we need to save charts as images
                    string tempPath = Path.Combine(Path.GetTempPath(), "ASHome_Charts");
                    if (!Directory.Exists(tempPath))
                    {
                        Directory.CreateDirectory(tempPath);
                    }

                    string revenueChartPath = Path.Combine(tempPath, "revenue_chart.png");
                    string expensesChartPath = Path.Combine(tempPath, "expenses_chart.png");
                    string contractsChartPath = Path.Combine(tempPath, "contracts_chart.png");
                    string propertyTypesChartPath = Path.Combine(tempPath, "property_types_chart.png");

                    chartRevenue.SaveImage(revenueChartPath, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                    chartExpenses.SaveImage(expensesChartPath, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                    chartContracts.SaveImage(contractsChartPath, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                    chartPropertyTypes.SaveImage(propertyTypesChartPath, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);

                    // Create dictionaries for summary data and chart paths
                    Dictionary<string, string> summaryData = new Dictionary<string, string>
                    {
                        { "Ümumi gəlir", lblTotalRevenue.Text },
                        { "Ümumi xərclər", lblTotalExpenses.Text },
                        { "Xalis mənfəət", lblNetProfit.Text },
                        { "Ümumi əmlak", lblTotalProperties.Text },
                        { "Mövcud əmlak", lblAvailableProperties.Text },
                        { "Satılan əmlak", lblSoldProperties.Text },
                        { "Kirayə verilən əmlak", lblRentedProperties.Text },
                        { "Ümumi müştərilər", lblTotalCustomers.Text },
                        { "Yeni müştərilər", lblNewCustomers.Text },
                        { "Ümumi müqavilələr", lblTotalContracts.Text },
                        { "Yeni müqavilələr", lblNewContracts.Text }
                    };

                    Dictionary<string, string> chartPaths = new Dictionary<string, string>
                    {
                        { "Gəlir qrafiki", revenueChartPath },
                        { "Xərc qrafiki", expensesChartPath },
                        { "Müqavilə qrafiki", contractsChartPath },
                        { "Əmlak növləri qrafiki", propertyTypesChartPath }
                    };

                    // Generate PDF report
                    bool success = ExportHelper.ExportReportToPdf(
                        saveDialog.FileName,
                        lblReportPeriod.Text,
                        summaryData,
                        chartPaths,
                        dgvTopPerformers
                    );

                    if (success)
                    {
                        MessageBox.Show("Hesabat uğurla PDF olaraq saxlanıldı", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Clean up temp files
                    try
                    {
                        File.Delete(revenueChartPath);
                        File.Delete(expensesChartPath);
                        File.Delete(contractsChartPath);
                        File.Delete(propertyTypesChartPath);
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hesabat ixrac edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
