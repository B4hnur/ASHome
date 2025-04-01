using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHome.Models
{
    /// <summary>
    /// Company information model class
    /// </summary>
    public class CompanyInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Company name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Website URL
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Tax ID
        /// </summary>
        public string TaxId { get; set; }

        /// <summary>
        /// Path to logo file
        /// </summary>
        public string LogoPath { get; set; }

        /// <summary>
        /// Contract terms and conditions for use in contract printing
        /// </summary>
        public string ContractTerms { get; set; }

        /// <summary>
        /// Bank details
        /// </summary>
        public string BankDetails { get; set; }

        /// <summary>
        /// Last updated date
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}