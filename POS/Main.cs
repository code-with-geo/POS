using Newtonsoft.Json.Linq;
using POS.Classes;
using System.ComponentModel;
using System.Data;

namespace POS
{
    public partial class Main : Form
    {
        private static readonly string FolderPath = @"C:\POS";
        private static readonly string DbPath = Path.Combine(FolderPath, "POS.sqlite");
        private List<Cart> cart = new List<Cart>();
        private List<Inventory> inventoryList = new List<Inventory>();
        public int UserId { get; private set; }
        public int LocationId { get; private set; }
        public int CustomerId { get; private set; }
        private static bool isRetail = true;
        public Main(int userId,int locationId)
        {
            InitializeComponent();
            UserId = userId;
            LocationId = locationId;
        }

        private void DisplayTotalAmount()
        {
            // Check if the cart has items
            decimal totalSubTotal = cart.Any() ? cart.Sum(p => p.SubTotal) : 0;
            lblTotalAmount.Text = totalSubTotal.ToString("C2");
            lblTopTotalAmount.Text = totalSubTotal.ToString("C2");
        }

        private void DisplayVatSale()
        {
            // Check if the cart has items with VAT
            decimal vatInclusiveTotal = cart.Any(p => p.IsVat == 1) ? cart.Where(p => p.IsVat == 1).Sum(p => p.SubTotal) : 0;
            lblVatSale.Text = vatInclusiveTotal.ToString("C2");
        }

        private void DisplayVatAmount()
        {
            // Check if the cart has items
            decimal VatAmount = cart.Any() ? cart.Sum(p => p.VatAmount) : 0;
            lblVatAmount.Text = VatAmount.ToString("C2");
        }

        private void DisplayVatExempt()
        {
            // Check if the cart has VAT-exempt items
            decimal VatExempt = cart.Any(p => p.IsVat == 0) ? cart.Where(p => p.IsVat == 0).Sum(p => p.SubTotal) : 0;
            lblVatExempt.Text = VatExempt.ToString("C2");
        }

        private void DisplayTotalDiscount()
        {
            // Check if the cart has discounts applied
            decimal TotalDiscount = cart.Any(d => d.HasDiscountApplied) ? cart.Where(d => d.HasDiscountApplied).Sum(d => d.TotalDiscount) : 0;
            lblDiscount.Text = TotalDiscount.ToString("C2");
        }

        private void RefreshDataGridView()
        {
            //DataGridView Properties
            dgvCart.ColumnHeadersVisible = true;
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            // Add columns and bind to properties

            // Add Barcode column to DataGridView
            dgvCart.Columns.Add("Barcode", "Barcode");
            dgvCart.Columns["Barcode"].DataPropertyName = "Barcode";

            // Add Name column to DataGridView
            dgvCart.Columns.Add("Name", "Name");
            dgvCart.Columns["Name"].DataPropertyName = "Name";

            // Add Price column to DataGridView
            dgvCart.Columns.Add("Price", "Price");
            dgvCart.Columns["Price"].DataPropertyName = "Price";

            // Add Quantity column to DataGridView
            dgvCart.Columns.Add("Quantity", "Quantity");
            dgvCart.Columns["Quantity"].DataPropertyName = "Quantity";

            // Add SubTotal column to DataGridView
            dgvCart.Columns.Add("SubTotal", "Sub Total");
            dgvCart.Columns["SubTotal"].DataPropertyName = "SubTotal";

            dgvCart.Columns.Add("TotalDiscount", "Total Discount");
            dgvCart.Columns["TotalDiscount"].DataPropertyName = "TotalDiscount";

            // Add Remove button column
            // Add a Remove button column with an image
            DataGridViewImageColumn removeButtonColumn = new DataGridViewImageColumn();
            removeButtonColumn.Name = "Remove";
            removeButtonColumn.HeaderText = "Remove";
            removeButtonColumn.Image = Properties.Resources.trash; // Replace with your image resource
            removeButtonColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust layout if needed
            dgvCart.Columns.Add(removeButtonColumn);

            // Add Discount column to DataGridView
            DataGridViewImageColumn discountColumn = new DataGridViewImageColumn();
            discountColumn.Name = "Discount";
            discountColumn.HeaderText = "Apply Discount";
            discountColumn.Image = Properties.Resources.discount; // Replace with your image resource
            discountColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Adjust layout if needed
            dgvCart.Columns.Add(discountColumn);

            // Bind the displayedProducts list to the DataGridView
            dgvCart.DataSource = null;  // Clear previous binding
            dgvCart.DataSource = cart;

            // Format columns for currency
            dgvCart.Columns["Price"].DefaultCellStyle.Format = "C2";
            dgvCart.Columns["SubTotal"].DefaultCellStyle.Format = "C2";
            dgvCart.Columns["TotalDiscount"].DefaultCellStyle.Format = "C2";
            // Set readonly for certain columns
            dgvCart.Columns["Barcode"].ReadOnly = true;
            dgvCart.Columns["Price"].ReadOnly = true;
            dgvCart.Columns["SubTotal"].ReadOnly = true;
            dgvCart.Columns["TotalDiscount"].ReadOnly = true;

        }

