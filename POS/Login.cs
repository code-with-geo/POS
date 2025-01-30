using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IdentityModel.Tokens.Jwt;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace POS
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        private static readonly string FolderPath = @"C:\POS";
        private static readonly string DbPath = Path.Combine(FolderPath, "POS.sqlite");
        private readonly HttpClient _httpClient;
        public int UserId { get; private set; }
        public int LocationId { get; private set; }
        public string Token { get; private set; }
        public Login()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists(DbPath))
            {
                DatabaseHelper.CreateDatabase();
            }

            if (File.Exists(DbPath))
            {
                if (AuthenticateUserLocally(username,password))
                {
                    var (userId, token, locationId) = GetUserAndToken(username, password);
                    UserId = Convert.ToInt32(userId);
                    LocationId = Convert.ToInt32(locationId);
                    if (!string.IsNullOrEmpty(token) && token != "" && IsTokenExpired(token))
                    {

                        string users = $"https://localhost:7148/api/auth/locations/{locationId}";
                        string products = "https://localhost:7148/api/products";
                        string category = "https://localhost:7148/api/category";
                        string inventory = $"https://localhost:7148/api/inventory/pos?locationId={locationId}";
                        string discount = "https://localhost:7148/api/discounts";
                            await DatabaseHelper.SyncUser(users, Token);
                            await DatabaseHelper.SyncProducts(products, Token);
                            await DatabaseHelper.SyncCategory(category, Token);
                            await DatabaseHelper.SyncInventory(inventory, Token);
                            await DatabaseHelper.SyncDiscount(discount, Token);
                            OpenMainForm();
                    }
                    else
                    {
                        var response = await AuthenticateUserViaAPI(username, password);
                        if (!string.IsNullOrEmpty(response.Token))
                        {
                            UserId = Convert.ToInt32(response.UserId);
                            UpdateToken(Convert.ToInt32(response.UserId), response.Token);
                            OpenMainForm();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    var response = await AuthenticateUserViaAPI(username, password);

                    if (!string.IsNullOrEmpty(response.Token))
                    {
                        UserId = Convert.ToInt32(response.UserId);
                        UpdateToken(Convert.ToInt32(response.UserId), response.Token);
                        OpenMainForm();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (!IsInternetAvailable())
            {
                if (AuthenticateUserLocally(username, password))
                {
                    OpenMainForm();
                }
                else
                {
                    MessageBox.Show("User not found in local database. Please check your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var response = await AuthenticateUserViaAPI(username, password);

                if (!string.IsNullOrEmpty(response.Token))
                {
                    UserId = Convert.ToInt32(response.UserId);
                    UpdateToken(Convert.ToInt32(response.UserId),response.Token);
                    OpenMainForm();
                }
                else
                {
                    MessageBox.Show("Invalid username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private bool IsTokenExpired(string token)
        {
            try
            {
                // Decode the token
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // Extract the expiration time (exp) claim
                var expClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "exp")?.Value;

                if (long.TryParse(expClaim, out long expTimestamp))
                {
                    // Convert the expiration time from Unix time to DateTime
                    var expirationTime = DateTimeOffset.FromUnixTimeSeconds(expTimestamp).UtcDateTime;

                    // Compare with the current UTC time
                    return DateTime.UtcNow >= expirationTime;
                }

                // If no exp claim is found or parsing fails, assume the token is invalid
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error decoding token: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Treat as expired in case of error
            }
        }

        public static void UpdateToken(int userId, string token)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
            {
                connection.Open();

                string query = @"
                UPDATE Users SET Token= @Token
                WHERE UserId = @UserId;";


                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Token", token);
                    command.Parameters.AddWithValue("@UserId", userId);
                    // Execute the query
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private void OpenMainForm()
        {
            Main mainForm = new Main(UserId,LocationId);
            mainForm.Show();
            this.Hide(); // Hide the login form
        }

        private bool IsInternetAvailable()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool IsLocation(string loctionid)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = "SELECT COUNT(1) FROM Locations WHERE LocationId = @LocationId";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LocationId", loctionid);

                        var result = Convert.ToInt32(command.ExecuteScalar());
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on IsLocation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool AuthenticateUserLocally(string username,string password)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        var result = Convert.ToInt32(command.ExecuteScalar());
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on AuthenticateUserLocally: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private (string UserId, string Token, int LocationId) GetUserAndToken(string username, string password)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = "SELECT UserId, Token, LocationId FROM Users WHERE Username = @Username AND Password = @Password";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userId = reader["UserId"].ToString();
                                string token = reader["Token"].ToString();
                                int locationId = reader["LocationId"] != DBNull.Value ? Convert.ToInt32(reader["LocationId"]) : 0;

                                return (userId, token, locationId);
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return ("", "", 0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on AuthenticateUserLocally: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ("", "", 0);
            }
        }

        private async Task<(string Token, string UserId)> AuthenticateUserViaAPI(string username, string password)
        {
            try
            {
                // Your API endpoint for login
                string apiUrl = $"https://localhost:7148/api/auth/login?username={username}&password={password}";
                

                // Create the login request payload (usually a JSON object)
                var loginData = new
                {
                    Username = username,
                    Password = password
                };

                // Serialize the login data to JSON
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send the POST request to the API
                var response = await _httpClient.PostAsync(apiUrl, content);

                // Check if the request was successful (status code 200-299)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content (usually contains the token in JSON format)
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Assuming the response is a JSON object with a "token" property
                    var responseObject = JsonConvert.DeserializeObject<ApiResponse>(responseContent);

                    if (responseObject != null && !string.IsNullOrEmpty(responseObject.Token))
                    {
                        if (!IsLocation(responseObject.LocationId))
                        {
                            LocationId = Convert.ToInt32(responseObject.LocationId);
                            string locations = $"https://localhost:7148/api/locations/{responseObject.LocationId}";
                            string users = $"https://localhost:7148/api/auth/locations/{responseObject.LocationId}";
                            string products = "https://localhost:7148/api/products";
                            string category = "https://localhost:7148/api/category";
                            string inventory = $"https://localhost:7148/api/inventory/pos?locationId={responseObject.LocationId}";
                            string discount = "https://localhost:7148/api/discounts";

                            await DatabaseHelper.SyncUser(users, responseObject.Token);
                            await DatabaseHelper.SyncLocations(locations, responseObject.Token);
                            await DatabaseHelper.SyncProducts(products, responseObject.Token);
                            await DatabaseHelper.SyncCategory(category, responseObject.Token);
                            await DatabaseHelper.SyncInventory(inventory, responseObject.Token);
                            await DatabaseHelper.SyncDiscount(discount, responseObject.Token);
                        }
                        else
                        {
                            LocationId = Convert.ToInt32(responseObject.LocationId);
                            string locations = $"https://localhost:7148/api/locations/{responseObject.LocationId}";
                            string users = $"https://localhost:7148/api/auth/locations/{responseObject.LocationId}";
                            string products = "https://localhost:7148/api/products";
                            string category = "https://localhost:7148/api/category";
                            string inventory = $"https://localhost:7148/api/inventory/pos?locationId={responseObject.LocationId}";
                            string discount = "https://localhost:7148/api/discounts";

                            await DatabaseHelper.SyncUser(users, responseObject.Token);
                            await DatabaseHelper.SyncProducts(products, responseObject.Token);
                            await DatabaseHelper.SyncCategory(category, responseObject.Token);
                            await DatabaseHelper.SyncInventory(inventory, responseObject.Token);
                            await DatabaseHelper.SyncDiscount(discount, responseObject.Token);
                        }

                        return (responseObject.Token, responseObject.UserId); // Return the token
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on AuthenticateUserAsync: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (null, null); // Return null if authentication failed or an error occurred
        }

        public class ApiResponse
        {
            [JsonProperty("Token")]
            public string Token { get; set; }

            [JsonProperty("UserId")]
            public string UserId { get; set; }

            [JsonProperty("LocationId")]
            public string LocationId { get; set; }
        }

    }
}
