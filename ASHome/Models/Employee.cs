using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHome.Models
{
    /// <summary>
    /// Employee model class
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Employee ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User ID (if employee has login credentials)
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Salary
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// Hire date
        /// </summary>
        public DateTime HireDate { get; set; }

        /// <summary>
        /// Join date
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// Status (Active, Inactive, etc.)
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