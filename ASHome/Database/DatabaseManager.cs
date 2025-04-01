using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASHome.Models;
using ASHome.Utils;

namespace ASHome.Database
{
    /// <summary>
    /// Database manager class for SQLite operations
    /// </summary>
    public class DatabaseManager
    {
        private static readonly string DbFileName = "ashome.db";
        private static readonly string AppFolder = "ASHome";
        private static readonly string DbFolderPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            AppFolder);
        private static readonly string DbPath = Path.Combine(DbFolderPath, DbFileName);
        private static string _connectionString = $"Data Source=\"{DbPath}\";Version=3;";

        // Singleton instance
        private static DatabaseManager _instance;

        // Property to access connection string
        private static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        // Lock object for thread-safety
        private static readonly object _lock = new object();

        /// <summary>
        /// Get singleton instance
        /// </summary>
        public static DatabaseManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DatabaseManager();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private DatabaseManager()
        {
            // Initialize database
            InitializeDatabase();
        }

        /// <summary>
        /// Constructor with connection string
        /// </summary>
        /// <param name="connectionString">Custom connection string</param>
        public DatabaseManager(string connectionString)
        {
            // Set connection string
            ConnectionString = connectionString;

            // Initialize database
            InitializeDatabase();
        }

        /// <summary>
        /// Initialize database, create tables if not exist
        /// </summary>
        public void InitializeDatabase()
        {
            try
            {
                // Create database directory if it doesn't exist
                if (!Directory.Exists(DbFolderPath))
                {
                    Directory.CreateDirectory(DbFolderPath);
                }

                // Check if database file exists
                if (!File.Exists(DbPath))
                {
                    // Create database file
                    SQLiteConnection.CreateFile(DbPath);
                }

                // Create tables
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Create Users table
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Users (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Username TEXT NOT NULL UNIQUE,
                                PasswordHash TEXT NOT NULL,
                                FullName TEXT NOT NULL,
                                Email TEXT,
                                IsAdmin INTEGER NOT NULL DEFAULT 0,
                                IsActive INTEGER NOT NULL DEFAULT 1,
                                LastLogin TEXT,
                                CreatedAt TEXT NOT NULL,
                                UpdatedAt TEXT NOT NULL
                            );
                        ";
                        command.ExecuteNonQuery();
                    }

                    // Create Properties table
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Properties (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                ListingCode TEXT NOT NULL,
                                Type TEXT NOT NULL,
                                Title TEXT NOT NULL,
                                Description TEXT,
                                Address TEXT NOT NULL,
                                City TEXT NOT NULL,
                                Area REAL NOT NULL,
                                Price REAL NOT NULL,
                                Rooms INTEGER,
                                Bathrooms INTEGER,
                                Floor INTEGER,
                                TotalFloors INTEGER,
                                BuiltYear INTEGER,
                                Status TEXT NOT NULL,
                                EmployeeId INTEGER,
                                SourceUrl TEXT,
                                CreatedAt TEXT NOT NULL,
                                UpdatedAt TEXT NOT NULL,
                                FOREIGN KEY(EmployeeId) REFERENCES Employees(Id)
                            );
                        ";
                        command.ExecuteNonQuery();
                    }

