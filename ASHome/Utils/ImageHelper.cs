using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASHome.Utils
{
    /// <summary>
    /// Helper class for image operations
    /// </summary>
    public static class ImageHelper
    {
        private static readonly string ImagesFolder = Path.Combine(Application.StartupPath, "Images");
        private static readonly string PropertyImagesFolder = Path.Combine(ImagesFolder, "Properties");

        /// <summary>
        /// Ensure directories exist
        /// </summary>
        static ImageHelper()
        {
            EnsureDirectoriesExist();
        }

        /// <summary>
        /// Ensure directories exist
        /// </summary>
        private static void EnsureDirectoriesExist()
        {
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }

            if (!Directory.Exists(PropertyImagesFolder))
            {
                Directory.CreateDirectory(PropertyImagesFolder);
            }
        }

        /// <summary>
        /// Save property image
        /// </summary>
        /// <param name="propertyId">Property ID</param>
        /// <param name="imagePath">Source image path</param>
        /// <returns>Saved image path</returns>
        public static string SavePropertyImage(int propertyId, string imagePath)
        {
            try
            {
                EnsureDirectoriesExist();

                // Create property folder if not exists
                string propertyFolder = Path.Combine(PropertyImagesFolder, propertyId.ToString());
                if (!Directory.Exists(propertyFolder))
                {
                    Directory.CreateDirectory(propertyFolder);
                }

                // Generate unique filename
                string fileName = $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{Guid.NewGuid().ToString().Substring(0, 8)}.jpg";
                string destPath = Path.Combine(propertyFolder, fileName);

                // Create thumbnail and save
                using (Image img = Image.FromFile(imagePath))
                {
                    using (Image thumbnail = CreateThumbnail(img, 1024, 768))
                    {
                        thumbnail.Save(destPath, ImageFormat.Jpeg);
                    }
                }

                return destPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şəkil saxlanarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Create thumbnail image
        /// </summary>
        /// <param name="image">Source image</param>
        /// <param name="maxWidth">Maximum width</param>
        /// <param name="maxHeight">Maximum height</param>
        /// <returns>Thumbnail image</returns>
        public static Image CreateThumbnail(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        /// <summary>
        /// Delete property image
        /// </summary>
        /// <param name="imagePath">Image path to delete</param>
        /// <returns>True if successful, false otherwise</returns>
        public static bool DeletePropertyImage(string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şəkil silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get default image path for properties
        /// </summary>
        /// <returns>Default image path</returns>
        public static string GetDefaultPropertyImagePath()
        {
            string defaultImagePath = Path.Combine(ImagesFolder, "default_property.jpg");

            // If default image doesn't exist, create one
            if (!File.Exists(defaultImagePath))
            {
                using (Bitmap bitmap = new Bitmap(800, 600))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        // Fill background
                        g.FillRectangle(Brushes.LightGray, 0, 0, 800, 600);

                        // Draw text
                        using (Font font = new Font("Arial", 20, FontStyle.Bold))
                        {
                            string text = "No Image Available";
                            SizeF textSize = g.MeasureString(text, font);
                            g.DrawString(text, font, Brushes.DarkGray,
                                (800 - textSize.Width) / 2,
                                (600 - textSize.Height) / 2);
                        }
                    }

                    bitmap.Save(defaultImagePath, ImageFormat.Jpeg);
                }
            }

            return defaultImagePath;
        }

        /// <summary>
        /// Get image from path with default fallback
        /// </summary>
        /// <param name="imagePath">Image path</param>
        /// <returns>Image from path or default image</returns>
        public static Image GetImage(string imagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    return Image.FromFile(imagePath);
                }

                return Image.FromFile(GetDefaultPropertyImagePath());
            }
            catch
            {
                return Image.FromFile(GetDefaultPropertyImagePath());
            }
        }

        /// <summary>
        /// Save multiple property images
        /// </summary>
        /// <param name="propertyId">Property ID</param>
        /// <param name="imagePaths">List of image paths</param>
        /// <returns>List of saved image paths</returns>
        public static List<string> SavePropertyImages(int propertyId, List<string> imagePaths)
        {
            var savedPaths = new List<string>();

            try
            {
                if (imagePaths == null || imagePaths.Count == 0)
                {
                    return savedPaths;
                }

                foreach (var imagePath in imagePaths)
                {
                    var savedPath = SavePropertyImage(propertyId, imagePath);
                    if (!string.IsNullOrEmpty(savedPath))
                    {
                        savedPaths.Add(savedPath);
                    }
                }

                return savedPaths;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şəkilləri saxlanarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return savedPaths;
            }
        }
    }
}