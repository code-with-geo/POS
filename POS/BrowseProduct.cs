using POS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace POS
{
    public partial class BrowseProduct : MetroFramework.Forms.MetroForm
    {
        public bool IsRetail { get; private set; }
        public int ProductId { get; private set; }
        public BrowseProduct(bool isRetail)
        {
            InitializeComponent();
            IsRetail = isRetail;
            this.BackColor = Color.Red;
        }

        private void BrowseProduct_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Z: // Move to the previous row
                case Keys.X: // Move to the next row
                    if (!dgvProducts.Focused)
                    {
                        dgvProducts.Focus();
                    }

                    int currentRowIndex = dgvProducts.CurrentCell?.RowIndex ?? 0; // Get the current row index
                    int totalRows = dgvProducts.Rows.Count;

                    if (e.KeyCode == Keys.X) // Move to the next row
                    {
                        if (currentRowIndex < totalRows - 1)
                        {
                            dgvProducts.CurrentCell = dgvProducts.Rows[currentRowIndex + 1].Cells[1];
                        }
                        else
                        {
                            // Optional: Wrap around to the first row
                            dgvProducts.CurrentCell = dgvProducts.Rows[0].Cells[1];
                        }
                    }
                    else if (e.KeyCode == Keys.Z) // Move to the previous row
                    {
                        if (currentRowIndex > 0)
                        {
                            dgvProducts.CurrentCell = dgvProducts.Rows[currentRowIndex - 1].Cells[1];
                        }
                        else
                        {
                            // Optional: Wrap around to the last row
                            dgvProducts.CurrentCell = dgvProducts.Rows[totalRows - 1].Cells[1];
                        }
                    }

                    e.Handled = true; // Prevent further handling of the key event
                    e.SuppressKeyPress = true; // Suppress the key press
                    break;
            }
        }

        private void BrowseProduct_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            // Fetch data from the database
            DataTable productsTable = IsRetail ? DatabaseHelper.GetRetailedProduct() : DatabaseHelper.GetWholesaleProduct();

            // Clear existing columns
            dgvProducts.Columns.Clear();

            // Set DataGridView properties
            dgvProducts.ColumnHeadersVisible = true;
            dgvProducts.AutoGenerateColumns = false;

            // Add Id column (hidden)
            dgvProducts.Columns.Add("Id", "Id");
            dgvProducts.Columns["Id"].DataPropertyName = "Id";
            dgvProducts.Columns["Id"].Visible = false; // Hide the column

            // Add Barcode column
            dgvProducts.Columns.Add("Barcode", "Barcode");
            dgvProducts.Columns["Barcode"].DataPropertyName = "Barcode";

            // Add Name column
            dgvProducts.Columns.Add("Name", "Name");
            dgvProducts.Columns["Name"].DataPropertyName = "Name";

            // Add RetailPrice column (Price)
            dgvProducts.Columns.Add(IsRetail ? "RetailPrice" : "WholesalePrice", "Price");
            dgvProducts.Columns[IsRetail ? "RetailPrice" : "WholesalePrice"].DataPropertyName = IsRetail ? "RetailPrice" : "WholesalePrice";

            //// Add Quantity column
            //dgvProducts.Columns.Add("Quantity", "Quantity");
            //dgvProducts.Columns["Quantity"].DataPropertyName = "Quantity";

            // Add Remove button column
            // Add a Remove button column with an image
            DataGridViewImageColumn removeButtonColumn = new DataGridViewImageColumn();
            removeButtonColumn.Name = "Select";
            removeButtonColumn.HeaderText = "Select";
            removeButtonColumn.Image = Properties.Resources.trash; // Replace with your image resource
            removeButtonColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust layout if needed
            dgvProducts.Columns.Add(removeButtonColumn);

            // Bind the DataTable to the DataGridView
            dgvProducts.DataSource = productsTable;

            // Format columns for currency
            dgvProducts.Columns[IsRetail ? "RetailPrice" : "WholesalePrice"].DefaultCellStyle.Format = "C2";
            dgvProducts.Columns["Barcode"].ReadOnly = true;
            dgvProducts.Columns[IsRetail ? "RetailPrice" : "WholesalePrice"].ReadOnly = true;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell is within valid bounds
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Check if the clicked column is the "Select" button column
                if (dgvProducts.Columns[e.ColumnIndex].Name == "Select")
                {
                    // Retrieve the Product Id from the clicked row
                    string productId = dgvProducts.Rows[e.RowIndex].Cells["Id"].Value.ToString();

                    // Display or use the Product Id (you can replace this with your desired logic)
                    MessageBox.Show($"Selected Product Id: {productId}", "Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvProducts_KeyDown(object sender, KeyEventArgs e)
        {

            // Check if the Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                // Ensure the current cell and row index are valid
                if (dgvProducts.CurrentCell != null && dgvProducts.CurrentCell.RowIndex >= 0)
                {
                    int rowIndex = dgvProducts.CurrentCell.RowIndex;

                    // Retrieve the Product Id from the current row
                    string productId = dgvProducts.Rows[rowIndex].Cells["Id"].Value.ToString();

                    ProductId = Convert.ToInt32(productId);
                    this.DialogResult = DialogResult.OK; // Close with success
                    this.Close();
                    // Prevent the default behavior of the Enter key (e.g., moving to the next row)
                    e.Handled = true;
                }
            }

            // Handle 'X' and 'Z' keys for row navigation
            if (e.KeyCode == Keys.X || e.KeyCode == Keys.Z)
            {
                // Check if cart is empty before proceeding
                if (dgvProducts.Rows.Count == 0)
                {
                    MessageBox.Show("The cart is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                e.Handled = true;     // Prevent default behavior
                e.SuppressKeyPress = true; // Suppress keypress to avoid triggering editing

                // Ensure there is a current cell and rows are present
                if (dgvProducts.CurrentCell == null || dgvProducts.Rows.Count == 0)
                {
                    MessageBox.Show("No rows to navigate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int currentRowIndex = dgvProducts.CurrentCell.RowIndex;
                int totalRows = dgvProducts.Rows.Count;

                if (e.KeyCode == Keys.X) // Move to the next row
                {
                    if (currentRowIndex < totalRows - 1)
                    {
                        dgvProducts.CurrentCell = dgvProducts.Rows[currentRowIndex + 1].Cells[1];
                    }
                    else
                    {
                        // Optional: Wrap around to the first row
                        dgvProducts.CurrentCell = dgvProducts.Rows[0].Cells[1];
                    }
                }
                else if (e.KeyCode == Keys.Z) // Move to the previous row
                {
                    if (currentRowIndex > 0)
                    {
                        dgvProducts.CurrentCell = dgvProducts.Rows[currentRowIndex - 1].Cells[1];
                    }
                    else
                    {
                        // Optional: Wrap around to the last row
                        dgvProducts.CurrentCell = dgvProducts.Rows[totalRows - 1].Cells[1];
                    }
                }
            }
        }

        private void RefreshDataGridViewFilter(DataTable dt)
        {
            // Clear existing columns
            dgvProducts.Columns.Clear();

            // Set DataGridView properties
            dgvProducts.ColumnHeadersVisible = true;
            dgvProducts.AutoGenerateColumns = false;

            // Add Id column (hidden)
            dgvProducts.Columns.Add("Id", "Id");
            dgvProducts.Columns["Id"].DataPropertyName = "Id";
            dgvProducts.Columns["Id"].Visible = false; // Hide the column

            // Add Barcode column
            dgvProducts.Columns.Add("Barcode", "Barcode");
            dgvProducts.Columns["Barcode"].DataPropertyName = "Barcode";

            // Add Name column
            dgvProducts.Columns.Add("Name", "Name");
            dgvProducts.Columns["Name"].DataPropertyName = "Name";

            // Add RetailPrice column (Price)
            dgvProducts.Columns.Add(IsRetail ? "RetailPrice" : "WholesalePrice", "Price");
            dgvProducts.Columns[IsRetail ? "RetailPrice" : "WholesalePrice"].DataPropertyName = IsRetail ? "RetailPrice" : "WholesalePrice";

            //// Add Quantity column
            //dgvProducts.Columns.Add("Quantity", "Quantity");
            //dgvProducts.Columns["Quantity"].DataPropertyName = "Quantity";

            // Add Remove button column
            // Add a Remove button column with an image
            DataGridViewImageColumn removeButtonColumn = new DataGridViewImageColumn();
            removeButtonColumn.Name = "Select";
            removeButtonColumn.HeaderText = "Select";
            removeButtonColumn.Image = Properties.Resources.trash; // Replace with your image resource
            removeButtonColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust layout if needed
            dgvProducts.Columns.Add(removeButtonColumn);

            // Bind the DataTable to the DataGridView
            dgvProducts.DataSource = dt;

            // Format columns for currency
            dgvProducts.Columns[IsRetail ? "RetailPrice" : "WholesalePrice"].DefaultCellStyle.Format = "C2";
            dgvProducts.Columns["Barcode"].ReadOnly = true;
            dgvProducts.Columns[IsRetail ? "RetailPrice" : "WholesalePrice"].ReadOnly = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Get the text from the search box
            string searchText = txtSearch.Text.Trim();

            // Fetch data based on the search text
            DataTable dt = IsRetail ? DatabaseHelper.GetRetailedProduct() : DatabaseHelper.GetWholesaleProduct();


            if (string.IsNullOrEmpty(searchText))
            {
                RefreshDataGridViewFilter(dt);
            }
            else
            {
                if (cbKeys.SelectedIndex == 0)
                {
                    dt = IsRetail ? DatabaseHelper.GetRetailedProductByName(searchText) : DatabaseHelper.GetWholesaleProductByName(searchText);
                    dgvProducts.DataSource = null;
                    RefreshDataGridViewFilter(dt);
                }
                else
                {
                    dt = IsRetail ? DatabaseHelper.GetRetailedProductByBarcode(searchText) : DatabaseHelper.GetWholesaleProductByBarcode(searchText);
                    dgvProducts.DataSource = null;
                    RefreshDataGridViewFilter(dt);
                }

            }
        }
    }
}
