using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using POS.Classes;

namespace POS
{
    public partial class NewCustomer : MetroFramework.Forms.MetroForm
    {
        public string Token { get; private set; }
        public NewCustomer(string token)
        {
            InitializeComponent();
            Token = token;
        }

        private void NewCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public async Task InsertCustomer()
        {
            // Create a new customer object and get data from textboxes
            Customers customer = new Customers
            {
                // Get the values from the textboxes
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                ContactNo = txtContactNo.Text,
                Email = txtEmail.Text,
                TransactionCount = 0,
                Points = 0,
                Status = 1,
                DateCreated = DateTime.Now
            };

            // Generate a random 8-digit AccountId
            Random random = new Random();
            customer.AccountId = random.Next(10000000, 99999999);
            customer.CardNumber = "CN-" + random.Next(10000000, 99999999).ToString();

            // API URL
            string apiUrl = "https://localhost:7148/api/customers"; // Replace with your actual API endpoint

            using (HttpClient client = new HttpClient())
            {
                // Set the authorization header with your token (replace "your_token_here")
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                // Convert the customer object to JSON
                string jsonContent = JsonConvert.SerializeObject(customer);

                // Create the HttpContent object
                StringContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // If successful, you can read the response content or handle it as needed
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Customer created successfully: {responseBody}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Handle errors
                    MessageBox.Show($"Error: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("First name and last name is required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Prevent the InsertCustomer method from running if validation fails
            }
            InsertCustomer();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
