using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHome.Models
{
    /// <summary>
    /// User model class for system users
    /// </summary>
    public class User
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username for login
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password in plain text (used only for adding/updating)
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Full name of user
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Is user admin
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Is user active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Last login date
        /// </summary>
        public DateTime? LastLogin { get; set; }

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