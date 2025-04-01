using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHome.Models
{
    /// <summary>
    /// Expense model class
    /// </summary>
    public class Expense
    {
        /// <summary>
        /// Expense ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Expense date
        /// </summary>
        public DateTime ExpenseDate { get; set; }

        /// <summary>
        /// Employee ID
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Employee name (for display only)
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Property ID
        /// </summary>
        public int? PropertyId { get; set; }

        /// <summary>
        /// Property title (for display only)
        /// </summary>
        public string PropertyTitle { get; set; }

        /// <summary>
        /// Status (Paid, Pending, etc.)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Note
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Updated date
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}