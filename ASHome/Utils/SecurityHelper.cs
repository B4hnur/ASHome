using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASHome.Utils
{
    /// <summary>
    /// Helper class for security operations
    /// </summary>
    public static class SecurityHelper
    {
        private static readonly string Salt = "ASH0ME$@LT"; // Salt for password hashing

        /// <summary>
        /// Hash a password with salt using SHA256
        /// </summary>
        /// <param name="password">Plain text password</param>
        /// <returns>Hashed password</returns>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty", nameof(password));
            }

            // Add salt to password
            string saltedPassword = string.Concat(password, Salt);

            // Create hash
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                // Convert byte array to hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Verify if a password matches a hashed password
        /// </summary>
        /// <param name="password">Plain text password</param>
        /// <param name="hashedPassword">Hashed password to compare against</param>
        /// <returns>True if password matches, false otherwise</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            {
                return false;
            }

            // Hash the input password
            string hashedInput = HashPassword(password);

            // Compare the hashes
            return string.Equals(hashedInput, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Generate a random password
        /// </summary>
        /// <param name="length">Length of password (default: 10)</param>
        /// <returns>Random password</returns>
        public static string GenerateRandomPassword(int length = 10)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_-+=";
            StringBuilder password = new StringBuilder();

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                for (int i = 0; i < length; i++)
                {
                    password.Append(validChars[randomBytes[i] % validChars.Length]);
                }
            }

            return password.ToString();
        }
    }
}
