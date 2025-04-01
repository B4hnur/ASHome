using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHome.Models
{
    /// <summary>
    /// Property image model class
    /// </summary>
    public class PropertyImage
    {
        /// <summary>
        /// Image ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Property ID
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// Image file path
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Is main image
        /// </summary>
        public bool IsMain { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}