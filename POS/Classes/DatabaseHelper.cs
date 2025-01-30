using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace POS.Classes
{
    public class DatabaseHelper
    {
        private static readonly string FolderPath = @"C:\POS";
        private static readonly string DbPath = Path.Combine(FolderPath, "POS.sqlite");

        public static void CreateDatabase()
        {
            try
            {
                // Create the folder if it doesn't exist
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                // Check if the database file already exists
                if (System.IO.File.Exists(DbPath))
                {
                    MessageBox.Show("Database already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create the SQLite database file
                SQLiteConnection.CreateFile(DbPath);

                // Connect to the database and create tables
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {

                    connection.Open();

                    // Create multiple tables
                    string[] tableQueries = new string[]
                    {
                         // Users Table
                        @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            UserId VARCHAR(100) NOT NULL UNIQUE,
                            LocationId INTEGER NOT NULL, 
                            Username VARCHAR(100) NOT NULL,
                            Password VARCHAR(100) NOT NULL,
                            Name VARCHAR(100) NOT NULL,
                            IsRole  INTEGER NOT NULL,
                            Status  INTEGER NOT NULL,
                            Token  VARCHAR(500),
                            DateCreated DATETIME DEFAULT (DATETIME('now')),
                            FOREIGN KEY (LocationId) REFERENCES Locations(LocationId)
                        );",

                         // Customer Table
                        @"
                        CREATE TABLE IF NOT EXISTS Customers (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            AccountId VARCHAR(100) NOT NULL UNIQUE,
                            FirstName VARCHAR(100) NOT NULL,
                            LastName VARCHAR(100) NOT NULL,
                            ContactNo VARCHAR(100) NOT NULL, 
                            Email VARCHAR(100) NOT NULL,       
                            TransactionCount  INTEGER NOT NULL,
                            CardNumber VARCHAR(100) NOT NULL UNIQUE,
                            Points  INTEGER NOT NULL,
                            Status  INTEGER NOT NULL,   
                            DateCreated DATETIME DEFAULT (DATETIME('now'))     
                        );",

                        // Inventory Table
                        @"
                        CREATE TABLE IF NOT EXISTS Inventory (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            InventoryId INTEGER NOT NULL UNIQUE,
                            Specification VARCHAR(55),
                            Units INT NOT NULL,
                            ProductId INT NOT NULL,
                            LocationId INT NOT NULL,
                            Status INT NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now')),
                            FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
                            FOREIGN KEY (LocationId) REFERENCES Locations(LocationId)
                        );",
                        
                        // Products Table
                        @"
                        CREATE TABLE IF NOT EXISTS Products (
                            ProductId INTEGER PRIMARY KEY AUTOINCREMENT,
                            Id INTEGER NOT NULL UNIQUE,
                            Barcode VARCHAR(100) NOT NULL,
                            Name VARCHAR(100) NOT NULL,
                            Description VARCHAR(100) NOT NULL,
                            SupplierPrice  DECIMAL(18, 2) NOT NULL,
                            RetailPrice  DECIMAL(18, 2) NOT NULL,
                            WholesalePrice  DECIMAL(18, 2) NOT NULL,
                            ReorderLevel  INTEGER NOT NULL,
                            Remarks VARCHAR(100) NOT NULL,
                            IsVat  INTEGER NOT NULL,
                            Status  INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now')),        
                            CategoryId  INTEGER NOT NULL,
                            FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
                        );",
                        
                        // Category Table
                        @"
                        CREATE TABLE IF NOT EXISTS Category (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            CategoryId INTEGER NOT NULL UNIQUE,
                            Name VARCHAR(100) NOT NULL,
                            Status  INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now'))     
                        );",

                        // Locations Table
                        @"
                           CREATE TABLE IF NOT EXISTS Locations (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            LocationId INTEGER NOT NULL UNIQUE,
                            Name VARCHAR(50) NOT NULL,
                            Status INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now'))   
                        );",

                        // Discount Table
                        @"
                        CREATE TABLE IF NOT EXISTS Discounts (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            DiscountId INTEGER NOT NULL UNIQUE,
                            Name VARCHAR(100) NOT NULL,
                            Percentage INTEGER NOT NULL,
                            Status  INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now'))     
                        );",

                        // Cash Drawer Table
                        @"
                        CREATE TABLE IF NOT EXISTS CashDrawer (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            DrawerId INTEGER NOT NULL,
                            UserId INTEGER NOT NULL,
                            LocationId INTEGER NOT NULL,
                            InitialCash DECIMAL(18, 2) NOT NULL,
                            Withdrawals DECIMAL(18, 2) NOT NULL,
                            Expenses DECIMAL(18, 2) NOT NULL,
                            DrawerCash DECIMAL(18, 2) NOT NULL,    
                            TimeStart DATETIME NOT NULL,
                            TimeEnd DATETIME,
                            Status  INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now')),
                            FOREIGN KEY (LocationId) REFERENCES Locations(LocationId)
                        );",

                         // Initial Cash Table
                        @"
                        CREATE TABLE IF NOT EXISTS InitialCash (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            DrawerId INTEGER NOT NULL,
                            Cash DECIMAL(18, 2) NOT NULL,
                            Remarks VARCHAR(100) NOT NULL,
                            IsAdditional  INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now'))     
                        );",

                         // Withdrawals Cash Table
                          @"
                        CREATE TABLE IF NOT EXISTS Withdrawals (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            DrawerId INTEGER NOT NULL,
                            Cash DECIMAL(18, 2) NOT NULL,
                            Remarks VARCHAR(100) NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now'))     
                        );",

                         // Expenses Cash Table
                          @"
                        CREATE TABLE IF NOT EXISTS Expenses (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            DrawerId INTEGER NOT NULL,
                            Cash DECIMAL(18, 2) NOT NULL,
                            Remarks VARCHAR(100) NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now'))     
                        );",

                        // HoldProducts Table
                        @"
                        CREATE TABLE IF NOT EXISTS HoldProducts (
                            HoldProductId INTEGER PRIMARY KEY AUTOINCREMENT,
                            ReferenceId INTEGER NOT NULL,
                            ProductId INTEGER NOT NULL,
                            Barcode VARCHAR(100) NOT NULL,
                            Name VARCHAR(100) NOT NULL,
                            Description VARCHAR(100) NOT NULL,
                            Price  DECIMAL(18, 2) NOT NULL,
                            Quantity  INTEGER NOT NULL,
                            VatAmount  DECIMAL(18, 2) NOT NULL,
                            SubTotal  DECIMAL(18, 2) NOT NULL,
                            AppliedDiscount  DECIMAL(18, 2) NOT NULL,
                            TotalDiscount  DECIMAL(18, 2) NOT NULL,
                            DiscountId  INTEGER NOT NULL,
                            IsVat  INTEGER NOT NULL,
                            HasDiscountApplied  INTEGER NOT NULL,
                            DiscountPercentage  DECIMAL(18, 2) NOT NULL     
                        );",

                         // HoldOrders Table
                        @"
                        CREATE TABLE IF NOT EXISTS HoldOrders (
                            HoldId INTEGER PRIMARY KEY AUTOINCREMENT,
                            ReferenceID INTEGER NOT NULL,
                            EmployeeId INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now'))     
                        );",

                           // Orders Table
                        @"
                        CREATE TABLE IF NOT EXISTS Orders (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            InvoiceNumber INTEGER NOT NULL,
                            UserId INTEGER NOT NULL,
                            LocationId INTEGER NOT NULL,
                            AccountId INTEGER NOT NULL,
                            TotalAmount  DECIMAL(18, 2) NOT NULL,
                            ReceivedAmount  DECIMAL(18, 2) NOT NULL,
                            PaymentMethod INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now'))     
                        );",

                          // OrderProducts Table
                        @"
                        CREATE TABLE IF NOT EXISTS OrderProducts (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            InvoiceNumber INTEGER NOT NULL,
                            ProductId INTEGER NOT NULL,
                            Quantity INTEGER NOT NULL,
                            SubTotal  DECIMAL(18, 2) NOT NULL,
                            DiscountId  INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now'))     
                        );"
                    };

                    // Execute each table creation query
                    foreach (string query in tableQueries)
                    {
                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }

                // MessageBox.Show("Database created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task SyncDataFromApi<T>(
           string apiUrl,
           string authToken,
           string tableName,
           Func<T, SQLiteCommand, Task> mapToDatabaseCommand)
        {
            try
            {
                // Fetch data from the Web API with Authorization header
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserialize JSON to a list of objects of type T
                        var items = JsonSerializer.Deserialize<List<T>>(jsonResponse);

                        if (items == null || items.Count == 0)
                        {
                            MessageBox.Show($"No data to sync for {tableName}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Connect to SQLite database
                        using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                        {
                            connection.Open();

                            foreach (var item in items)
                            {
                                using (var command = new SQLiteCommand(connection))
                                {
                                    // Call the mapping function to insert/update data
                                    await mapToDatabaseCommand(item, command);
                                    command.ExecuteNonQuery();
                                }
                            }

                            connection.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show($"Failed to fetch data for {tableName}. Status: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error syncing data for {tableName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task SyncSingleDataFromApi<T>(
        string apiUrl,
        string authToken,
        string tableName,
        Func<T, SQLiteCommand, Task> mapToDatabaseCommand)
        {
            try
            {
                // Fetch data from the Web API with Authorization header
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserialize JSON to a list of objects of type T
                        var items = JsonSerializer.Deserialize<List<T>>(jsonResponse);

                        if (items == null || items.Count == 0)
                        {
                            MessageBox.Show($"No data to sync for {tableName}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Connect to SQLite database
                        using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                        {
                            connection.Open();

                            foreach (var item in items)
                            {
                                using (var command = new SQLiteCommand(connection))
                                {
                                    // Call the mapping function to insert/update data
                                    await mapToDatabaseCommand(item, command);
                                    command.ExecuteNonQuery();
                                }
                            }

                            connection.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show($"Failed to fetch data for {tableName}. Status: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error syncing data for {tableName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task SyncProducts(string apiUrl, string authToken)
        {

            await SyncDataFromApi<Products>(
                apiUrl,
                authToken,
                "Products",
                async (product, command) =>
                {
                    // Clear parameters at the beginning of each operation
                    command.Parameters.Clear();

                    // Check if the product already exists
                    string checkQuery = "SELECT COUNT(1) FROM Products WHERE Id = @Id";
                    command.CommandText = checkQuery;
                    command.Parameters.AddWithValue("@Id", product.Id);

                    long count = (long)(await command.ExecuteScalarAsync());

                    if (count == 0)
                    {
                        command.CommandText = @"
                                            INSERT INTO Products (Id, Barcode, Name, Description, SupplierPrice, RetailPrice, WholesalePrice, ReorderLevel, Remarks, IsVat, Status, CategoryId)
                                            VALUES (@Id, @Barcode, @Name, @Description, @SupplierPrice, @RetailPrice, @WholesalePrice, @ReorderLevel, @Remarks, @IsVat, @Status, @CategoryId);";
                    }
                    else
                    {
                        command.CommandText = @"
                            UPDATE Products
                            SET Barcode = @Barcode,
                                Name = @Name,
                                Description = @Description,
                                SupplierPrice = @SupplierPrice,
                                RetailPrice = @RetailPrice,
                                WholesalePrice = @WholesalePrice,
                                ReorderLevel = @ReorderLevel,
                                Remarks = @Remarks,
                                IsVat = @IsVat,
                                Status = @Status,
                                CategoryId = @CategoryId
                            WHERE Id = @Id;";
                    }

                    // Clear parameters before re-adding them for the INSERT or UPDATE query
                    command.Parameters.Clear();

                    // Add all required parameters
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Barcode", product.Barcode);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@SupplierPrice", product.SupplierPrice);
                    command.Parameters.AddWithValue("@RetailPrice", product.RetailPrice);
                    command.Parameters.AddWithValue("@WholesalePrice", product.WholesalePrice);
                    command.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel);
                    command.Parameters.AddWithValue("@Remarks", product.Remarks ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsVat", product.IsVat);
                    command.Parameters.AddWithValue("@Status", product.Status);
                    command.Parameters.AddWithValue("@CategoryId", product.CategoryId);

                    await command.ExecuteNonQueryAsync();
                }
            );

        }

        public static async Task SyncLocations(string apiUrl, string authToken)
        {

            await SyncSingleDataFromApi<Locations>(
                apiUrl,
                authToken,
                "Locations",
                async (location, command) =>
                {
                    // Clear parameters at the beginning of each operation
                    command.Parameters.Clear();

                    // Check if the location already exists
                    string checkQuery = "SELECT COUNT(1) FROM Locations WHERE LocationId = @LocationId";
                    command.CommandText = checkQuery;
                    command.Parameters.AddWithValue("@LocationId", location.LocationId);

                    long count = (long)(await command.ExecuteScalarAsync());

                    if (count == 0)
                    {
                        command.CommandText = @"
                                            INSERT INTO Locations (LocationId, Name, Status)
                                            VALUES (@LocationId, @Name, @Status);";
                    }
                    else
                    {
                        command.CommandText = @"
                            UPDATE Locations
                            SET Name = @Name,
                                Status = @Status
                            WHERE LocationId = @LocationId;";
                    }

                    // Clear parameters before re-adding them for the INSERT or UPDATE query
                    command.Parameters.Clear();

                    // Add all required parameters
                    command.Parameters.AddWithValue("@LocationId", location.LocationId);
                    command.Parameters.AddWithValue("@Name", location.Name);
                    command.Parameters.AddWithValue("@Status", location.Status);

                    await command.ExecuteNonQueryAsync();
                }
            );
        }


        public static async Task SyncCategory(string apiUrl, string authToken)
        {

            await SyncDataFromApi<Category>(
                apiUrl,
                authToken,
                "Category",
                async (category, command) =>
                {
                    // Clear parameters at the beginning of each operation
                    command.Parameters.Clear();

                    // Check if the category already exists
                    string checkQuery = "SELECT COUNT(1) FROM Category WHERE CategoryId = @CategoryId";
                    command.CommandText = checkQuery;
                    command.Parameters.AddWithValue("@CategoryId", category.CategoryId);

                    long count = (long)(await command.ExecuteScalarAsync());

                    if (count == 0)
                    {
                        command.CommandText = @"
                                            INSERT INTO Category (CategoryId, Name, Status)
                                            VALUES (@CategoryId, @Name, @Status);";
                    }
                    else
                    {
                        command.CommandText = @"
                            UPDATE Category
                            SET Name = @Name,
                                Status = @Status
                            WHERE CategoryId = @CategoryId;";
                    }

                    // Clear parameters before re-adding them for the INSERT or UPDATE query
                    command.Parameters.Clear();

                    // Add all required parameters
                    command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                    command.Parameters.AddWithValue("@Name", category.Name);
                    command.Parameters.AddWithValue("@Status", category.Status);

                    await command.ExecuteNonQueryAsync();
                }
            );

        }

        public static async Task SyncInventory(string apiUrl, string authToken)
        {

            await SyncDataFromApi<Inventory>(
                apiUrl,
                authToken,
                "Inventory",
                async (inventory, command) =>
                {
                    // Clear parameters at the beginning of each operation
                    command.Parameters.Clear();

                    // Check if the inventory already exists
                    string checkQuery = "SELECT COUNT(1) FROM Inventory WHERE InventoryId = @InventoryId";
                    command.CommandText = checkQuery;
                    command.Parameters.AddWithValue("@InventoryId", inventory.InventoryId);

                    long count = (long)(await command.ExecuteScalarAsync());

                    if (count == 0)
                    {
                        command.CommandText = @"
                                            INSERT INTO Inventory (InventoryId, Specification, Units, ProductId, LocationId, Status)
                                            VALUES (@InventoryId, @Specification, @Units, @ProductId, @LocationId, @Status);";
                    }
                    else
                    {
                        command.CommandText = @"
                            UPDATE Inventory
                            SET Specification = @Specification,
                                Units = @Units,
                                ProductId = @ProductId, 
                                LocationId = @LocationId,
                                Status = @Status
                            WHERE InventoryId = @InventoryId;";
                    }

                    // Clear parameters before re-adding them for the INSERT or UPDATE query
                    command.Parameters.Clear();

                    // Add all required parameters
                    command.Parameters.AddWithValue("@InventoryId", inventory.InventoryId);
                    command.Parameters.AddWithValue("@Specification", inventory.Specification ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Units", inventory.Units);
                    command.Parameters.AddWithValue("@ProductId", inventory.ProductId);
                    command.Parameters.AddWithValue("@LocationId", inventory.LocationId);
                    command.Parameters.AddWithValue("@Status", inventory.Status);

                    await command.ExecuteNonQueryAsync();
                }
            );

        }

        public static async Task SyncDiscount(string apiUrl, string authToken)
        {

            await SyncDataFromApi<Discounts>(
                apiUrl,
                authToken,
                "Discounts",
                async (discounts, command) =>
                {
                    // Clear parameters at the beginning of each operation
                    command.Parameters.Clear();

                    // Check if the location already exists
                    string checkQuery = "SELECT COUNT(1) FROM Discounts WHERE DiscountId = @DiscountId";
                    command.CommandText = checkQuery;
                    command.Parameters.AddWithValue("@DiscountId", discounts.DiscountId);

                    long count = (long)(await command.ExecuteScalarAsync());

                    if (count == 0)
                    {
                        command.CommandText = @"
                                            INSERT INTO Discounts (DiscountId, Name, Percentage, Status)
                                            VALUES (@DiscountId, @Name, @Percentage, @Status);";
                    }
                    else
                    {
                        command.CommandText = @"
                            UPDATE Discounts
                            SET Name = @Name,
                                Percentage = @Percentage,
                                Status = @Status
                            WHERE DiscountId = @DiscountId;";
                    }

                    // Clear parameters before re-adding them for the INSERT or UPDATE query
                    command.Parameters.Clear();

                    // Add all required parameters
                    command.Parameters.AddWithValue("@DiscountId", discounts.DiscountId);
                    command.Parameters.AddWithValue("@Name", discounts.Name);
                    command.Parameters.AddWithValue("@Percentage", discounts.Percentage);
                    command.Parameters.AddWithValue("@Status", discounts.Status);

                    await command.ExecuteNonQueryAsync();
                }
            );

        }

        public static async Task SyncUser(string apiUrl, string authToken)
        {

            await SyncDataFromApi<Users>(
                apiUrl,
                authToken,
                "Users",
                async (user, command) =>
                {
                    // Clear parameters at the beginning of each operation
                    command.Parameters.Clear();

                    // Check if the product already exists
                    string checkQuery = "SELECT COUNT(1) FROM Users WHERE UserId = @UserId";
                    command.CommandText = checkQuery;
                    command.Parameters.AddWithValue("@UserId", user.Id);

                    long count = (long)(await command.ExecuteScalarAsync());

                    if (count == 0)
                    {
                        command.CommandText = @"
                                            INSERT INTO Users (UserId, LocationId, Username, Password, Name, IsRole, Status, Token)
                                            VALUES (@UserId, @LocationId, @Username, @Password, @Name, @IsRole, @Status, @Token);";
                    }
                    else
                    {
                        command.CommandText = @"
                            UPDATE Users
                            SET 
                                Name = @Name,
                                Username = @Username,
                                Password = @Password,   
                                IsRole = @IsRole,
                                Token = @Token,
                                Status = @Status,
                                LocationId = @LocationId
                            WHERE UserId = @UserId;";
                    }

                    // Clear parameters before re-adding them for the INSERT or UPDATE query
                    command.Parameters.Clear();

                    // Add all required parameters
                    command.Parameters.AddWithValue("@UserId", user.Id);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@IsRole", user.IsRole);
                    command.Parameters.AddWithValue("@Token", user.Token);
                    command.Parameters.AddWithValue("@Status", user.Status);
                    command.Parameters.AddWithValue("@LocationId", user.LocationId);
                }
            );

        }

        public static List<Inventory> LoadInventoryList()
        {
            List<Inventory> inventoryList = new List<Inventory>();

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    I.InventoryId,
                    I.Specification,
                    I.Units,
                    I.ProductId,
                    I.LocationId,
                    I.Status,
                    I.DateCreated
                FROM Inventory I;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                inventoryList.Add(new Inventory
                                {
                                    InventoryId = reader.GetInt32(reader.GetOrdinal("InventoryId")),
                                    Specification = reader.IsDBNull(reader.GetOrdinal("Specification"))
                                ? string.Empty // Handle NULL values safely
                                : reader.GetString(reader.GetOrdinal("Specification")),
                                    Units = reader.GetInt32(reader.GetOrdinal("Units")),
                                    ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                                    LocationId = reader.GetInt32(reader.GetOrdinal("LocationId")),
                                    Status = reader.GetInt32(reader.GetOrdinal("Status")),
                                    DateCreated = reader.IsDBNull(reader.GetOrdinal("DateCreated")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DateCreated"))
                                });
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching LoadInventoryList: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return inventoryList;
        }

        public static Products GetRetailedProductById(int productId)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT Id, Barcode, Name, Description, RetailPrice, IsVat 
                        FROM Products 
                        WHERE Id = @Id;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", productId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Map database row to Product object
                                return new Products
                                {
                                    Id = reader.GetInt32(0),
                                    Barcode = reader.GetString(1),
                                    Name = reader.GetString(2),
                                    Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    RetailPrice = reader.GetDecimal(4),
                                    IsVat = reader.GetInt32(5) // Check if IsVat is 1
                                };
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching GetRetailedProductById: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public static Products GetWholesaleProductById(int productId)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT Id, Barcode, Name, Description, WholesalePrice, IsVat 
                        FROM Products 
                        WHERE Id = @Id;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", productId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Map database row to Product object
                                return new Products
                                {
                                    Id = reader.GetInt32(0),
                                    Barcode = reader.GetString(1),
                                    Name = reader.GetString(2),
                                    Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    WholesalePrice = reader.GetDecimal(4),
                                    IsVat = reader.GetInt32(5) // Check if IsVat is 1
                                };
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching GetWholesaleProductById: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public static DataTable GetAllDiscounts()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            DiscountId,
                            Name, 
                            Percentage, 
                            Status, 
                            DateCreated
                        FROM Discounts;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching GetAllDiscounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }


        public static void SaveHoldProducts(List<Cart> carts, int refId)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();

                string query = @"
            INSERT INTO HoldProducts 
            (ReferenceId, ProductId, Barcode, Name, Description, Price, Quantity, VatAmount, SubTotal, AppliedDiscount, 
             TotalDiscount, DiscountId, IsVat, HasDiscountApplied, DiscountPercentage) 
            VALUES 
            (@ReferenceId, @ProductId, @Barcode, @Name, @Description, @Price, @Quantity, @VatAmount, @SubTotal, @AppliedDiscount, 
             @TotalDiscount, @DiscountId, @IsVat, @HasDiscountApplied, @DiscountPercentage)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    foreach (var cart in carts)
                    {
                        // Add parameters to the query
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ReferenceId", refId);
                        command.Parameters.AddWithValue("@ProductId", cart.Id);
                        command.Parameters.AddWithValue("@Barcode", cart.Barcode ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Name", cart.Name ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Description", cart.Description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Price", cart.Price);
                        command.Parameters.AddWithValue("@Quantity", cart.Quantity);
                        command.Parameters.AddWithValue("@VatAmount", cart.VatAmount);
                        command.Parameters.AddWithValue("@SubTotal", cart.SubTotal);
                        command.Parameters.AddWithValue("@AppliedDiscount", cart.AppliedDiscount);
                        command.Parameters.AddWithValue("@TotalDiscount", cart.TotalDiscount);
                        command.Parameters.AddWithValue("@DiscountId", cart.DiscountId);
                        command.Parameters.AddWithValue("@IsVat", cart.IsVat);
                        command.Parameters.AddWithValue("@HasDiscountApplied", cart.HasDiscountApplied ? 1 : 0);
                        command.Parameters.AddWithValue("@DiscountPercentage", cart.DiscountPercentage);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }

        public static void SaveHoldSale(int refId, int employeeId)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();

                string query = @"
                    INSERT INTO HoldOrders 
                    (ReferenceId, EmployeeId) 
                    VALUES 
                    (@ReferenceId, @EmployeeId)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@ReferenceId", refId);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    // Execute the query
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static DataTable GetAllHoldSale()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            ReferenceId,
                            EmployeeId, 
                            DateCreated
                        FROM HoldOrders;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        public static void DeleteAllHoldProduct()
        {
            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();

                string query = "DELETE FROM HoldProducts";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Execute the delete query
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static void DeleteAllHoldSale()
        {
            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();

                string query = "DELETE FROM HoldOrders";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Execute the delete query
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static void DeleteHoldProductByRefId(int refId)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();

                string query = $"DELETE FROM HoldOrders WHERE ReferenceId = {refId}";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Execute the delete query
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static void DeleteHoldSaleByRefId(int refId)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();

                string query = $"DELETE FROM HoldProducts WHERE ReferenceId = {refId}";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Execute the delete query
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static List<Cart> GetAllHoldOrdersByRefId(int refId)
        {
            var holdOrders = new List<Cart>();

            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();

                string query = $"SELECT * FROM HoldProducts WHERE ReferenceId = {refId}";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Map the database row to a Cart object
                            var cart = new Cart
                            {
                                Id = Convert.ToInt32(reader["ProductId"]),
                                Barcode = reader["Barcode"] != DBNull.Value ? reader["Barcode"].ToString() : null,
                                Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null,
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                VatAmount = Convert.ToDecimal(reader["VatAmount"]),
                                SubTotal = Convert.ToDecimal(reader["SubTotal"]),
                                AppliedDiscount = Convert.ToDecimal(reader["AppliedDiscount"]),
                                TotalDiscount = Convert.ToDecimal(reader["TotalDiscount"]),
                                DiscountId = reader["DiscountId"] != DBNull.Value ? Convert.ToInt32(reader["DiscountId"]) : 0,
                                IsVat = Convert.ToInt32(reader["IsVat"]),
                                HasDiscountApplied = Convert.ToBoolean(reader["HasDiscountApplied"]),
                                DiscountPercentage = Convert.ToDecimal(reader["DiscountPercentage"])
                            };

                            holdOrders.Add(cart);
                        }
                    }
                }

                connection.Close();
            }
            return holdOrders;
        }

        public static DataTable GetRetailedProduct()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT Id, Barcode, Name, Description, RetailPrice 
                        FROM Products";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        public static DataTable GetRetailedProductByBarcode(string filter)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT Id, Barcode, Name, Description, RetailPrice 
                        FROM Products WHERE Barcode LIKE @Filter || '%'";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Add filter parameter to prevent SQL injection
                        command.Parameters.AddWithValue("@Filter", filter);
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        public static DataTable GetRetailedProductByName(string filter)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT Id, Barcode, Name, Description, RetailPrice 
                        FROM Products WHERE Name LIKE @Filter || '%'";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Filter", filter);
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        public static DataTable GetWholesaleProduct()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT Id, Barcode, Name, Description, WholesalePrice 
                        FROM Products";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        public static DataTable GetWholesaleProductByBarcode(string filter)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT Id, Barcode, Name, Description, WholesalePrice 
                        FROM Products WHERE Barcode LIKE @Filter || '%'";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Filter", filter);
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        public static DataTable GetWholesaleProductByName(string filter)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT Id, Barcode, Name, Description, WholesalePrice 
                        FROM Products WHERE Name LIKE @Filter || '%'";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Filter", filter);
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }


        public static DataTable GetEmployeeByUserIdAndLocationId(int userId, int locationId)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT UserId, LocationId, Name, IsRole, Status 
                        FROM Users WHERE UserId = @UserId AND LocationId = @LocationId";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@LocationId", locationId);
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }
        public static int GetCashDrawerCountByUserId(int userId)
        {
            int count = 0;

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                SELECT Count(*)
                FROM CashDrawer WHERE UserId = @UserId";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Execute the query and get the count
                        count = Convert.ToInt32(command.ExecuteScalar());
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return count;
        }

        public static void InsertCashDrawerEntry(int drawerId, int userId, int locationId, decimal initialCash, decimal withdrawals, decimal expenses, decimal drawerCash, DateTime timeStart)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                INSERT INTO CashDrawer (DrawerId, UserId, LocationId, InitialCash, Withdrawals, Expenses, DrawerCash, TimeStart, TimeEnd, Status)
                VALUES (@DrawerId, @UserId, @LocationId, @InitialCash, @Withdrawals, @Expenses, @DrawerCash, @TimeStart, @TimeEnd, @Status)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@DrawerId", drawerId);
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@LocationId", locationId);
                        command.Parameters.AddWithValue("@InitialCash", initialCash);
                        command.Parameters.AddWithValue("@Withdrawals", withdrawals);
                        command.Parameters.AddWithValue("@Expenses", expenses);
                        command.Parameters.AddWithValue("@DrawerCash", drawerCash);
                        command.Parameters.AddWithValue("@TimeStart", timeStart);
                        command.Parameters.AddWithValue("@TimeEnd", DBNull.Value); // TimeEnd is set to NULL initially
                        command.Parameters.AddWithValue("@Status", 1); // Status 1 for 'Active' (you can adjust this logic as needed)

                        // Execute the insert query
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting cash drawer entry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