                    // Create PropertyImages table
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS PropertyImages (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                PropertyId INTEGER NOT NULL,
                                ImagePath TEXT NOT NULL,
                                IsMain INTEGER NOT NULL DEFAULT 0,
                                CreatedAt TEXT NOT NULL,
                                FOREIGN KEY(PropertyId) REFERENCES Properties(Id)
                            );
                        ";
                        command.ExecuteNonQuery();
                    }

                    // Create Employees table
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Employees (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                FullName TEXT NOT NULL,
                                PhoneNumber TEXT NOT NULL,
                                Email TEXT,
                                Position TEXT NOT NULL,
                                Salary REAL NOT NULL,
                                JoinDate TEXT NOT NULL,
                                Status TEXT NOT NULL,
                                Note TEXT,
                                CreatedAt TEXT NOT NULL,
                                UpdatedAt TEXT NOT NULL
                            );
                        ";
                        command.ExecuteNonQuery();
                    }

                    // Create Customers table
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Customers (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                FullName TEXT NOT NULL,
                                PhoneNumber TEXT NOT NULL,
                                Email TEXT,
                                IdNumber TEXT,
                                Address TEXT,
                                Note TEXT,
                                CreatedAt TEXT NOT NULL,
                                UpdatedAt TEXT NOT NULL
                            );
                        ";
                        command.ExecuteNonQuery();
                    }

                    // Create Contracts table
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Contracts (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                ContractNumber TEXT NOT NULL,
                                PropertyId INTEGER NOT NULL,
                                CustomerId INTEGER NOT NULL,
                                EmployeeId INTEGER NOT NULL,
                                ContractType TEXT NOT NULL,
                                ContractAmount REAL NOT NULL,
                                StartDate TEXT NOT NULL,
                                EndDate TEXT,
                                SignDate TEXT NOT NULL,
                                Status TEXT NOT NULL,
                                Note TEXT,
                                CreatedAt TEXT NOT NULL,
                                UpdatedAt TEXT NOT NULL,
                                FOREIGN KEY(PropertyId) REFERENCES Properties(Id),
                                FOREIGN KEY(CustomerId) REFERENCES Customers(Id),
                                FOREIGN KEY(EmployeeId) REFERENCES Employees(Id)
                            );
                        ";
                        command.ExecuteNonQuery();
                    }

                    // Create DownPayments table
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS DownPayments (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                ContractId INTEGER NOT NULL,
                                Amount REAL NOT NULL,
                                PaymentDate TEXT NOT NULL,
                                PaymentMethod TEXT NOT NULL,
                                Note TEXT,
                                CreatedAt TEXT NOT NULL,
                                FOREIGN KEY(ContractId) REFERENCES Contracts(Id)
                            );
                        ";
                        command.ExecuteNonQuery();
                    }

                    // Create Expenses table
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            CREATE TABLE IF NOT EXISTS Expenses (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Category TEXT NOT NULL,
                                Description TEXT NOT NULL,
                                Amount REAL NOT NULL,
                                ExpenseDate TEXT NOT NULL,
                                EmployeeId INTEGER,
                                PropertyId INTEGER,
                                Status TEXT NOT NULL,
                                Note TEXT,
                                CreatedAt TEXT NOT NULL,
                                UpdatedAt TEXT NOT NULL,
                                FOREIGN KEY(EmployeeId) REFERENCES Employees(Id),
                                FOREIGN KEY(PropertyId) REFERENCES Properties(Id)
                            );
                        ";
                        command.ExecuteNonQuery();
                    }

                    // Create default admin user if none exists
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT COUNT(*) FROM Users;";
                        long userCount = (long)command.ExecuteScalar();

                        if (userCount == 0)
                        {
                            string passwordHash = SecurityHelper.HashPassword("admin123");
                            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            command.CommandText = @"
                                INSERT INTO Users (Username, PasswordHash, FullName, Email, IsAdmin, IsActive, CreatedAt, UpdatedAt)
                                VALUES (@Username, @PasswordHash, @FullName, @Email, @IsAdmin, @IsActive, @CreatedAt, @UpdatedAt);
                            ";

                            command.Parameters.AddWithValue("@Username", "admin");
                            command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                            command.Parameters.AddWithValue("@FullName", "System Administrator");
                            command.Parameters.AddWithValue("@Email", "admin@ashome.az");
                            command.Parameters.AddWithValue("@IsAdmin", 1);
                            command.Parameters.AddWithValue("@IsActive", 1);
                            command.Parameters.AddWithValue("@CreatedAt", now);
                            command.Parameters.AddWithValue("@UpdatedAt", now);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Verilənlər bazası yaradılarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Create a backup of the database
        /// </summary>
        /// <param name="backupName">Optional backup name</param>
        /// <returns>Path to the backup file or null on failure</returns>
        public string CreateBackup(string backupName = null)
        {
            return DatabaseBackupHelper.CreateBackup(backupName);
        }

        /// <summary>
        /// Restore a database backup
        /// </summary>
        /// <param name="backupPath">Path to the backup file</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool RestoreBackup(string backupPath)
        {
            return DatabaseBackupHelper.RestoreBackup(backupPath);
        }

        #region User Methods

        /// <summary>
        /// Verify user password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password to verify</param>
        /// <returns>True if password is valid</returns>
        public bool VerifyUserPassword(string username, string password)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT PasswordHash FROM Users WHERE Username = @Username;";
                        command.Parameters.AddWithValue("@Username", username);

                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            string storedHash = result.ToString();
                            return SecurityHelper.VerifyPassword(password, storedHash);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şifrə yoxlanarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Verify user password with user ID
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="password">Password to verify</param>
        /// <returns>True if password is valid</returns>
        public bool VerifyUserPassword(int userId, string password)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT PasswordHash FROM Users WHERE Id = @UserId;";
                        command.Parameters.AddWithValue("@UserId", userId);

                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            string storedHash = result.ToString();
                            return SecurityHelper.VerifyPassword(password, storedHash);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şifrə yoxlanarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>User if authenticated, null otherwise</returns>
        public User AuthenticateUser(string username, string password)
        {
            User user = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT * FROM Users WHERE Username = @Username AND IsActive = 1;";
                        command.Parameters.AddWithValue("@Username", username);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["PasswordHash"].ToString();

                                if (SecurityHelper.VerifyPassword(password, storedHash))
                                {
                                    user = new User
                                    {
                                        Id = Convert.ToInt32(reader["Id"]),
                                        Username = reader["Username"].ToString(),
                                        FullName = reader["FullName"].ToString(),
                                        Email = reader["Email"].ToString(),
                                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
                                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                                        LastLogin = reader["LastLogin"] != DBNull.Value ? Convert.ToDateTime(reader["LastLogin"]) : (DateTime?)null,
                                        CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                        UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                    };

                                    // Update last login
                                    UpdateUserLastLogin(user.Id);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstifadəçi doğrulanarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return user;
        }

        /// <summary>
        /// Update user's last login
        /// </summary>
        /// <param name="userId">User ID</param>
        private void UpdateUserLastLogin(int userId)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "UPDATE Users SET LastLogin = @LastLogin WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@LastLogin", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@Id", userId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating last login: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of users</returns>
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT * FROM Users ORDER BY FullName;";

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Username = reader["Username"].ToString(),
                                    FullName = reader["FullName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                                    LastLogin = reader["LastLogin"] != DBNull.Value ? Convert.ToDateTime(reader["LastLogin"]) : (DateTime?)null,
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstifadəçilər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return users;
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User if found, null otherwise</returns>
        public User GetUserById(int id)
        {
            User user = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT * FROM Users WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@Id", id);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Username = reader["Username"].ToString(),
                                    FullName = reader["FullName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
                                    IsActive = Convert.ToBoolean(reader["IsActive"]),
                                    LastLogin = reader["LastLogin"] != DBNull.Value ? Convert.ToDateTime(reader["LastLogin"]) : (DateTime?)null,
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstifadəçi yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return user;
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user">User to add</param>
        /// <returns>ID of the new user if successful, 0 otherwise</returns>
        /// <summary>
        /// Add new user with specified username, password and isAdmin flag
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="isAdmin">Whether user is admin</param>
        /// <returns>ID of the new user if successful, 0 otherwise</returns>
        public int AddUser(string username, string password, bool isAdmin)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                FullName = username,
                IsAdmin = isAdmin,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return AddUser(user);
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user">User to add</param>
        /// <returns>ID of the new user if successful, 0 otherwise</returns>
        public int AddUser(User user)
        {
            int newId = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Check if username exists
                    using (SQLiteCommand checkCommand = new SQLiteCommand(connection))
                    {
                        checkCommand.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @Username;";
                        checkCommand.Parameters.AddWithValue("@Username", user.Username);

                        long count = (long)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Bu istifadəçi adı artıq mövcuddur.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return 0;
                        }
                    }

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            INSERT INTO Users (Username, PasswordHash, FullName, Email, IsAdmin, IsActive, CreatedAt, UpdatedAt)
                            VALUES (@Username, @PasswordHash, @FullName, @Email, @IsAdmin, @IsActive, @CreatedAt, @UpdatedAt);
                            SELECT last_insert_rowid();
                        ";

                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@PasswordHash", SecurityHelper.HashPassword(user.Password));
                        command.Parameters.AddWithValue("@FullName", user.FullName);
                        command.Parameters.AddWithValue("@Email", user.Email ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin ? 1 : 0);
                        command.Parameters.AddWithValue("@IsActive", user.IsActive ? 1 : 0);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        newId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstifadəçi əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newId;
        }

        /// <summary>
        /// Add new user with specified password
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="password">User password</param>
        /// <returns>ID of the new user if successful, 0 otherwise</returns>
        public int AddUser(User user, string password)
        {
            // Set the password on the user object
            user.Password = password;

            // Call the original AddUser method
            return AddUser(user);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user">User to update</param>
        /// <returns>True if successful, false otherwise</returns>
        /// <summary>
        /// Update user with a flag to update certain fields
        /// </summary>
        /// <param name="user">User to update</param>
        /// <param name="updateFlag">Flag to determine what to update</param>
        /// <returns>True if successful</returns>
        public bool UpdateUser(User user, bool updateFlag)
        {
            // UpdateFlag can be used to control which fields to update
            // For example, if updateFlag is true, update all fields
            // If updateFlag is false, update only certain fields
            return UpdateUser(user);
        }

        /// <summary>
        /// Update user information
        /// </summary>
        /// <param name="user">User to update</param>
        /// <returns>True if successful</returns>
        public bool UpdateUser(User user)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Check if username exists for other users
                    using (SQLiteCommand checkCommand = new SQLiteCommand(connection))
                    {
                        checkCommand.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Id != @Id;";
                        checkCommand.Parameters.AddWithValue("@Username", user.Username);
                        checkCommand.Parameters.AddWithValue("@Id", user.Id);

                        long count = (long)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Bu istifadəçi adı artıq mövcuddur.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        if (string.IsNullOrEmpty(user.Password))
                        {
                            // Update without changing password
                            command.CommandText = @"
                                UPDATE Users SET 
                                    Username = @Username, 
                                    FullName = @FullName, 
                                    Email = @Email, 
                                    IsAdmin = @IsAdmin, 
                                    IsActive = @IsActive, 
                                    UpdatedAt = @UpdatedAt
                                WHERE Id = @Id;
                            ";
                        }
                        else
                        {
                            // Update with new password
                            command.CommandText = @"
                                UPDATE Users SET 
                                    Username = @Username, 
                                    PasswordHash = @PasswordHash, 
                                    FullName = @FullName, 
                                    Email = @Email, 
                                    IsAdmin = @IsAdmin, 
                                    IsActive = @IsActive, 
                                    UpdatedAt = @UpdatedAt
                                WHERE Id = @Id;
                            ";
                            command.Parameters.AddWithValue("@PasswordHash", SecurityHelper.HashPassword(user.Password));
                        }

                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@FullName", user.FullName);
                        command.Parameters.AddWithValue("@Email", user.Email ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin ? 1 : 0);
                        command.Parameters.AddWithValue("@IsActive", user.IsActive ? 1 : 0);
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@Id", user.Id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstifadəçi yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool DeleteUser(int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM Users WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@Id", id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İstifadəçi silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Add a new user with specific information
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>New user ID or 0 on failure</returns>
        public int AddUser(string username, string password)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                FullName = username,
                IsAdmin = false,
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return AddUser(user);
        }

        /// <summary>
        /// Update user with specific password
        /// </summary>
        /// <param name="user">User to update</param>
        /// <param name="newPassword">New password</param>
        /// <returns>True if successful</returns>
        public bool UpdateUser(User user, string newPassword)
        {
            user.Password = newPassword;
            user.UpdatedAt = DateTime.Now;

            return UpdateUser(user);
        }

        #endregion

        #region Employee Methods

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>List of employees</returns>
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT * FROM Employees ORDER BY FullName;";

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new Employee
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    FullName = reader["FullName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Position = reader["Position"].ToString(),
                                    Salary = Convert.ToDecimal(reader["Salary"]),
                                    JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                                    Status = reader["Status"].ToString(),
                                    Note = reader["Note"].ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşçilər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return employees;
        }

        /// <summary>
        /// Get employee by ID
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Employee if found, null otherwise</returns>
        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT * FROM Employees WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@Id", id);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                employee = new Employee
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    FullName = reader["FullName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Position = reader["Position"].ToString(),
                                    Salary = Convert.ToDecimal(reader["Salary"]),
                                    JoinDate = Convert.ToDateTime(reader["JoinDate"]),
                                    Status = reader["Status"].ToString(),
                                    Note = reader["Note"].ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşçi yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return employee;
        }

        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="employee">Employee to add</param>
        /// <returns>ID of the new employee if successful, 0 otherwise</returns>
        public int AddEmployee(Employee employee)
        {
            int newId = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            INSERT INTO Employees (FullName, PhoneNumber, Email, Position, Salary, JoinDate, Status, Note, CreatedAt, UpdatedAt)
                            VALUES (@FullName, @PhoneNumber, @Email, @Position, @Salary, @JoinDate, @Status, @Note, @CreatedAt, @UpdatedAt);
                            SELECT last_insert_rowid();
                        ";

                        command.Parameters.AddWithValue("@FullName", employee.FullName);
                        command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                        command.Parameters.AddWithValue("@Email", employee.Email ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Position", employee.Position);
                        command.Parameters.AddWithValue("@Salary", employee.Salary);
                        command.Parameters.AddWithValue("@JoinDate", employee.JoinDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Status", employee.Status);
                        command.Parameters.AddWithValue("@Note", employee.Note ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        newId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşçi əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newId;
        }

        /// <summary>
        /// Update employee
        /// </summary>
        /// <param name="employee">Employee to update</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            UPDATE Employees SET 
                                FullName = @FullName, 
                                PhoneNumber = @PhoneNumber, 
                                Email = @Email, 
                                Position = @Position, 
                                Salary = @Salary, 
                                JoinDate = @JoinDate, 
                                Status = @Status, 
                                Note = @Note, 
                                UpdatedAt = @UpdatedAt
                            WHERE Id = @Id;
                        ";

                        command.Parameters.AddWithValue("@FullName", employee.FullName);
                        command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                        command.Parameters.AddWithValue("@Email", employee.Email ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Position", employee.Position);
                        command.Parameters.AddWithValue("@Salary", employee.Salary);
                        command.Parameters.AddWithValue("@JoinDate", employee.JoinDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Status", employee.Status);
                        command.Parameters.AddWithValue("@Note", employee.Note ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@Id", employee.Id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşçi yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool DeleteEmployee(int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Check if employee is referenced in other tables
                    using (SQLiteCommand checkCommand = new SQLiteCommand(connection))
                    {
                        checkCommand.CommandText = @"
                            SELECT COUNT(*) FROM Properties WHERE EmployeeId = @Id
                            UNION ALL
                            SELECT COUNT(*) FROM Contracts WHERE EmployeeId = @Id
                            UNION ALL
                            SELECT COUNT(*) FROM Expenses WHERE EmployeeId = @Id;
                        ";
                        checkCommand.Parameters.AddWithValue("@Id", id);

                        using (SQLiteDataReader reader = checkCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                long count = Convert.ToInt64(reader[0]);
                                if (count > 0)
                                {
                                    MessageBox.Show("Bu işçi digər cədvəllərdə istifadə olunur və silinə bilməz.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                    }

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM Employees WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@Id", id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İşçi silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region Customer Methods

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List of customers</returns>
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT * FROM Customers ORDER BY FullName;";

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customers.Add(new Customer
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    FullName = reader["FullName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Email = reader["Email"]?.ToString(),
                                    IdNumber = reader["IdNumber"]?.ToString(),
                                    Address = reader["Address"]?.ToString(),
                                    Note = reader["Note"]?.ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müştərilər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return customers;
        }

        /// <summary>
        /// Get customer by ID
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>Customer if found, null otherwise</returns>
        public Customer GetCustomerById(int id)
        {
            Customer customer = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT * FROM Customers WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@Id", id);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customer = new Customer
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    FullName = reader["FullName"].ToString(),
                                    PhoneNumber = reader["PhoneNumber"].ToString(),
                                    Email = reader["Email"]?.ToString(),
                                    IdNumber = reader["IdNumber"]?.ToString(),
                                    Address = reader["Address"]?.ToString(),
                                    Note = reader["Note"]?.ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müştəri yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return customer;
        }

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="customer">Customer to add</param>
        /// <returns>ID of the new customer if successful, 0 otherwise</returns>
        public int AddCustomer(Customer customer)
        {
            int newId = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            INSERT INTO Customers (FullName, PhoneNumber, Email, IdNumber, Address, Note, CreatedAt, UpdatedAt)
                            VALUES (@FullName, @PhoneNumber, @Email, @IdNumber, @Address, @Note, @CreatedAt, @UpdatedAt);
                            SELECT last_insert_rowid();
                        ";

                        command.Parameters.AddWithValue("@FullName", customer.FullName);
                        command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                        command.Parameters.AddWithValue("@Email", customer.Email ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@IdNumber", customer.IdNumber ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Address", customer.Address ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Note", customer.Note ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        newId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müştəri əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newId;
        }

        /// <summary>
        /// Update customer
        /// </summary>
        /// <param name="customer">Customer to update</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            UPDATE Customers SET 
                                FullName = @FullName, 
                                PhoneNumber = @PhoneNumber, 
                                Email = @Email, 
                                IdNumber = @IdNumber, 
                                Address = @Address, 
                                Note = @Note, 
                                UpdatedAt = @UpdatedAt
                            WHERE Id = @Id;
                        ";

                        command.Parameters.AddWithValue("@FullName", customer.FullName);
                        command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                        command.Parameters.AddWithValue("@Email", customer.Email ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@IdNumber", customer.IdNumber ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Address", customer.Address ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Note", customer.Note ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@Id", customer.Id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müştəri yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool DeleteCustomer(int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Check if customer is referenced in other tables
                    using (SQLiteCommand checkCommand = new SQLiteCommand(connection))
                    {
                        checkCommand.CommandText = "SELECT COUNT(*) FROM Contracts WHERE CustomerId = @Id;";
                        checkCommand.Parameters.AddWithValue("@Id", id);

                        long count = (long)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Bu müştəri müqavilələrdə istifadə olunur və silinə bilməz.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM Customers WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@Id", id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müştəri silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region Property Methods

        /// <summary>
        /// Get all properties
        /// </summary>
        /// <returns>List of properties</returns>
        public List<Property> GetAllProperties(string status = null)
        {
            List<Property> properties = new List<Property>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            SELECT p.*, e.FullName as EmployeeName 
                            FROM Properties p
                            LEFT JOIN Employees e ON p.EmployeeId = e.Id
                            ORDER BY p.UpdatedAt DESC;
                        ";

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                properties.Add(new Property
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ListingCode = reader["ListingCode"].ToString(),
                                    Type = reader["Type"].ToString(),
                                    Title = reader["Title"].ToString(),
                                    Description = reader["Description"]?.ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    Area = Convert.ToDecimal(reader["Area"]),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    Rooms = reader["Rooms"] != DBNull.Value ? Convert.ToInt32(reader["Rooms"]) : (int?)null,
                                    Bathrooms = reader["Bathrooms"] != DBNull.Value ? Convert.ToInt32(reader["Bathrooms"]) : (int?)null,
                                    Floor = reader["Floor"] != DBNull.Value ? Convert.ToInt32(reader["Floor"]) : (int?)null,
                                    TotalFloors = reader["TotalFloors"] != DBNull.Value ? Convert.ToInt32(reader["TotalFloors"]) : (int?)null,
                                    BuiltYear = reader["BuiltYear"] != DBNull.Value ? Convert.ToInt32(reader["BuiltYear"]) : (int?)null,
                                    Status = reader["Status"].ToString(),
                                    EmployeeId = reader["EmployeeId"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeId"]) : (int?)null,
                                    EmployeeName = reader["EmployeeName"]?.ToString(),
                                    SourceUrl = reader["SourceUrl"]?.ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əmlaklar yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return properties;
        }

        /// <summary>
        /// Get property by ID
        /// </summary>
        /// <param name="id">Property ID</param>
        /// <param name="includeImages">Whether to include property images</param>
        /// <returns>Property if found, null otherwise</returns>
        public Property GetPropertyById(int id, bool includeImages = false)
        {
            Property property = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            SELECT p.*, e.FullName as EmployeeName 
                            FROM Properties p
                            LEFT JOIN Employees e ON p.EmployeeId = e.Id
                            WHERE p.Id = @Id;
                        ";
                        command.Parameters.AddWithValue("@Id", id);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                property = new Property
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ListingCode = reader["ListingCode"].ToString(),
                                    Type = reader["Type"].ToString(),
                                    Title = reader["Title"].ToString(),
                                    Description = reader["Description"]?.ToString(),
                                    Address = reader["Address"].ToString(),
                                    City = reader["City"].ToString(),
                                    Area = Convert.ToDecimal(reader["Area"]),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    Rooms = reader["Rooms"] != DBNull.Value ? Convert.ToInt32(reader["Rooms"]) : (int?)null,
                                    Bathrooms = reader["Bathrooms"] != DBNull.Value ? Convert.ToInt32(reader["Bathrooms"]) : (int?)null,
                                    Floor = reader["Floor"] != DBNull.Value ? Convert.ToInt32(reader["Floor"]) : (int?)null,
                                    TotalFloors = reader["TotalFloors"] != DBNull.Value ? Convert.ToInt32(reader["TotalFloors"]) : (int?)null,
                                    BuiltYear = reader["BuiltYear"] != DBNull.Value ? Convert.ToInt32(reader["BuiltYear"]) : (int?)null,
                                    Status = reader["Status"].ToString(),
                                    EmployeeId = reader["EmployeeId"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeId"]) : (int?)null,
                                    EmployeeName = reader["EmployeeName"]?.ToString(),
                                    SourceUrl = reader["SourceUrl"]?.ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                };

                                // Load images if requested
                                if (includeImages)
                                {
                                    property.Images = GetPropertyImages(id);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əmlak yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return property;
        }

        /// <summary>
        /// Get property images
        /// </summary>
        /// <param name="propertyId">Property ID</param>
        /// <returns>List of property images</returns>
        public List<PropertyImage> GetPropertyImages(int propertyId)
        {
            List<PropertyImage> images = new List<PropertyImage>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT * FROM PropertyImages WHERE PropertyId = @PropertyId ORDER BY IsMain DESC, Id;";
                        command.Parameters.AddWithValue("@PropertyId", propertyId);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                images.Add(new PropertyImage
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    PropertyId = Convert.ToInt32(reader["PropertyId"]),
                                    ImagePath = reader["ImagePath"].ToString(),
                                    IsMain = Convert.ToBoolean(reader["IsMain"]),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əmlak şəkilləri yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return images;
        }

        /// <summary>
        /// Add new property
        /// </summary>
        /// <param name="property">Property to add</param>
        /// <returns>ID of the new property if successful, 0 otherwise</returns>
        public int AddProperty(Property property)
        {
            int newId = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            INSERT INTO Properties (
                                ListingCode, Type, Title, Description, Address, City, 
                                Area, Price, Rooms, Bathrooms, Floor, TotalFloors, BuiltYear, 
                                Status, EmployeeId, SourceUrl, CreatedAt, UpdatedAt
                            )
                            VALUES (
                                @ListingCode, @Type, @Title, @Description, @Address, @City, 
                                @Area, @Price, @Rooms, @Bathrooms, @Floor, @TotalFloors, @BuiltYear, 
                                @Status, @EmployeeId, @SourceUrl, @CreatedAt, @UpdatedAt
                            );
                            SELECT last_insert_rowid();
                        ";

                        command.Parameters.AddWithValue("@ListingCode", property.ListingCode);
                        command.Parameters.AddWithValue("@Type", property.Type);
                        command.Parameters.AddWithValue("@Title", property.Title);
                        command.Parameters.AddWithValue("@Description", property.Description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Address", property.Address);
                        command.Parameters.AddWithValue("@City", property.City);
                        command.Parameters.AddWithValue("@Area", property.Area);
                        command.Parameters.AddWithValue("@Price", property.Price);
                        command.Parameters.AddWithValue("@Rooms", property.Rooms.HasValue ? (object)property.Rooms.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Bathrooms", property.Bathrooms.HasValue ? (object)property.Bathrooms.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Floor", property.Floor.HasValue ? (object)property.Floor.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@TotalFloors", property.TotalFloors.HasValue ? (object)property.TotalFloors.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@BuiltYear", property.BuiltYear.HasValue ? (object)property.BuiltYear.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Status", property.Status);
                        command.Parameters.AddWithValue("@EmployeeId", property.EmployeeId.HasValue ? (object)property.EmployeeId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@SourceUrl", property.SourceUrl ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedAt", property.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@UpdatedAt", property.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));

                        newId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əmlak əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newId;
        }

        /// <summary>
        /// Update property
        /// </summary>
        /// <param name="property">Property to update</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateProperty(Property property)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            UPDATE Properties SET 
                                ListingCode = @ListingCode, 
                                Type = @Type, 
                                Title = @Title, 
                                Description = @Description, 
                                Address = @Address, 
                                City = @City, 
                                Area = @Area, 
                                Price = @Price, 
                                Rooms = @Rooms, 
                                Bathrooms = @Bathrooms, 
                                Floor = @Floor, 
                                TotalFloors = @TotalFloors, 
                                BuiltYear = @BuiltYear, 
                                Status = @Status, 
                                EmployeeId = @EmployeeId, 
                                SourceUrl = @SourceUrl, 
                                UpdatedAt = @UpdatedAt
                            WHERE Id = @Id;
                        ";

                        command.Parameters.AddWithValue("@ListingCode", property.ListingCode);
                        command.Parameters.AddWithValue("@Type", property.Type);
                        command.Parameters.AddWithValue("@Title", property.Title);
                        command.Parameters.AddWithValue("@Description", property.Description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Address", property.Address);
                        command.Parameters.AddWithValue("@City", property.City);
                        command.Parameters.AddWithValue("@Area", property.Area);
                        command.Parameters.AddWithValue("@Price", property.Price);
                        command.Parameters.AddWithValue("@Rooms", property.Rooms.HasValue ? (object)property.Rooms.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Bathrooms", property.Bathrooms.HasValue ? (object)property.Bathrooms.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Floor", property.Floor.HasValue ? (object)property.Floor.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@TotalFloors", property.TotalFloors.HasValue ? (object)property.TotalFloors.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@BuiltYear", property.BuiltYear.HasValue ? (object)property.BuiltYear.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Status", property.Status);
                        command.Parameters.AddWithValue("@EmployeeId", property.EmployeeId.HasValue ? (object)property.EmployeeId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@SourceUrl", property.SourceUrl ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedAt", property.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@Id", property.Id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əmlak yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Delete property
        /// </summary>
        /// <param name="id">Property ID</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool DeleteProperty(int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Check if property is referenced in other tables
                    using (SQLiteCommand checkCommand = new SQLiteCommand(connection))
                    {
                        checkCommand.CommandText = @"
                            SELECT COUNT(*) FROM Contracts WHERE PropertyId = @Id
                            UNION ALL
                            SELECT COUNT(*) FROM Expenses WHERE PropertyId = @Id;
                        ";
                        checkCommand.Parameters.AddWithValue("@Id", id);

                        using (SQLiteDataReader reader = checkCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                long count = Convert.ToInt64(reader[0]);
                                if (count > 0)
                                {
                                    MessageBox.Show("Bu əmlak digər cədvəllərdə istifadə olunur və silinə bilməz.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                        }
                    }

                    // Get property images to delete
                    List<PropertyImage> images = GetPropertyImages(id);

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Delete property images
                            using (SQLiteCommand deleteImagesCommand = new SQLiteCommand(connection))
                            {
                                deleteImagesCommand.CommandText = "DELETE FROM PropertyImages WHERE PropertyId = @PropertyId;";
                                deleteImagesCommand.Parameters.AddWithValue("@PropertyId", id);
                                deleteImagesCommand.ExecuteNonQuery();
                            }

                            // Delete property
                            using (SQLiteCommand deletePropertyCommand = new SQLiteCommand(connection))
                            {
                                deletePropertyCommand.CommandText = "DELETE FROM Properties WHERE Id = @Id;";
                                deletePropertyCommand.Parameters.AddWithValue("@Id", id);
                                deletePropertyCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            // Delete image files
                            foreach (var image in images)
                            {
                                ImageHelper.DeletePropertyImage(image.ImagePath);
                            }

                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əmlak silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Add property images
        /// </summary>
        /// <param name="propertyId">Property ID</param>
        /// <param name="imagePaths">List of image paths</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool AddPropertyImages(int propertyId, List<string> imagePaths)
        {
            if (imagePaths == null || imagePaths.Count == 0)
            {
                return false;
            }

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            foreach (string imagePath in imagePaths)
                            {
                                using (SQLiteCommand command = new SQLiteCommand(connection))
                                {
                                    command.CommandText = @"
                                        INSERT INTO PropertyImages (PropertyId, ImagePath, IsMain, CreatedAt)
                                        VALUES (@PropertyId, @ImagePath, @IsMain, @CreatedAt);
                                    ";

                                    // Check if there are any existing images
                                    using (SQLiteCommand checkCommand = new SQLiteCommand(connection))
                                    {
                                        checkCommand.CommandText = "SELECT COUNT(*) FROM PropertyImages WHERE PropertyId = @PropertyId;";
                                        checkCommand.Parameters.AddWithValue("@PropertyId", propertyId);

                                        long count = (long)checkCommand.ExecuteScalar();

                                        command.Parameters.AddWithValue("@PropertyId", propertyId);
                                        command.Parameters.AddWithValue("@ImagePath", imagePath);
                                        command.Parameters.AddWithValue("@IsMain", count == 0 ? 1 : 0); // First image is main
                                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                        command.ExecuteNonQuery();
                                    }
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əmlak şəkilləri əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Delete property image
        /// </summary>
        /// <param name="imageId">Image ID</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool DeletePropertyImage(int imageId)
        {
            try
            {
                string imagePath = null;

                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Get image path first
                    using (SQLiteCommand getPathCommand = new SQLiteCommand(connection))
                    {
                        getPathCommand.CommandText = "SELECT ImagePath FROM PropertyImages WHERE Id = @Id;";
                        getPathCommand.Parameters.AddWithValue("@Id", imageId);

                        imagePath = (string)getPathCommand.ExecuteScalar();
                    }

                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return false;
                    }

                    // Delete from database
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM PropertyImages WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@Id", imageId);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            // Delete file from disk
                            return ImageHelper.DeletePropertyImage(imagePath);
                        }

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şəkil silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region Contract Methods

        /// <summary>
        /// Get all contracts
        /// </summary>
        /// <returns>List of contracts</returns>
        public List<Contract> GetAllContracts()
        {
            List<Contract> contracts = new List<Contract>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            SELECT c.*, 
                                p.Title as PropertyTitle,
                                cust.FullName as CustomerName,
                                e.FullName as EmployeeName
                            FROM Contracts c
                            LEFT JOIN Properties p ON c.PropertyId = p.Id
                            LEFT JOIN Customers cust ON c.CustomerId = cust.Id
                            LEFT JOIN Employees e ON c.EmployeeId = e.Id
                            ORDER BY c.SignDate DESC;
                        ";

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                contracts.Add(new Contract
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ContractNumber = reader["ContractNumber"].ToString(),
                                    PropertyId = Convert.ToInt32(reader["PropertyId"]),
                                    PropertyTitle = reader["PropertyTitle"].ToString(),
                                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                    EmployeeName = reader["EmployeeName"].ToString(),
                                    ContractType = reader["ContractType"].ToString(),
                                    ContractAmount = Convert.ToDecimal(reader["ContractAmount"]),
                                    StartDate = Convert.ToDateTime(reader["StartDate"]),
                                    EndDate = reader["EndDate"] != DBNull.Value ? Convert.ToDateTime(reader["EndDate"]) : (DateTime?)null,
                                    SignDate = Convert.ToDateTime(reader["SignDate"]),
                                    Status = reader["Status"].ToString(),
                                    Note = reader["Note"]?.ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müqavilələr yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return contracts;
        }

        /// <summary>
        /// Get contract by ID
        /// </summary>
        /// <param name="id">Contract ID</param>
        /// <returns>Contract if found, null otherwise</returns>
        public Contract GetContractById(int id)
        {
            Contract contract = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            SELECT c.*, 
                                p.Title as PropertyTitle,
                                cust.FullName as CustomerName,
                                e.FullName as EmployeeName
                            FROM Contracts c
                            LEFT JOIN Properties p ON c.PropertyId = p.Id
                            LEFT JOIN Customers cust ON c.CustomerId = cust.Id
                            LEFT JOIN Employees e ON c.EmployeeId = e.Id
                            WHERE c.Id = @Id;
                        ";
                        command.Parameters.AddWithValue("@Id", id);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                contract = new Contract
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ContractNumber = reader["ContractNumber"].ToString(),
                                    PropertyId = Convert.ToInt32(reader["PropertyId"]),
                                    PropertyTitle = reader["PropertyTitle"].ToString(),
                                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                    EmployeeName = reader["EmployeeName"].ToString(),
                                    ContractType = reader["ContractType"].ToString(),
                                    ContractAmount = Convert.ToDecimal(reader["ContractAmount"]),
                                    StartDate = Convert.ToDateTime(reader["StartDate"]),
                                    EndDate = reader["EndDate"] != DBNull.Value ? Convert.ToDateTime(reader["EndDate"]) : (DateTime?)null,
                                    SignDate = Convert.ToDateTime(reader["SignDate"]),
                                    Status = reader["Status"].ToString(),
                                    Note = reader["Note"]?.ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müqavilə yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return contract;
        }

        /// <summary>
        /// Add new contract
        /// </summary>
        /// <param name="contract">Contract to add</param>
        /// <returns>ID of the new contract if successful, 0 otherwise</returns>
        public int AddContract(Contract contract)
        {
            int newId = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            INSERT INTO Contracts (
                                ContractNumber, PropertyId, CustomerId, EmployeeId, ContractType,
                                ContractAmount, StartDate, EndDate, SignDate, Status, Note, CreatedAt, UpdatedAt
                            )
                            VALUES (
                                @ContractNumber, @PropertyId, @CustomerId, @EmployeeId, @ContractType,
                                @ContractAmount, @StartDate, @EndDate, @SignDate, @Status, @Note, @CreatedAt, @UpdatedAt
                            );
                            SELECT last_insert_rowid();
                        ";

                        command.Parameters.AddWithValue("@ContractNumber", contract.ContractNumber);
                        command.Parameters.AddWithValue("@PropertyId", contract.PropertyId);
                        command.Parameters.AddWithValue("@CustomerId", contract.CustomerId);
                        command.Parameters.AddWithValue("@EmployeeId", contract.EmployeeId);
                        command.Parameters.AddWithValue("@ContractType", contract.ContractType);
                        command.Parameters.AddWithValue("@ContractAmount", contract.ContractAmount);
                        command.Parameters.AddWithValue("@StartDate", contract.StartDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@EndDate", contract.EndDate.HasValue ? (object)contract.EndDate.Value.ToString("yyyy-MM-dd") : DBNull.Value);
                        command.Parameters.AddWithValue("@SignDate", contract.SignDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Status", contract.Status);
                        command.Parameters.AddWithValue("@Note", contract.Note ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        newId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müqavilə əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newId;
        }

        /// <summary>
        /// Update contract
        /// </summary>
        /// <param name="contract">Contract to update</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateContract(Contract contract)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            UPDATE Contracts SET 
                                ContractNumber = @ContractNumber, 
                                PropertyId = @PropertyId, 
                                CustomerId = @CustomerId, 
                                EmployeeId = @EmployeeId, 
                                ContractType = @ContractType, 
                                ContractAmount = @ContractAmount, 
                                StartDate = @StartDate, 
                                EndDate = @EndDate, 
                                SignDate = @SignDate, 
                                Status = @Status, 
                                Note = @Note, 
                                UpdatedAt = @UpdatedAt
                            WHERE Id = @Id;
                        ";

                        command.Parameters.AddWithValue("@ContractNumber", contract.ContractNumber);
                        command.Parameters.AddWithValue("@PropertyId", contract.PropertyId);
                        command.Parameters.AddWithValue("@CustomerId", contract.CustomerId);
                        command.Parameters.AddWithValue("@EmployeeId", contract.EmployeeId);
                        command.Parameters.AddWithValue("@ContractType", contract.ContractType);
                        command.Parameters.AddWithValue("@ContractAmount", contract.ContractAmount);
                        command.Parameters.AddWithValue("@StartDate", contract.StartDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@EndDate", contract.EndDate.HasValue ? (object)contract.EndDate.Value.ToString("yyyy-MM-dd") : DBNull.Value);
                        command.Parameters.AddWithValue("@SignDate", contract.SignDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Status", contract.Status);
                        command.Parameters.AddWithValue("@Note", contract.Note ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@Id", contract.Id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müqavilə yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Delete contract
        /// </summary>
        /// <param name="id">Contract ID</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool DeleteContract(int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Check if contract is referenced in payments
                    using (SQLiteCommand checkCommand = new SQLiteCommand(connection))
                    {
                        checkCommand.CommandText = "SELECT COUNT(*) FROM DownPayments WHERE ContractId = @Id;";
                        checkCommand.Parameters.AddWithValue("@Id", id);

                        long count = (long)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Bu müqavilə üzrə ödənişlər var və silinə bilməz.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM Contracts WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@Id", id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Müqavilə silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region Expense Methods

        /// <summary>
        /// Get all expenses
        /// </summary>
        /// <returns>List of expenses</returns>
        public List<Expense> GetAllExpenses()
        {
            List<Expense> expenses = new List<Expense>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            SELECT e.*, 
                                emp.FullName as EmployeeName,
                                p.Title as PropertyTitle
                            FROM Expenses e
                            LEFT JOIN Employees emp ON e.EmployeeId = emp.Id
                            LEFT JOIN Properties p ON e.PropertyId = p.Id
                            ORDER BY e.ExpenseDate DESC;
                        ";

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                expenses.Add(new Expense
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Category = reader["Category"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"]),
                                    ExpenseDate = Convert.ToDateTime(reader["ExpenseDate"]),
                                    EmployeeId = reader["EmployeeId"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeId"]) : (int?)null,
                                    EmployeeName = reader["EmployeeName"]?.ToString(),
                                    PropertyId = reader["PropertyId"] != DBNull.Value ? Convert.ToInt32(reader["PropertyId"]) : (int?)null,
                                    PropertyTitle = reader["PropertyTitle"]?.ToString(),
                                    Status = reader["Status"].ToString(),
                                    Note = reader["Note"]?.ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xərclər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return expenses;
        }

        /// <summary>
        /// Get expense by ID
        /// </summary>
        /// <param name="id">Expense ID</param>
        /// <returns>Expense if found, null otherwise</returns>
        public Expense GetExpenseById(int id)
        {
            Expense expense = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            SELECT e.*, 
                                emp.FullName as EmployeeName,
                                p.Title as PropertyTitle
                            FROM Expenses e
                            LEFT JOIN Employees emp ON e.EmployeeId = emp.Id
                            LEFT JOIN Properties p ON e.PropertyId = p.Id
                            WHERE e.Id = @Id;
                        ";
                        command.Parameters.AddWithValue("@Id", id);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                expense = new Expense
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Category = reader["Category"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"]),
                                    ExpenseDate = Convert.ToDateTime(reader["ExpenseDate"]),
                                    EmployeeId = reader["EmployeeId"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeId"]) : (int?)null,
                                    EmployeeName = reader["EmployeeName"]?.ToString(),
                                    PropertyId = reader["PropertyId"] != DBNull.Value ? Convert.ToInt32(reader["PropertyId"]) : (int?)null,
                                    PropertyTitle = reader["PropertyTitle"]?.ToString(),
                                    Status = reader["Status"].ToString(),
                                    Note = reader["Note"]?.ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xərc yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return expense;
        }

        /// <summary>
        /// Add new expense
        /// </summary>
        /// <param name="expense">Expense to add</param>
        /// <returns>ID of the new expense if successful, 0 otherwise</returns>
        public int AddExpense(Expense expense)
        {
            int newId = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            INSERT INTO Expenses (
                                Category, Description, Amount, ExpenseDate, EmployeeId,
                                PropertyId, Status, Note, CreatedAt, UpdatedAt
                            )
                            VALUES (
                                @Category, @Description, @Amount, @ExpenseDate, @EmployeeId,
                                @PropertyId, @Status, @Note, @CreatedAt, @UpdatedAt
                            );
                            SELECT last_insert_rowid();
                        ";

                        command.Parameters.AddWithValue("@Category", expense.Category);
                        command.Parameters.AddWithValue("@Description", expense.Description);
                        command.Parameters.AddWithValue("@Amount", expense.Amount);
                        command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@EmployeeId", expense.EmployeeId.HasValue ? (object)expense.EmployeeId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@PropertyId", expense.PropertyId.HasValue ? (object)expense.PropertyId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Status", expense.Status);
                        command.Parameters.AddWithValue("@Note", expense.Note ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        newId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xərc əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newId;
        }

        /// <summary>
        /// Update expense
        /// </summary>
        /// <param name="expense">Expense to update</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateExpense(Expense expense)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            UPDATE Expenses SET 
                                Category = @Category, 
                                Description = @Description, 
                                Amount = @Amount, 
                                ExpenseDate = @ExpenseDate, 
                                EmployeeId = @EmployeeId, 
                                PropertyId = @PropertyId, 
                                Status = @Status, 
                                Note = @Note, 
                                UpdatedAt = @UpdatedAt
                            WHERE Id = @Id;
                        ";

                        command.Parameters.AddWithValue("@Category", expense.Category);
                        command.Parameters.AddWithValue("@Description", expense.Description);
                        command.Parameters.AddWithValue("@Amount", expense.Amount);
                        command.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@EmployeeId", expense.EmployeeId.HasValue ? (object)expense.EmployeeId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@PropertyId", expense.PropertyId.HasValue ? (object)expense.PropertyId.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Status", expense.Status);
                        command.Parameters.AddWithValue("@Note", expense.Note ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@Id", expense.Id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xərc yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Delete expense
        /// </summary>
        /// <param name="id">Expense ID</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool DeleteExpense(int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM Expenses WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@Id", id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xərc silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region DownPayment Methods

        /// <summary>
        /// Update a down payment
        /// </summary>
        /// <param name="payment">Down payment to update</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateDownPayment(DownPayment payment)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            UPDATE DownPayments SET 
                                ContractId = @ContractId, 
                                Amount = @Amount, 
                                PaymentDate = @PaymentDate, 
                                PaymentMethod = @PaymentMethod,
                                PaymentType = @PaymentType,
                                PaymentNumber = @PaymentNumber,
                                Note = @Note,
                                UpdatedAt = @UpdatedAt
                            WHERE Id = @Id;
                        ";

                        command.Parameters.AddWithValue("@Id", payment.Id);
                        command.Parameters.AddWithValue("@ContractId", payment.ContractId);
                        command.Parameters.AddWithValue("@Amount", payment.Amount);
                        command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                        command.Parameters.AddWithValue("@PaymentType", payment.PaymentType);
                        command.Parameters.AddWithValue("@PaymentNumber", payment.PaymentNumber ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Note", payment.Note ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödəniş yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get all down payments
        /// </summary>
        /// <returns>List of down payments</returns>
        public List<DownPayment> GetAllDownPayments()
        {
            List<DownPayment> payments = new List<DownPayment>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            SELECT dp.*, 
                                c.ContractNumber,
                                cust.FullName as CustomerName
                            FROM DownPayments dp
                            LEFT JOIN Contracts c ON dp.ContractId = c.Id
                            LEFT JOIN Customers cust ON c.CustomerId = cust.Id
                            ORDER BY dp.PaymentDate DESC;
                        ";

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                payments.Add(new DownPayment
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ContractId = Convert.ToInt32(reader["ContractId"]),
                                    ContractNumber = reader["ContractNumber"].ToString(),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"]),
                                    PaymentDate = Convert.ToDateTime(reader["PaymentDate"]),
                                    PaymentMethod = reader["PaymentMethod"].ToString(),
                                    Note = reader["Note"]?.ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödənişlər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return payments;
        }

        /// <summary>
        /// Get down payments by contract ID
        /// </summary>
        /// <param name="contractId">Contract ID</param>
        /// <returns>List of down payments for the contract</returns>
        public List<DownPayment> GetDownPaymentsByContractId(int contractId)
        {
            List<DownPayment> payments = new List<DownPayment>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            SELECT dp.*, 
                                c.ContractNumber,
                                cust.FullName as CustomerName
                            FROM DownPayments dp
                            LEFT JOIN Contracts c ON dp.ContractId = c.Id
                            LEFT JOIN Customers cust ON c.CustomerId = cust.Id
                            WHERE dp.ContractId = @ContractId
                            ORDER BY dp.PaymentDate DESC;
                        ";
                        command.Parameters.AddWithValue("@ContractId", contractId);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                payments.Add(new DownPayment
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ContractId = Convert.ToInt32(reader["ContractId"]),
                                    ContractNumber = reader["ContractNumber"].ToString(),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"]),
                                    PaymentDate = Convert.ToDateTime(reader["PaymentDate"]),
                                    PaymentMethod = reader["PaymentMethod"].ToString(),
                                    Note = reader["Note"]?.ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödənişlər yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return payments;
        }

        /// <summary>
        /// Get down payment by ID
        /// </summary>
        /// <param name="id">Down payment ID</param>
        /// <returns>Down payment if found, null otherwise</returns>
        public DownPayment GetDownPaymentById(int id)
        {
            DownPayment payment = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            SELECT dp.*, 
                                c.ContractNumber,
                                cust.FullName as CustomerName
                            FROM DownPayments dp
                            LEFT JOIN Contracts c ON dp.ContractId = c.Id
                            LEFT JOIN Customers cust ON c.CustomerId = cust.Id
                            WHERE dp.Id = @Id;
                        ";
                        command.Parameters.AddWithValue("@Id", id);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                payment = new DownPayment
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ContractId = Convert.ToInt32(reader["ContractId"]),
                                    ContractNumber = reader["ContractNumber"].ToString(),
                                    CustomerName = reader["CustomerName"].ToString(),
                                    Amount = Convert.ToDecimal(reader["Amount"]),
                                    PaymentDate = Convert.ToDateTime(reader["PaymentDate"]),
                                    PaymentMethod = reader["PaymentMethod"].ToString(),
                                    Note = reader["Note"]?.ToString(),
                                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödəniş yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return payment;
        }

        /// <summary>
        /// Add new down payment
        /// </summary>
        /// <param name="payment">Down payment to add</param>
        /// <returns>ID of the new down payment if successful, 0 otherwise</returns>
        public int AddDownPayment(DownPayment payment)
        {
            int newId = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            INSERT INTO DownPayments (ContractId, Amount, PaymentDate, PaymentMethod, Note, CreatedAt)
                            VALUES (@ContractId, @Amount, @PaymentDate, @PaymentMethod, @Note, @CreatedAt);
                            SELECT last_insert_rowid();
                        ";

                        command.Parameters.AddWithValue("@ContractId", payment.ContractId);
                        command.Parameters.AddWithValue("@Amount", payment.Amount);
                        command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                        command.Parameters.AddWithValue("@Note", payment.Note ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        newId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödəniş əlavə edilərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return newId;
        }

        /// <summary>
        /// Delete down payment
        /// </summary>
        /// <param name="id">Down payment ID</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool DeleteDownPayment(int id)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "DELETE FROM DownPayments WHERE Id = @Id;";
                        command.Parameters.AddWithValue("@Id", id);

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödəniş silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region Company Information Methods

        /// <summary>
        /// Save company information
        /// </summary>
        /// <param name="companyInfo">Company information to save</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool SaveCompanyInfo(CompanyInfo companyInfo)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Check if CompanyInfo table exists, create if not
                    using (SQLiteCommand checkCommand = new SQLiteCommand(connection))
                    {
                        checkCommand.CommandText = @"
                            CREATE TABLE IF NOT EXISTS CompanyInfo (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                CompanyName TEXT NOT NULL,
                                Address TEXT,
                                Phone TEXT,
                                Email TEXT,
                                Website TEXT,
                                TaxId TEXT,
                                LogoPath TEXT,
                                ContractTerms TEXT,
                                UpdatedAt TEXT NOT NULL
                            );
                        ";
                        checkCommand.ExecuteNonQuery();
                    }

                    // Check if any record exists
                    using (SQLiteCommand countCommand = new SQLiteCommand(connection))
                    {
                        countCommand.CommandText = "SELECT COUNT(*) FROM CompanyInfo;";
                        long count = (long)countCommand.ExecuteScalar();

                        if (count == 0)
                        {
                            // Insert new record
                            using (SQLiteCommand command = new SQLiteCommand(connection))
                            {
                                command.CommandText = @"
                                    INSERT INTO CompanyInfo (CompanyName, Address, Phone, Email, Website, TaxId, LogoPath, ContractTerms, UpdatedAt)
                                    VALUES (@CompanyName, @Address, @Phone, @Email, @Website, @TaxId, @LogoPath, @ContractTerms, @UpdatedAt);
                                ";

                                command.Parameters.AddWithValue("@CompanyName", companyInfo.CompanyName);
                                command.Parameters.AddWithValue("@Address", companyInfo.Address ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@Phone", companyInfo.Phone ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@Email", companyInfo.Email ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@Website", companyInfo.Website ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@TaxId", companyInfo.TaxId ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@LogoPath", companyInfo.LogoPath ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@ContractTerms", companyInfo.ContractTerms ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                return command.ExecuteNonQuery() > 0;
                            }
                        }
                        else
                        {
                            // Update existing record
                            using (SQLiteCommand command = new SQLiteCommand(connection))
                            {
                                command.CommandText = @"
                                    UPDATE CompanyInfo SET 
                                        CompanyName = @CompanyName, 
                                        Address = @Address, 
                                        Phone = @Phone, 
                                        Email = @Email, 
                                        Website = @Website, 
                                        TaxId = @TaxId, 
                                        LogoPath = @LogoPath, 
                                        ContractTerms = @ContractTerms,
                                        UpdatedAt = @UpdatedAt
                                    WHERE Id = 1;
                                ";

                                command.Parameters.AddWithValue("@CompanyName", companyInfo.CompanyName);
                                command.Parameters.AddWithValue("@Address", companyInfo.Address ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@Phone", companyInfo.Phone ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@Email", companyInfo.Email ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@Website", companyInfo.Website ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@TaxId", companyInfo.TaxId ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@LogoPath", companyInfo.LogoPath ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@ContractTerms", companyInfo.ContractTerms ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                return command.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şirkət məlumatları saxlanarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get company information
        /// </summary>
        /// <returns>Company information if found, null otherwise</returns>
        public CompanyInfo GetCompanyInfo()
        {
            CompanyInfo companyInfo = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Check if CompanyInfo table exists
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = @"
                            SELECT name FROM sqlite_master 
                            WHERE type='table' AND name='CompanyInfo';
                        ";

                        var result = command.ExecuteScalar();
                        if (result == null)
                        {
                            // Table doesn't exist, create it
                            using (SQLiteCommand createCommand = new SQLiteCommand(connection))
                            {
                                createCommand.CommandText = @"
                                    CREATE TABLE IF NOT EXISTS CompanyInfo (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        CompanyName TEXT NOT NULL,
                                        Address TEXT,
                                        Phone TEXT,
                                        Email TEXT,
                                        Website TEXT,
                                        TaxId TEXT,
                                        LogoPath TEXT,
                                        ContractTerms TEXT,
                                        UpdatedAt TEXT NOT NULL
                                    );
                                ";
                                createCommand.ExecuteNonQuery();
                            }

                            // Return default company info
                            return new CompanyInfo
                            {
                                CompanyName = "AS Home"
                            };
                        }
                    }

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "SELECT * FROM CompanyInfo LIMIT 1;";

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                companyInfo = new CompanyInfo
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    CompanyName = reader["CompanyName"].ToString(),
                                    Address = reader["Address"]?.ToString(),
                                    Phone = reader["Phone"]?.ToString(),
                                    Email = reader["Email"]?.ToString(),
                                    Website = reader["Website"]?.ToString(),
                                    TaxId = reader["TaxId"]?.ToString(),
                                    LogoPath = reader["LogoPath"]?.ToString(),
                                    ContractTerms = reader["ContractTerms"]?.ToString(),
                                    UpdatedAt = Convert.ToDateTime(reader["UpdatedAt"])
                                };
                            }
                            else
                            {
                                // No data in table, return default company info
                                companyInfo = new CompanyInfo
                                {
                                    CompanyName = "AS Home"
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Şirkət məlumatları yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return companyInfo;
        }

        #endregion
    }
}
