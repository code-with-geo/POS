namespace POS
{
    partial class Customer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnNewCustomer = new Button();
            cbKeys = new Guna.UI2.WinForms.Guna2ComboBox();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            dgvCustomer = new Guna.UI2.WinForms.Guna2DataGridView();
            Barcode = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.ForeColor = Color.LightCoral;
            guna2HtmlLabel1.Location = new Point(814, 21);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(102, 15);
            guna2HtmlLabel1.TabIndex = 25;
            guna2HtmlLabel1.Text = "Press [ESC] to close";
            // 
            // btnNewCustomer
            // 
            btnNewCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNewCustomer.BackColor = Color.FromArgb(255, 214, 90);
            btnNewCustomer.Cursor = Cursors.Hand;
            btnNewCustomer.FlatAppearance.BorderSize = 0;
            btnNewCustomer.FlatStyle = FlatStyle.Flat;
            btnNewCustomer.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnNewCustomer.ForeColor = Color.Black;
            btnNewCustomer.Location = new Point(772, 485);
            btnNewCustomer.Name = "btnNewCustomer";
            btnNewCustomer.Size = new Size(144, 51);
            btnNewCustomer.TabIndex = 26;
            btnNewCustomer.Text = "New Customer";
            btnNewCustomer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNewCustomer.UseVisualStyleBackColor = false;
            btnNewCustomer.Click += btnNewCustomer_Click;
            // 
            // cbKeys
            // 
            cbKeys.BackColor = Color.White;
            cbKeys.BorderRadius = 5;
            cbKeys.CustomizableEdges = customizableEdges1;
            cbKeys.DrawMode = DrawMode.OwnerDrawFixed;
            cbKeys.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKeys.FocusedColor = Color.FromArgb(94, 148, 255);
            cbKeys.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbKeys.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbKeys.ForeColor = Color.FromArgb(105, 117, 101);
            cbKeys.ItemHeight = 30;
            cbKeys.Items.AddRange(new object[] { "FIRST NAME", "LAST NAME", "EMAIL" });
            cbKeys.Location = new Point(27, 54);
            cbKeys.Name = "cbKeys";
            cbKeys.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbKeys.Size = new Size(152, 36);
            cbKeys.StartIndex = 0;
            cbKeys.TabIndex = 29;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BackColor = Color.White;
            txtSearch.BorderRadius = 5;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Location = new Point(185, 54);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderText = "SEARCH";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(731, 36);
            txtSearch.TabIndex = 28;
            // 
            // dgvCustomer
            // 
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AllowUserToDeleteRows = false;
            dgvCustomer.AllowUserToResizeColumns = false;
            dgvCustomer.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(246, 177, 0);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomer.ColumnHeadersHeight = 40;
            dgvCustomer.Columns.AddRange(new DataGridViewColumn[] { Barcode, ProductName, Price, Quantity });
            dgvCustomer.Cursor = Cursors.Hand;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(246, 177, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCustomer.GridColor = Color.White;
            dgvCustomer.Location = new Point(23, 96);
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.RowHeadersVisible = false;
            dgvCustomer.RowTemplate.Height = 25;
            dgvCustomer.Size = new Size(893, 373);
            dgvCustomer.TabIndex = 27;
            dgvCustomer.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvCustomer.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvCustomer.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvCustomer.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvCustomer.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvCustomer.ThemeStyle.BackColor = Color.White;
            dgvCustomer.ThemeStyle.GridColor = Color.White;
            dgvCustomer.ThemeStyle.HeaderStyle.BackColor = Color.White;
            dgvCustomer.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCustomer.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dgvCustomer.ThemeStyle.HeaderStyle.ForeColor = Color.Black;
            dgvCustomer.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCustomer.ThemeStyle.HeaderStyle.Height = 40;
            dgvCustomer.ThemeStyle.ReadOnly = false;
            dgvCustomer.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvCustomer.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomer.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgvCustomer.ThemeStyle.RowsStyle.ForeColor = Color.White;
            dgvCustomer.ThemeStyle.RowsStyle.Height = 25;
            dgvCustomer.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvCustomer.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(246, 177, 0);
            // 
            // Barcode
            // 
            Barcode.HeaderText = "Barcode";
            Barcode.Name = "Barcode";
            Barcode.ReadOnly = true;
            Barcode.Resizable = DataGridViewTriState.False;
            // 
            // ProductName
            // 
            ProductName.HeaderText = "Product Name";
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            ProductName.Resizable = DataGridViewTriState.False;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Resizable = DataGridViewTriState.False;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.Name = "Quantity";
            Quantity.Resizable = DataGridViewTriState.False;
            // 
            // Customer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 549);
            ControlBox = false;
            Controls.Add(cbKeys);
            Controls.Add(txtSearch);
            Controls.Add(dgvCustomer);
            Controls.Add(btnNewCustomer);
            Controls.Add(guna2HtmlLabel1);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Movable = false;
            Name = "Customer";
            SizeGripStyle = SizeGripStyle.Hide;
            Style = MetroFramework.MetroColorStyle.Yellow;
            KeyDown += Customer_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Button btnNewCustomer;
        private Guna.UI2.WinForms.Guna2ComboBox cbKeys;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCustomer;
        private DataGridViewTextBoxColumn Barcode;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
    }
}