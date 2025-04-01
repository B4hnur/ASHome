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

namespace ASHome.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly User _currentUser;
        private List<Property> _properties;
        private List<Contract> _contracts;
        private List<Employee> _employees;
        private List<Customer> _customers;
        private List<DownPayment> _payments;
        private List<Expense> _expenses;

        public DashboardForm(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Xoş gəlmisiniz, {_currentUser.FullName}!";
            LoadData();
            SetupDashboard();
        }

        private void LoadData()
        {
            try
            {
                // Load data from database
                _properties = DatabaseManager.Instance.GetAllProperties();
                _contracts = DatabaseManager.Instance.GetAllContracts();
                _employees = DatabaseManager.Instance.GetAllEmployees();
                _customers = DatabaseManager.Instance.GetAllCustomers();
                _payments = DatabaseManager.Instance.GetAllDownPayments();
                _expenses = DatabaseManager.Instance.GetAllExpenses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məlumatlar yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDashboard()
        {
            // Set summary stats
            SetSummaryStats();

            // Set recent activities
            LoadRecentActivities();

            // Set charts
            SetupPropertyStatusChart();
            SetupMonthlyRevenueChart();
        }

        private void SetSummaryStats()
        {
            // Properties
            lblTotalProperties.Text = _properties?.Count.ToString() ?? "0";

            int availableProperties = _properties?.Count(p => p.Status == "Satılır" || p.Status == "Kirayə verilir") ?? 0;
            lblAvailableProperties.Text = availableProperties.ToString();

            // Contracts
            lblTotalContracts.Text = _contracts?.Count.ToString() ?? "0";

            // Get contracts from last 30 days
            DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);
            int recentContracts = _contracts?.Count(c => c.SignDate >= thirtyDaysAgo) ?? 0;
            lblRecentContracts.Text = recentContracts.ToString();

            // Customers
            lblTotalCustomers.Text = _customers?.Count.ToString() ?? "0";

            // Get customers from last 30 days
            int recentCustomers = _customers?.Count(c => c.CreatedAt >= thirtyDaysAgo) ?? 0;
            lblNewCustomers.Text = recentCustomers.ToString();

            // Financial
            decimal totalRevenue = _payments?.Sum(p => p.Amount) ?? 0;
            decimal monthlyRevenue = _payments?.Where(p => p.PaymentDate.Month == DateTime.Now.Month &&
                                                         p.PaymentDate.Year == DateTime.Now.Year)
                                                .Sum(p => p.Amount) ?? 0;

            decimal totalExpenses = _expenses?.Sum(e => e.Amount) ?? 0;
            decimal monthlyExpenses = _expenses?.Where(e => e.ExpenseDate.Month == DateTime.Now.Month &&
                                                          e.ExpenseDate.Year == DateTime.Now.Year)
                                                 .Sum(e => e.Amount) ?? 0;

            lblTotalRevenue.Text = $"{totalRevenue:N2} AZN";
            lblMonthlyRevenue.Text = $"{monthlyRevenue:N2} AZN";
            lblTotalExpenses.Text = $"{totalExpenses:N2} AZN";
            lblMonthlyExpenses.Text = $"{monthlyExpenses:N2} AZN";

            // Profit
            decimal totalProfit = totalRevenue - totalExpenses;
            decimal monthlyProfit = monthlyRevenue - monthlyExpenses;

            lblTotalProfit.Text = $"{totalProfit:N2} AZN";
            lblMonthlyProfit.Text = $"{monthlyProfit:N2} AZN";
        }

        private void LoadRecentActivities()
        {
            listRecentActivities.Items.Clear();

            // Combine recent contracts, customers, and payments
            var activities = new List<RecentActivity>();

            // Add contracts
            if (_contracts != null)
            {
                foreach (var contract in _contracts.OrderByDescending(c => c.SignDate).Take(10))
                {
                    activities.Add(new RecentActivity
                    {
                        Date = contract.SignDate,
                        Description = $"Müqavilə {contract.ContractNumber} - {contract.CustomerName} ilə imzalandı",
                        Amount = contract.ContractAmount,
                        Type = "Müqavilə"
                    });
                }
            }

            // Add customers
            if (_customers != null)
            {
                foreach (var customer in _customers.OrderByDescending(c => c.CreatedAt).Take(10))
                {
                    activities.Add(new RecentActivity
                    {
                        Date = customer.CreatedAt,
                        Description = $"Yeni müştəri: {customer.FullName}",
                        Amount = null,
                        Type = "Müştəri"
                    });
                }
            }

            // Add payments
            if (_payments != null)
            {
                foreach (var payment in _payments.OrderByDescending(p => p.PaymentDate).Take(10))
                {
                    activities.Add(new RecentActivity
                    {
                        Date = payment.PaymentDate,
                        Description = $"Ödəniş {payment.PaymentNumber} - {payment.CustomerName}",
                        Amount = payment.Amount,
                        Type = "Ödəniş"
                    });
                }
            }

            // Sort activities by date
            var sortedActivities = activities.OrderByDescending(a => a.Date).Take(20).ToList();

            // Add to list
            foreach (var activity in sortedActivities)
            {
                string displayText = $"{activity.Date:dd.MM.yyyy} - {activity.Description}";
                if (activity.Amount.HasValue)
                {
                    displayText += $" ({activity.Amount.Value:N2} AZN)";
                }

                ListViewItem item = new ListViewItem(displayText);

                // Set item color based on type
                switch (activity.Type)
                {
                    case "Müqavilə":
                        item.ForeColor = Color.DarkBlue;
                        break;
                    case "Müştəri":
                        item.ForeColor = Color.DarkGreen;
                        break;
                    case "Ödəniş":
                        item.ForeColor = Color.DarkRed;
                        break;
                }

                listRecentActivities.Items.Add(item);
            }
        }

        private void SetupPropertyStatusChart()
        {
            if (_properties != null && _properties.Count > 0)
            {
                // Clear existing data
                chartPropertyStatus.Series[0].Points.Clear();

                // Group properties by status
                var groupedByStatus = _properties.GroupBy(p => p.Status)
                    .Select(g => new { Status = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToList();

                // Add data points to chart
                foreach (var item in groupedByStatus)
                {
                    chartPropertyStatus.Series[0].Points.AddXY(item.Status, item.Count);
                }
            }
        }

        private void SetupMonthlyRevenueChart()
        {
            if (_payments != null && _payments.Count > 0)
            {
                // Clear existing data
                chartRevenue.Series[0].Points.Clear();
                chartRevenue.Series[1].Points.Clear();

                // Get last 6 months
                DateTime startDate = DateTime.Now.AddMonths(-5).Date;
                startDate = new DateTime(startDate.Year, startDate.Month, 1);

                // Group payments by month
                var monthlyRevenue = _payments
                    .Where(p => p.PaymentDate >= startDate)
                    .GroupBy(p => new { p.PaymentDate.Year, p.PaymentDate.Month })
                    .Select(g => new
                    {
                        Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                        TotalAmount = g.Sum(p => p.Amount)
                    })
                    .OrderBy(x => x.Month)
                    .ToList();

                // Group expenses by month
                var monthlyExpenses = new List<dynamic>();
                if (_expenses != null && _expenses.Count > 0)
                {
                    monthlyExpenses = _expenses
                        .Where(e => e.ExpenseDate >= startDate)
                        .GroupBy(e => new { e.ExpenseDate.Year, e.ExpenseDate.Month })
                        .Select(g => new
                        {
                            Month = new DateTime(g.Key.Year, g.Key.Month, 1),
                            TotalAmount = g.Sum(e => e.Amount)
                        })
                        .OrderBy(x => x.Month)
                        .ToList<dynamic>();
                }

                // Create a range of months
                var months = new List<DateTime>();
                var currentMonth = startDate;
                while (currentMonth <= DateTime.Now.Date)
                {
                    months.Add(currentMonth);
                    currentMonth = currentMonth.AddMonths(1);
                }

                // Add data points to chart
                foreach (var month in months)
                {
                    var revenue = monthlyRevenue.FirstOrDefault(m => m.Month.Year == month.Year && m.Month.Month == month.Month);

                    // Find matching expense for the month - need to use dynamic approach due to type differences
                    dynamic matchingExpense = null;
                    foreach (var expense in monthlyExpenses)
                    {
                        dynamic expenseItem = expense;
                        if (expenseItem.Month.Year == month.Year && expenseItem.Month.Month == month.Month)
                        {
                            matchingExpense = expenseItem;
                            break;
                        }
                    }

                    decimal revenueAmount = revenue?.TotalAmount ?? 0;
                    decimal expensesAmount = 0;

                    if (matchingExpense != null)
                    {
                        expensesAmount = matchingExpense.TotalAmount;
                    }

                    chartRevenue.Series[0].Points.AddXY(month.ToString("MMM yy"), (double)revenueAmount);
                    chartRevenue.Series[1].Points.AddXY(month.ToString("MMM yy"), (double)expensesAmount);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            SetupDashboard();
        }

        private class RecentActivity
        {
            public DateTime Date { get; set; }
            public string Description { get; set; }
            public decimal? Amount { get; set; }
            public string Type { get; set; }
        }
    }
}
