using Guna.UI2.WinForms;
using Newtonsoft.Json.Linq;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Customer : MetroFramework.Forms.MetroForm
    {
        public int UserId { get; private set; }
        public int LocationId { get; private set; }
        public int CustomerId { get; private set; }
        public string Token { get; private set; }

        private BindingSource bindingSource = new BindingSource();
        private List<Customers> allCustomers = new List<Customers>();
        public Customer(int userId, int locationId)
        {
            InitializeComponent();
            UserId = userId;
            LocationId = locationId;
        }

        private void Customer_KeyDown(object sender, KeyEventArgs e)
        {
            // Prevent function from running if a TextBox is focused
            if (ActiveControl is Guna2TextBox)
                return;

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Z: // Move to the previous row
                case Keys.X: // Move to the next row
                    if (!dgvCustomer.Focused)
                    {
                        dgvCustomer.Focus();
                    }

                    int currentRowIndex = dgvCustomer.CurrentCell?.RowIndex ?? 0; // Get the current row index
                    int totalRows = dgvCustomer.Rows.Count;

                    if (e.KeyCode == Keys.X) // Move to the next row
                    {
                        if (currentRowIndex < totalRows - 1)
                        {
                            dgvCustomer.CurrentCell = dgvCustomer.Rows[currentRowIndex + 1].Cells[1];
                        }
                        else
                        {
                            // Optional: Wrap around to the first row
                            dgvCustomer.CurrentCell = dgvCustomer.Rows[0].Cells[1];
                        }
                    }
                    else if (e.KeyCode == Keys.Z) // Move to the previous row
                    {
                        if (currentRowIndex > 0)
                        {
                            dgvCustomer.CurrentCell = dgvCustomer.Rows[currentRowIndex - 1].Cells[1];
                        }
                        else
                        {
                            // Optional: Wrap around to the last row
                            dgvCustomer.CurrentCell = dgvCustomer.Rows[totalRows - 1].Cells[1];
                        }
                    }

                    e.Handled = true; // Prevent further handling of the key event
                    e.SuppressKeyPress = true; // Suppress the key press
                    break;
                case Keys.N:
                    NewCustomer customer = new NewCustomer(Token);
                    customer.ShowDialog();
                    break;
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            var customer = new NewCustomer(Token);
            var result = customer.ShowDialog();
            if (result == DialogResult.OK)
            {
                RefreshDataGridView(Token);
            }
        }


        private async void RefreshDataGridView(string token)
        {
            allCustomers = await DatabaseHelper.GetAllCustomersAsync(token);
            bindingSource.DataSource = allCustomers;

            dgvCustomer.Columns.Clear();
            dgvCustomer.ColumnHeadersVisible = true;
            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.DataSource = bindingSource;

            dgvCustomer.Columns.Add("CustomerId", "CustomerId");
            dgvCustomer.Columns["CustomerId"].DataPropertyName = "CustomerId";
            dgvCustomer.Columns["CustomerId"].Visible = false; // Hide the column

            dgvCustomer.Columns.Add("AccountId", "Account Id");
            dgvCustomer.Columns["AccountId"].DataPropertyName = "AccountId";

            dgvCustomer.Columns.Add("FirstName", "First Name");
            dgvCustomer.Columns["FirstName"].DataPropertyName = "FirstName";

            dgvCustomer.Columns.Add("LastName", "Last Name");
            dgvCustomer.Columns["LastName"].DataPropertyName = "LastName";

            dgvCustomer.Columns.Add("ContactNo", "Contact No.");
            dgvCustomer.Columns["ContactNo"].DataPropertyName = "ContactNo";

            dgvCustomer.Columns.Add("Email", "Email");
            dgvCustomer.Columns["Email"].DataPropertyName = "Email";

            DataGridViewImageColumn selectButton = new DataGridViewImageColumn();
            selectButton.Name = "Select";
            selectButton.HeaderText = "Select";
            selectButton.Image = Properties.Resources.attach_1; // Replace with your image resource
            selectButton.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust layout if needed
            dgvCustomer.Columns.Add(selectButton);
        }

        private void FilterCustomer()
        {
            if (cbKeys.SelectedItem == null || string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                bindingSource.DataSource = allCustomers; // Reset if empty
            }
            else
            {
                // Dictionary to map displayed column names to actual property names in Customers class
                Dictionary<string, string> columnMappings = new Dictionary<string, string>
                {
                    { "Account Id", "AccountId" },
                    { "First Name", "FirstName" },
                    { "Last Name", "LastName" },
                    { "Contact No.", "ContactNo" },
                    { "Email", "Email" }
                };

                string selectedColumn = cbKeys.SelectedItem.ToString();

                if (columnMappings.ContainsKey(selectedColumn))
                {
                    string propertyName = columnMappings[selectedColumn];
                    string filterValue = txtSearch.Text.ToLower();

                    bindingSource.DataSource = allCustomers
                        .Where(c =>
                            typeof(Customers).GetProperty(propertyName)
                            ?.GetValue(c, null)?.ToString().ToLower().Contains(filterValue) == true)
                        .ToList();
                }
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data = DatabaseHelper.GetEmployeeByUserIdAndLocationId(UserId, LocationId);
            if (data.Rows.Count > 0)
            {
                Token = data.Rows[0]["Token"].ToString();
                RefreshDataGridView(Token);
            }
        }

        private void cbKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterCustomer();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterCustomer();
        }

        private void dgvCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevents the default Enter key behavior

                if (dgvCustomer.CurrentRow != null)
                {
                    // Get CustomerId from the selected row
                    string customerId = dgvCustomer.CurrentRow.Cells["CustomerId"].Value?.ToString();

                    if (!string.IsNullOrEmpty(customerId))
                    {
                        CustomerId = int.Parse(customerId);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomer.Columns[e.ColumnIndex].Name == "Select")
            {
                // Get CustomerId from the selected row
                string customerId = dgvCustomer.CurrentRow.Cells["CustomerId"].Value?.ToString();

                if (!string.IsNullOrEmpty(customerId))
                {
                    CustomerId = int.Parse(customerId);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
