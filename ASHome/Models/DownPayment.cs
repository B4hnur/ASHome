using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHome.Models
{
    /// <summary>
    /// Down payment model class for contract payments
    /// </summary>
    public class DownPayment
    {
        /// <summary>
        /// Payment ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Contract ID
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// Contract number (for display only)
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        /// Customer ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Property ID
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Customer name (for display only)
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Payment amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Payment date
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Payment method (Cash, Bank Transfer, etc.)
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Payment type (Initial, Deposit, Final, etc.)
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// Payment number (check number, transaction ID, etc.)
        /// </summary>
        public string PaymentNumber { get; set; }

        /// <summary>
        /// Payment status (Paid, Pending, etc.)
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