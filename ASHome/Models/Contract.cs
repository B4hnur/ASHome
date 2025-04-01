using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHome.Models
{
    /// <summary>
    /// Contract model class
    /// </summary>
    public class Contract
    {
        /// <summary>
        /// Contract ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Contract number
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        /// Property ID
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Property (for display only)
        /// </summary>
        public Property Property { get; set; }

        /// <summary>
        /// Property title (for display only)
        /// </summary>
        public string PropertyTitle { get; set; }

        /// <summary>
        /// Customer ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Customer name (for display only)
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Customer (for display only)
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Employee ID
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Employee name (for display only)
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Contract type (Sale, Rent, etc.)
        /// </summary>
        public string ContractType { get; set; }

        /// <summary>
        /// Contract amount
        /// </summary>
        public decimal ContractAmount { get; set; }

        /// <summary>
        /// Start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date (null for sale contracts)
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Sign date
        /// </summary>
        public DateTime SignDate { get; set; }

        /// <summary>
        /// Status (Active, Completed, Cancelled, etc.)
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

        /// <summary>
        /// Down payments for this contract
        /// </summary>
        public List<DownPayment> DownPayments { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Contract()
        {
            DownPayments = new List<DownPayment>();
        }
    }
}