        private static bool IsLoggedIn()
        {
            return false;
        }

        private void AddProductToCart(int quantity)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Barcode cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fetch the product by barcode to get the ProductId
            var productId = isRetail ? DatabaseHelper.GetRetailedProductByBarcode(txtBarcode.Text) : DatabaseHelper.GetWholesaleProductByBarcode(txtBarcode.Text);


            if (productId.Rows.Count < 1)
            {
                MessageBox.Show("No product barcode found.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Fetch the product inventory details
            var inventory = inventoryList.FirstOrDefault(i => i.ProductId == Convert.ToInt32(productId.Rows[0]["Id"].ToString()) && i.LocationId == LocationId);


            if (inventory == null)
                {
                    MessageBox.Show($"No inventory found for Product ID {productId} at this location.", "Inventory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the product already exists in displayedProducts
                var existingProduct = cart.FirstOrDefault(p => p.Id == Convert.ToInt32(productId.Rows[0]["Id"].ToString()));

                if (existingProduct != null)
                {
                    // Check if adding another unit exceeds the inventory
                    if (existingProduct.Quantity + quantity > inventory.Units)
                    {
                        MessageBox.Show($"Cannot add more units. Available stock: {inventory.Units}.", "Stock Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Increment quantity if product already exists
                    existingProduct.Quantity += quantity;

                    // Update SubTotal
                    existingProduct.SubTotal = existingProduct.Quantity * existingProduct.Price;

                    // Recompute the discount if applied
                    if (existingProduct.HasDiscountApplied)
                    {
                        decimal discountPercentage = existingProduct.DiscountPercentage; // Get the previously applied discount percentage
                        existingProduct.TotalDiscount = existingProduct.AppliedDiscount * existingProduct.Quantity;  // Compute discount for the new SubTotal
                    }

                    // If product has VAT, update the VAT amount
                    if (existingProduct.IsVat == 1)
                    {
                        existingProduct.VatAmount = existingProduct.SubTotal * 0.12m;  // 12% VAT
                    }

                    // Refresh DataGridView after updating
                    RefreshDataGridView();
                    DisplayTotalAmount();
                    DisplayVatSale();
                    DisplayVatAmount();
                    DisplayVatExempt();
                    DisplayTotalDiscount();
                }
                else
                {
                    // Check if inventory has at least one unit
                    if (inventory.Units < 1)
                    {
                        MessageBox.Show($"Product with barcode {txtBarcode.Text} is out of stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Fetch product from the database
                    var product = isRetail ? DatabaseHelper.GetRetailedProductById(Convert.ToInt32(productId.Rows[0]["Id"].ToString())) : DatabaseHelper.GetWholesaleProductById(Convert.ToInt32(productId.Rows[0]["Id"].ToString()));

                    if (product != null)
                    {
                        // Calculate VAT if applicable
                        decimal vatAmount = 0;
                        if (product.IsVat == 1)
                        {
                            vatAmount = isRetail ? product.RetailPrice * 0.12m : product.WholesalePrice * 0.12m; // 12% VAT
                        }

                        decimal discountAmount = 0;

                        // Add the product to the cart
                        cart.Add(new Cart
                        {
                            Id = product.Id,
                            Barcode = product.Barcode,
                            Name = product.Name,
                            Description = product.Description,
                            Price = isRetail ? product.RetailPrice : product.WholesalePrice,
                            Quantity = quantity, // Initial quantity is 1
                            SubTotal = isRetail ? product.RetailPrice * quantity : product.WholesalePrice * quantity, // SubTotal = RetailPrice * Quantity
                            VatAmount = vatAmount, // Add VAT amount to the cart
                            IsVat = product.IsVat
                        });

                        if (cart.Count == 0)
                        {
                            dgvCart.Visible = false;
                        }
                        else
                        {
                            dgvCart.Visible = true;
                        }

                        // Refresh DataGridView to display the updated cart
                        RefreshDataGridView();
                        DisplayTotalAmount();
                        DisplayVatSale();
                        DisplayVatAmount();
                        DisplayVatExempt();
                        DisplayTotalDiscount();

                    }
                    else
                    {
                        // If no product is found in the database
                        MessageBox.Show($"Product with ID {productId} not found in the database.");
                    }
                }

                txtBarcode.Clear(); // Clear input for the next product
        }

        private void Main_Load(object sender, EventArgs e)
        {
            inventoryList = DatabaseHelper.LoadInventoryList();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.B:
                    MessageBox.Show(isRetail.ToString());
                    var browse = new BrowseProduct(isRetail);
                    var choose = browse.ShowDialog();
                    if (choose == DialogResult.OK)
                    {
                        AddToCartUsingBrowseProduct(browse.ProductId,1);
                    }
                    break;
                case Keys.Q: // Edit quantity
                    if (dgvCart.CurrentCell != null)
                    {
                        var quantity = new Quantity();
                        var result = quantity.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            UpdateQuantityBy(quantity.ChangeQuantity);
                        }

                    }
                    break;
                case Keys.Z: // Move to the previous row
                case Keys.X: // Move to the next row
                    if (!dgvCart.Focused)
                    {
                        dgvCart.Focus();
                    }

                    int currentRowIndex = dgvCart.CurrentCell?.RowIndex ?? 0; // Get the current row index
                    int totalRows = dgvCart.Rows.Count;

                    if (e.KeyCode == Keys.X) // Move to the next row
                    {
                        if (currentRowIndex < totalRows - 1)
                        {
                            dgvCart.CurrentCell = dgvCart.Rows[currentRowIndex + 1].Cells[0];
                        }
                        else
                        {
                            // Optional: Wrap around to the first row
                            dgvCart.CurrentCell = dgvCart.Rows[0].Cells[0];
                        }
                    }
                    else if (e.KeyCode == Keys.Z) // Move to the previous row
                    {
                        if (currentRowIndex > 0)
                        {
                            dgvCart.CurrentCell = dgvCart.Rows[currentRowIndex - 1].Cells[0];
                        }
                        else
                        {
                            // Optional: Wrap around to the last row
                            dgvCart.CurrentCell = dgvCart.Rows[totalRows - 1].Cells[0];
                        }
                    }

                    if (cart.Count == 0)
                    {
                        dgvCart.Visible = false;
                    }
                    else
                    {
                        dgvCart.Visible = true;
                    }

                    e.Handled = true; // Prevent further handling of the key event
                    e.SuppressKeyPress = true; // Suppress the key press
                    break;
                case Keys.D:
                    TriggerDiscountButton();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Delete:
                    TriggerRemoveButton();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.T:
                    if (cbTransactionType.SelectedIndex == 0)
                    {
                        isRetail = false;
                        RefreshForm();
                        cbTransactionType.SelectedIndex = 1; // Move to the second item
                    }
                    else
                    {
                        isRetail = true;
                        RefreshForm();
                        cbTransactionType.SelectedIndex = 0; // Move to the first item
                    }
                    break;
            }
        }

        private void TriggerRemoveButton()
        {
            if (dgvCart.Focused && dgvCart.Rows.Count > 0)
            {
                int currentRowIndex = dgvCart.CurrentCell.RowIndex;
                int discountColumnIndex = GetRemoveColumnIndex();

                if (discountColumnIndex >= 0)
                {
                    dgvCart_CellClick(dgvCart, new DataGridViewCellEventArgs(discountColumnIndex, currentRowIndex));
                }
            }
        }

        private int GetRemoveColumnIndex()
        {
            foreach (DataGridViewColumn column in dgvCart.Columns)
            {
                if (column.Name == "Remove")
                {
                    return column.Index;
                }
            }
            return -1;
        }

        private void TriggerDiscountButton()
        {
            // Ensure the DataGridView has focus and rows
            if (dgvCart.Focused && dgvCart.Rows.Count > 0)
            {
                // Get the current row and discount column index
                int currentRowIndex = dgvCart.CurrentCell.RowIndex;
                int discountColumnIndex = GetDiscountColumnIndex();

                // Ensure the column index is valid
                if (discountColumnIndex >= 0)
                {
                    // Simulate the discount button click
                    dgvCart_CellClick(dgvCart, new DataGridViewCellEventArgs(discountColumnIndex, currentRowIndex));
                }
            }
        }

        private int GetDiscountColumnIndex()
        {
            // Find the index of the "Discount" column
            foreach (DataGridViewColumn column in dgvCart.Columns)
            {
                if (column.Name == "Discount") // Match the column name
                {
                    return column.Index;
                }
            }
            return -1; // Return -1 if the column is not found
        }

        private async Task<bool> CheckDrawer()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            return await dbHelper.CheckCashDrawerStatus(UserId, LocationId);
        }

        private async void btnCustomer_Click(object sender, EventArgs e)
        {
            
            if (await CheckDrawer())
            {
                var customer = new Customer(UserId, LocationId);
                var result = customer.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CustomerId = customer.CustomerId;
                }
            }
            else
            {
                MessageBox.Show("Starting cash drawer is required", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnHoldCustomer_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                var hold = new HoldCustomer();
                var result = hold.ShowDialog();

                // If the user successfully logged in, set the token
                if (result == DialogResult.OK)
                {

                    cart = hold._cart;
                    RefreshDataGridView();
                    DisplayTotalAmount();
                    DisplayVatSale();
                    DisplayVatAmount();
                    DisplayVatExempt();
                    DisplayTotalDiscount();
                    dgvCart.Visible = true;
                    this.Refresh();
                }
            }
            else
            {
                Random random = new Random();
                int refId = random.Next(1000000000, int.MaxValue);
                DatabaseHelper.SaveHoldProducts(cart, refId);
                DatabaseHelper.SaveHoldSale(refId, 1);
                RefreshForm();
            }
        }

        private async void btnTender_Click(object sender, EventArgs e)
        {
            if (await CheckDrawer())
            {
                if (CustomerId == 0) { 
                    var searchCustomer = new SearchCustomer(UserId, LocationId, cart);
                    var result = searchCustomer.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        RefreshForm();
                    }
                } else
                {
                    var tender = new Tenders(UserId, LocationId, CustomerId, cart);
                    var result = tender.ShowDialog();
                    if(result == DialogResult.OK)
                    {
                        RefreshForm();
                    }
                }
            }
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CustomerId.ToString());
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddProductToCart(1);
                if (cart.Count == 0)
                {
                    dgvCart.Visible = false;
                }
                else
                {
                    dgvCart.Visible = true;
                }
                e.SuppressKeyPress = true;
            }
        }

        private void dgvCart_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle + and - keys to increase or decrease quantity
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus) // + key
            {
                // Check if cart is empty before proceeding
                if (dgvCart.Rows.Count == 0)
                {
                    MessageBox.Show("The cart is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgvCart.CurrentCell != null) // Ensure there's a selected cell
                {
                    UpdateQuantityBy(1); // Increase quantity
                }

                if (cart.Count == 0)
                {
                    dgvCart.Visible = false;
                }
                else
                {
                    dgvCart.Visible = true;
                }

                RefreshDataGridView();
                DisplayTotalAmount();
                DisplayVatSale();
                DisplayVatAmount();
                DisplayVatExempt();
                DisplayTotalDiscount();
                e.Handled = true;    // Prevent default + key behavior
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus) // - key
            {
                // Check if cart is empty before proceeding
                if (dgvCart.Rows.Count == 0)
                {
                    MessageBox.Show("The cart is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgvCart.CurrentCell != null) // Ensure there's a selected cell
                {
                    UpdateQuantityBy(-1); // Decrease quantity
                }

                if (cart.Count == 0)
                {
                    dgvCart.Visible = false;
                }
                else
                {
                    dgvCart.Visible = true;
                }

                RefreshDataGridView();
                DisplayTotalAmount();
                DisplayVatSale();
                DisplayVatAmount();
                DisplayVatExempt();
                DisplayTotalDiscount();
                e.Handled = true;     // Prevent default - key behavior
            }

            // Handle 'X' and 'Z' keys for row navigation
            if (e.KeyCode == Keys.X || e.KeyCode == Keys.Z)
            {
                // Check if cart is empty before proceeding
                if (dgvCart.Rows.Count == 0)
                {
                    MessageBox.Show("The cart is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                e.Handled = true;     // Prevent default behavior
                e.SuppressKeyPress = true; // Suppress keypress to avoid triggering editing

                // Ensure there is a current cell and rows are present
                if (dgvCart.CurrentCell == null || dgvCart.Rows.Count == 0)
                {
                    MessageBox.Show("No rows to navigate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int currentRowIndex = dgvCart.CurrentCell.RowIndex;
                int totalRows = dgvCart.Rows.Count;

                if (e.KeyCode == Keys.X) // Move to the next row
                {
                    if (currentRowIndex < totalRows - 1)
                    {
                        dgvCart.CurrentCell = dgvCart.Rows[currentRowIndex + 1].Cells[0];
                    }
                    else
                    {
                        // Optional: Wrap around to the first row
                        dgvCart.CurrentCell = dgvCart.Rows[0].Cells[0];
                    }
                }
                else if (e.KeyCode == Keys.Z) // Move to the previous row
                {
                    if (currentRowIndex > 0)
                    {
                        dgvCart.CurrentCell = dgvCart.Rows[currentRowIndex - 1].Cells[0];
                    }
                    else
                    {
                        // Optional: Wrap around to the last row
                        dgvCart.CurrentCell = dgvCart.Rows[totalRows - 1].Cells[0];
                    }
                }
            }
        }


        private void UpdateQuantityBy(int change)
        {
            var row = dgvCart.CurrentRow;

            if (row != null)
            {
                // Get the product's barcode from the current row
                string barcode = row.Cells["Barcode"].Value?.ToString();

                if (!string.IsNullOrEmpty(barcode))
                {
                    // Find the product in the cart by its barcode
                    var product = cart.FirstOrDefault(p => p.Barcode == barcode);

                    if (product != null)
                    {
                        // Get the inventory details for the product
                        var inventory = inventoryList.FirstOrDefault(i => i.ProductId == product.Id && i.LocationId == 1);

                        // Calculate the new quantity
                        int newQuantity = product.Quantity + change;

                        if (newQuantity < 1)
                        {
                            // Remove product from the cart if quantity goes below 1
                            cart.Remove(product);
                            RefreshDataGridView();
                            DisplayTotalAmount();
                            DisplayVatSale();
                            DisplayVatAmount();
                            DisplayVatExempt();
                            DisplayTotalDiscount();
                        }
                        else if (inventory != null && newQuantity > inventory.Units)
                        {
                            // Check if the new quantity exceeds available stock
                            MessageBox.Show($"Cannot set quantity to {newQuantity}. Available stock: {inventory.Units}.", "Stock Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            // Update the product's quantity and related calculations
                            product.Quantity = newQuantity;
                            product.SubTotal = product.Quantity * product.Price;

                            // Update discount if applicable
                            if (product.HasDiscountApplied)
                            {
                                product.TotalDiscount = product.AppliedDiscount * product.Quantity;
                            }

                            // Update VAT if applicable
                            if (product.IsVat == 1)
                            {
                                product.VatAmount = Math.Round(product.SubTotal * 0.12m, 2, MidpointRounding.AwayFromZero);
                            }
                        }

                        RefreshDataGridView();
                        DisplayTotalAmount();
                        DisplayVatSale();
                        DisplayVatAmount();
                        DisplayVatExempt();
                        DisplayTotalDiscount();
                    }
                }
            }
        }

        private void RefreshForm()
        {
            // Clear the cart
            cart.Clear();

            // Handle empty cart and DataGridView visibility
            if (cart.Count == 0)
            {
                dgvCart.Visible = false;
                dgvCart.DataSource = null; // Clear the DataGridView data source
                dgvCart.CurrentCell = null; // Reset current cell
            }
            else
            {
                dgvCart.Visible = true;
                dgvCart.DataSource = cart; // Bind cart to DataGridView
            }

            // Update display values
            RefreshDataGridView();
            DisplayTotalAmount();
            DisplayVatSale();
            DisplayVatAmount();
            DisplayVatExempt();
            DisplayTotalDiscount();
            CustomerId = 0;
            // Reload the inventory list
            inventoryList = DatabaseHelper.LoadInventoryList();
        }

        private void cbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTransactionType.SelectedIndex == 0)
            {
                isRetail = true;
                RefreshForm();
            }
            else
            {
                isRetail = false;
                RefreshForm();
            }
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on the "Remove" button column
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvCart.Columns["Remove"].Index)
            {
                var productToRemove = cart[e.RowIndex];

                // If quantity is greater than 1, decrease the quantity
                if (productToRemove.Quantity > 1)
                {
                    productToRemove.Quantity -= 1;
                    productToRemove.SubTotal = productToRemove.Quantity * productToRemove.Price;

                    // Recompute the discount if applied
                    if (productToRemove.HasDiscountApplied)
                    {
                        productToRemove.TotalDiscount = productToRemove.TotalDiscount - productToRemove.AppliedDiscount; // Remove the discount for the previous quantity
                    }

                    // Recalculate VAT if applicable
                    if (productToRemove.IsVat == 1)
                    {
                        productToRemove.VatAmount = Math.Round(productToRemove.SubTotal * 0.12m, 2, MidpointRounding.AwayFromZero);  // 12% VAT
                    }
                }
                else
                {
                    // If quantity is 1, remove the product from the cart
                    cart.RemoveAt(e.RowIndex);
                    if (cart.Count == 0)
                    {
                        dgvCart.ColumnHeadersVisible = false;

                    }
                    else
                    {
                        dgvCart.ColumnHeadersVisible = true;
                    }
                }

                if (cart.Count == 0)
                {
                    dgvCart.Visible = false;
                }
                else
                {
                    dgvCart.Visible = true;
                }
                // Refresh DataGridView after updating
                RefreshDataGridView();
                DisplayTotalAmount();
                DisplayVatSale();
                DisplayVatAmount();
                DisplayVatExempt();
                DisplayTotalDiscount();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dgvCart.Columns["Discount"].Index)
            {
                var productToDiscount = cart[e.RowIndex];

                // Check if the product already has a discount applied
                if (productToDiscount.HasDiscountApplied) // Assuming you have a property for this
                {
                    MessageBox.Show("This product already has a discount applied.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit early if a discount is already applied
                }

                // Fetch discount from the DiscountSelectionForm
                var selectedDiscount = GetSelectedDiscount();

                if (selectedDiscount != null)
                {
                    // Calculate discount amount
                    decimal discountAmount = (selectedDiscount.Percentage / 100m) * productToDiscount.Price;
                    decimal discountedPrice = productToDiscount.Price - discountAmount;
                    decimal totalDiscount = discountedPrice * (selectedDiscount.Percentage / 100m);
                    // Apply the discounted price
                    productToDiscount.DiscountId = selectedDiscount.DiscountId;
                    productToDiscount.Price = discountedPrice;
                    productToDiscount.SubTotal = productToDiscount.Quantity * discountedPrice;
                    productToDiscount.HasDiscountApplied = true; // Mark that a discount has been applied
                    productToDiscount.DiscountPercentage = selectedDiscount.Percentage;
                    productToDiscount.AppliedDiscount = discountAmount;
                    productToDiscount.TotalDiscount = discountAmount * productToDiscount.Quantity;
                    // Recalculate VAT if applicable
                    if (productToDiscount.IsVat == 1)
                    {
                        productToDiscount.VatAmount = Math.Round(productToDiscount.SubTotal * 0.12m, 2, MidpointRounding.AwayFromZero);  // 12% VAT
                    }

                }
                else
                {
                    MessageBox.Show("No discount selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (cart.Count == 0)
                {
                    dgvCart.Visible = false;
                }
                else
                {
                    dgvCart.Visible = true;
                }

                // Refresh DataGridView after updating
                RefreshDataGridView();
                DisplayTotalAmount();
                DisplayVatSale();
                DisplayVatAmount();
                DisplayVatExempt();
                DisplayTotalDiscount();
            }
        }

        private Discounts GetSelectedDiscount()
        {
            // Fetch the list of discounts from the database using the existing method
            DataTable discountDataTable = DatabaseHelper.GetAllDiscounts();

            // Check if any discounts were retrieved
            if (discountDataTable == null || discountDataTable.Rows.Count == 0)
            {
                MessageBox.Show("No discounts available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            // Convert DataTable to a list of Discounts
            List<Discounts> discounts = new List<Discounts>();
            foreach (DataRow row in discountDataTable.Rows)
            {
                discounts.Add(new Discounts
                {
                    DiscountId = Convert.ToInt32(row["DiscountId"]),
                    Name = row["Name"].ToString(),
                    Percentage = Convert.ToInt32(row["Percentage"]),
                    Status = Convert.ToInt32(row["Status"]),
                    DateCreated = row["DateCreated"] as DateTime? // Handle possible nulls
                });
            }

            // Create the DiscountSelectionForm and pass the discounts list
            using (var discountForm = new DiscountList(discounts))
            {
                var result = discountForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    return discountForm.SelectedDiscount;
                }
            }

            // If the user cancels or no discount selected, return null
            return null;
        }

        private void AddToCartUsingBrowseProduct(int productId,int quantity)
        {
                // Fetch the product inventory details
                var inventory = inventoryList.FirstOrDefault(i => i.ProductId == productId && i.LocationId == 1);

                if (inventory == null)
                {
                    MessageBox.Show($"No inventory found for Product ID {productId} at this location.", "Inventory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the product already exists in displayedProducts
                var existingProduct = cart.FirstOrDefault(p => p.Id == productId);

                if (existingProduct != null)
                {
                    // Check if adding another unit exceeds the inventory
                    if (existingProduct.Quantity + quantity > inventory.Units)
                    {
                        MessageBox.Show($"Cannot add more units. Available stock: {inventory.Units}.", "Stock Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Increment quantity if product already exists
                    existingProduct.Quantity += quantity;

                    // Update SubTotal
                    existingProduct.SubTotal = existingProduct.Quantity * existingProduct.Price;

                    // Recompute the discount if applied
                    if (existingProduct.HasDiscountApplied)
                    {
                        decimal discountPercentage = existingProduct.DiscountPercentage; // Get the previously applied discount percentage
                        existingProduct.TotalDiscount = existingProduct.AppliedDiscount * existingProduct.Quantity;  // Compute discount for the new SubTotal
                    }

                    // If product has VAT, update the VAT amount
                    if (existingProduct.IsVat == 1)
                    {
                        existingProduct.VatAmount = existingProduct.SubTotal * 0.12m;  // 12% VAT
                    }

                    // Refresh DataGridView after updating
                    RefreshDataGridView();
                    DisplayTotalAmount();
                    DisplayVatSale();
                    DisplayVatAmount();
                    DisplayVatExempt();
                    DisplayTotalDiscount();
                }
                else
                {
                    // Check if inventory has at least one unit
                    if (inventory.Units < 1)
                    {
                        MessageBox.Show($"Product ID {productId} is out of stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Fetch product from the database
                    var product = isRetail ? DatabaseHelper.GetRetailedProductById(productId) : DatabaseHelper.GetWholesaleProductById(productId);

                    if (product != null)
                    {
                        // Calculate VAT if applicable
                        decimal vatAmount = 0;
                        if (product.IsVat == 1)
                        {
                            vatAmount = isRetail ? product.RetailPrice * 0.12m : product.WholesalePrice * 0.12m; // 12% VAT
                        }

                        decimal discountAmount = 0;

                        // Add the product to the cart
                        cart.Add(new Cart
                        {
                            Id = product.Id,
                            Barcode = product.Barcode,
                            Name = product.Name,
                            Description = product.Description,
                            Price = isRetail ? product.RetailPrice : product.WholesalePrice,
                            Quantity = quantity, // Initial quantity is 1
                            SubTotal = isRetail ? product.RetailPrice * quantity : product.WholesalePrice * quantity, // SubTotal = RetailPrice * Quantity
                            VatAmount = vatAmount, // Add VAT amount to the cart
                            IsVat = product.IsVat
                        });

                        if (cart.Count == 0)
                        {
                            dgvCart.Visible = false;
                        }
                        else
                        {
                            dgvCart.Visible = true;
                        }

                        // Refresh DataGridView to display the updated cart
                        RefreshDataGridView();
                        DisplayTotalAmount();
                        DisplayVatSale();
                        DisplayVatAmount();
                        DisplayVatExempt();
                        DisplayTotalDiscount();

                    }
                    else
                    {
                        // If no product is found in the database
                        MessageBox.Show($"Product with ID {productId} not found in the database.");
                    }
                }

                txtBarcode.Clear(); // Clear input for the next product
        }

        private void btnXReading_Click(object sender, EventArgs e)
        {
            XReading xreading = new XReading();
            xreading.ShowDialog();
        }

        private void btnCashDrawer_Click(object sender, EventArgs e)
        {
            var drawer = new CashDrawer(UserId,LocationId);
            var result = drawer.ShowDialog();

            // If the user successfully logged in, set the token
            if (result == DialogResult.OK)
            {

            }
        }
    }
}
