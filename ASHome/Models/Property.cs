using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASHome.Models
{
    /// <summary>
    /// Property model class for real estate properties
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Property ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Listing code
        /// </summary>
        public string ListingCode { get; set; }

        /// <summary>
        /// Property type (Apartment, House, Land, etc.)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Property title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Property description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Property address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Property area in square meters
        /// </summary>
        public decimal Area { get; set; }

        /// <summary>
        /// Property price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Number of rooms
        /// </summary>
        public int? Rooms { get; set; }

        /// <summary>
        /// Room count (alias for Rooms)
        /// </summary>
        public int? RoomCount => Rooms;

        /// <summary>
        /// Number of bathrooms
        /// </summary>
        public int? Bathrooms { get; set; }

        /// <summary>
        /// Floor number
        /// </summary>
        public int? Floor { get; set; }

        /// <summary>
        /// Total floors in building
        /// </summary>
        public int? TotalFloors { get; set; }

        /// <summary>
        /// Year built
        /// </summary>
        public int? BuiltYear { get; set; }

        /// <summary>
        /// Property status (Available, Sold, Rented, etc.)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Employee ID responsible for this property
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Employee name (for display only)
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Source URL (if imported from website)
        /// </summary>
        public string SourceUrl { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Updated date
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Property images
        /// </summary>
        public List<PropertyImage> Images { get; set; }

        /// <summary>
        /// Main image path (for display only)
        /// </summary>
        public string MainImagePath { get; set; }

        /// <summary>
        /// Number of images (for display only)
        /// </summary>
        public int ImageCount => Images?.Count ?? 0;

        /// <summary>
        /// Constructor
        /// </summary>
        public Property()
        {
            Images = new List<PropertyImage>();
        }
    }
}