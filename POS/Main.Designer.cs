namespace POS
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            lblTopTotalAmount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnHoldCustomer = new Button();
            btnCashDrawer = new Button();
            btnXReading = new Button();
            btnCredits = new Button();
            btnSales = new Button();
            btnLogout = new Button();
            btnSync = new Button();
            btnCustomer = new Button();
            btnTender = new Button();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            lblDiscount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblVatSale = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblVatAmount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTotalAmount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblVatExempt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2ColorTransition1 = new Guna.UI2.WinForms.Guna2ColorTransition(components);
            cbTransactionType = new Guna.UI2.WinForms.Guna2ComboBox();
            txtBarcode = new Guna.UI2.WinForms.Guna2TextBox();
            dgvCart = new Guna.UI2.WinForms.Guna2DataGridView();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.BorderRadius = 5;
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.DragForm = false;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Panel1
            // 
            guna2Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel1.Controls.Add(lblTopTotalAmount);
            guna2Panel1.CustomizableEdges = customizableEdges7;
            guna2Panel1.FillColor = Color.FromArgb(246, 177, 0);
            guna2Panel1.Location = new Point(-13, -5);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2Panel1.Size = new Size(1092, 72);
            guna2Panel1.TabIndex = 0;
            // 
            // lblTopTotalAmount
            // 
            lblTopTotalAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTopTotalAmount.BackColor = Color.Transparent;
            lblTopTotalAmount.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblTopTotalAmount.ForeColor = Color.DarkGreen;
            lblTopTotalAmount.Location = new Point(943, 17);
            lblTopTotalAmount.Name = "lblTopTotalAmount";
            lblTopTotalAmount.Size = new Size(66, 47);
            lblTopTotalAmount.TabIndex = 23;
            lblTopTotalAmount.Text = "0.00";
            // 
            // btnHoldCustomer
            // 
            btnHoldCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHoldCustomer.BackColor = Color.FromArgb(255, 214, 90);
            btnHoldCustomer.Cursor = Cursors.Hand;
            btnHoldCustomer.FlatAppearance.BorderSize = 0;
            btnHoldCustomer.FlatStyle = FlatStyle.Flat;
            btnHoldCustomer.Font = new Font("Segoe UI Semilight", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnHoldCustomer.ForeColor = Color.Black;
            btnHoldCustomer.Image = Properties.Resources._4291883181595501278_48;
            btnHoldCustomer.Location = new Point(751, 287);
            btnHoldCustomer.Name = "btnHoldCustomer";
            btnHoldCustomer.Size = new Size(306, 79);
            btnHoldCustomer.TabIndex = 1;
            btnHoldCustomer.Text = "Hold Customer";
            btnHoldCustomer.TextAlign = ContentAlignment.BottomCenter;
            btnHoldCustomer.TextImageRelation = TextImageRelation.ImageAboveText;
            btnHoldCustomer.UseVisualStyleBackColor = false;
            btnHoldCustomer.Click += btnHoldCustomer_Click;
            // 
            // btnCashDrawer
            // 
            btnCashDrawer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCashDrawer.BackColor = Color.FromArgb(255, 214, 90);
            btnCashDrawer.Cursor = Cursors.Hand;
            btnCashDrawer.FlatAppearance.BorderSize = 0;
            btnCashDrawer.FlatStyle = FlatStyle.Flat;
            btnCashDrawer.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCashDrawer.ForeColor = Color.Black;
            btnCashDrawer.Image = (Image)resources.GetObject("btnCashDrawer.Image");
            btnCashDrawer.Location = new Point(907, 145);
            btnCashDrawer.Name = "btnCashDrawer";
            btnCashDrawer.Size = new Size(150, 65);
            btnCashDrawer.TabIndex = 4;
            btnCashDrawer.Text = "Cash Drawer";
            btnCashDrawer.TextAlign = ContentAlignment.MiddleRight;
            btnCashDrawer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCashDrawer.UseVisualStyleBackColor = false;
            btnCashDrawer.Click += btnCashDrawer_Click;
            // 
            // btnXReading
            // 
            btnXReading.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXReading.BackColor = Color.FromArgb(255, 214, 90);
            btnXReading.Cursor = Cursors.Hand;
            btnXReading.FlatAppearance.BorderSize = 0;
            btnXReading.FlatStyle = FlatStyle.Flat;
            btnXReading.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnXReading.ForeColor = Color.Black;
            btnXReading.Image = (Image)resources.GetObject("btnXReading.Image");
            btnXReading.Location = new Point(907, 216);
            btnXReading.Name = "btnXReading";
            btnXReading.Size = new Size(150, 65);
            btnXReading.TabIndex = 5;
            btnXReading.Text = "X-Reading";
            btnXReading.TextAlign = ContentAlignment.MiddleRight;
            btnXReading.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnXReading.UseVisualStyleBackColor = false;
            btnXReading.Click += btnXReading_Click;
            // 
            // btnCredits
            // 
            btnCredits.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCredits.BackColor = Color.FromArgb(255, 214, 90);
            btnCredits.Cursor = Cursors.Hand;
            btnCredits.FlatAppearance.BorderSize = 0;
            btnCredits.FlatStyle = FlatStyle.Flat;
            btnCredits.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCredits.ForeColor = Color.Black;
            btnCredits.Image = (Image)resources.GetObject("btnCredits.Image");
            btnCredits.Location = new Point(751, 145);
            btnCredits.Name = "btnCredits";
            btnCredits.Size = new Size(150, 65);
            btnCredits.TabIndex = 6;
            btnCredits.Text = "Credits";
            btnCredits.TextAlign = ContentAlignment.MiddleRight;
            btnCredits.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCredits.UseVisualStyleBackColor = false;
            btnCredits.Click += btnCredits_Click;
            // 
            // btnSales
            // 
            btnSales.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSales.BackColor = Color.FromArgb(255, 214, 90);
            btnSales.Cursor = Cursors.Hand;
            btnSales.FlatAppearance.BorderSize = 0;
            btnSales.FlatStyle = FlatStyle.Flat;
            btnSales.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSales.ForeColor = Color.Black;
            btnSales.Image = (Image)resources.GetObject("btnSales.Image");
            btnSales.Location = new Point(751, 216);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(150, 65);
            btnSales.TabIndex = 7;
            btnSales.Text = "Sales/Void";
            btnSales.TextAlign = ContentAlignment.MiddleRight;
            btnSales.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSales.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(255, 214, 90);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Image = (Image)resources.GetObject("btnLogout.Image");
            btnLogout.Location = new Point(985, 73);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(72, 65);
            btnLogout.TabIndex = 14;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.BottomCenter;
            btnLogout.TextImageRelation = TextImageRelation.ImageAboveText;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnSync
            // 
            btnSync.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSync.BackColor = Color.FromArgb(255, 214, 90);
            btnSync.Cursor = Cursors.Hand;
            btnSync.FlatAppearance.BorderSize = 0;
            btnSync.FlatStyle = FlatStyle.Flat;
            btnSync.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSync.ForeColor = Color.Black;
            btnSync.Image = (Image)resources.GetObject("btnSync.Image");
            btnSync.Location = new Point(907, 73);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(72, 66);
            btnSync.TabIndex = 13;
            btnSync.Text = "Sync";
            btnSync.TextAlign = ContentAlignment.BottomCenter;
            btnSync.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSync.UseVisualStyleBackColor = false;
            // 
            // btnCustomer
            // 
            btnCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCustomer.BackColor = Color.FromArgb(255, 214, 90);
            btnCustomer.Cursor = Cursors.Hand;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCustomer.ForeColor = Color.Black;
            btnCustomer.Image = (Image)resources.GetObject("btnCustomer.Image");
            btnCustomer.Location = new Point(751, 73);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(150, 65);
            btnCustomer.TabIndex = 12;
            btnCustomer.Text = "Customer";
            btnCustomer.TextAlign = ContentAlignment.BottomCenter;
            btnCustomer.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCustomer.UseVisualStyleBackColor = false;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnTender
            // 
            btnTender.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTender.AutoSize = true;
            btnTender.BackColor = Color.FromArgb(255, 214, 90);
            btnTender.Cursor = Cursors.Hand;
            btnTender.FlatAppearance.BorderSize = 0;
            btnTender.FlatStyle = FlatStyle.Flat;
            btnTender.Font = new Font("Segoe UI Semilight", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnTender.ForeColor = Color.Black;
            btnTender.Image = (Image)resources.GetObject("btnTender.Image");
            btnTender.Location = new Point(751, 549);
            btnTender.Name = "btnTender";
            btnTender.Size = new Size(306, 105);
            btnTender.TabIndex = 15;
            btnTender.Text = "Tenders";
            btnTender.TextAlign = ContentAlignment.BottomCenter;
            btnTender.TextImageRelation = TextImageRelation.ImageAboveText;
            btnTender.UseVisualStyleBackColor = false;
            btnTender.Click += btnTender_Click;
            // 
            // guna2Panel2
            // 
            guna2Panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            guna2Panel2.BackColor = Color.White;
            guna2Panel2.BorderColor = Color.FromArgb(255, 214, 90);
            guna2Panel2.BorderRadius = 5;
            guna2Panel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            guna2Panel2.Controls.Add(lblDiscount);
            guna2Panel2.Controls.Add(guna2HtmlLabel10);
            guna2Panel2.Controls.Add(guna2HtmlLabel8);
            guna2Panel2.Controls.Add(guna2HtmlLabel5);
            guna2Panel2.Controls.Add(lblVatSale);
            guna2Panel2.Controls.Add(guna2HtmlLabel6);
            guna2Panel2.Controls.Add(guna2HtmlLabel7);
            guna2Panel2.Controls.Add(lblVatAmount);
            guna2Panel2.Controls.Add(lblTotalAmount);
            guna2Panel2.Controls.Add(lblVatExempt);
            guna2Panel2.CustomizableEdges = customizableEdges5;
            guna2Panel2.Location = new Point(751, 372);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel2.Size = new Size(306, 171);
            guna2Panel2.TabIndex = 16;
            // 
            // lblDiscount
            // 
            lblDiscount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblDiscount.AvoidGeometryAntialias = true;
            lblDiscount.BackColor = Color.Transparent;
            lblDiscount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblDiscount.ForeColor = Color.Black;
            lblDiscount.Location = new Point(156, 40);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(27, 19);
            lblDiscount.TabIndex = 20;
            lblDiscount.Text = "0.00";
            lblDiscount.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // guna2HtmlLabel10
            // 
            guna2HtmlLabel10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guna2HtmlLabel10.BackColor = Color.Transparent;
            guna2HtmlLabel10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel10.ForeColor = Color.Black;
            guna2HtmlLabel10.Location = new Point(9, 141);
            guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            guna2HtmlLabel10.Size = new Size(126, 23);
            guna2HtmlLabel10.TabIndex = 23;
            guna2HtmlLabel10.Text = "TOTAL AMOUNT";
            // 
            // guna2HtmlLabel8
            // 
            guna2HtmlLabel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guna2HtmlLabel8.BackColor = Color.Transparent;
            guna2HtmlLabel8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel8.ForeColor = Color.Black;
            guna2HtmlLabel8.Location = new Point(9, 41);
            guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            guna2HtmlLabel8.Size = new Size(67, 19);
            guna2HtmlLabel8.TabIndex = 21;
            guna2HtmlLabel8.Text = "DISCOUNT";
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel5.ForeColor = Color.Black;
            guna2HtmlLabel5.Location = new Point(9, 66);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(60, 19);
            guna2HtmlLabel5.TabIndex = 17;
            guna2HtmlLabel5.Text = "VAT SALE";
            // 
            // lblVatSale
            // 
            lblVatSale.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblVatSale.BackColor = Color.Transparent;
            lblVatSale.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblVatSale.ForeColor = Color.Black;
            lblVatSale.Location = new Point(156, 65);
            lblVatSale.Name = "lblVatSale";
            lblVatSale.Size = new Size(27, 19);
            lblVatSale.TabIndex = 16;
            lblVatSale.Text = "0.00";
            lblVatSale.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // guna2HtmlLabel6
            // 
            guna2HtmlLabel6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guna2HtmlLabel6.BackColor = Color.Transparent;
            guna2HtmlLabel6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel6.ForeColor = Color.Black;
            guna2HtmlLabel6.Location = new Point(9, 116);
            guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            guna2HtmlLabel6.Size = new Size(80, 19);
            guna2HtmlLabel6.TabIndex = 18;
            guna2HtmlLabel6.Text = "VAT EXEMPT";
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel7.ForeColor = Color.Black;
            guna2HtmlLabel7.Location = new Point(9, 91);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(88, 19);
            guna2HtmlLabel7.TabIndex = 19;
            guna2HtmlLabel7.Text = "VAT AMOUNT";
            // 
            // lblVatAmount
            // 
            lblVatAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblVatAmount.BackColor = Color.Transparent;
            lblVatAmount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblVatAmount.ForeColor = Color.Black;
            lblVatAmount.Location = new Point(156, 90);
            lblVatAmount.Name = "lblVatAmount";
            lblVatAmount.Size = new Size(27, 19);
            lblVatAmount.TabIndex = 15;
            lblVatAmount.Text = "0.00";
            lblVatAmount.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalAmount.BackColor = Color.Transparent;
            lblTotalAmount.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalAmount.ForeColor = Color.DarkGreen;
            lblTotalAmount.Location = new Point(156, 133);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(48, 34);
            lblTotalAmount.TabIndex = 22;
            lblTotalAmount.Text = "0.00";
            lblTotalAmount.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // lblVatExempt
            // 
            lblVatExempt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblVatExempt.BackColor = Color.Transparent;
            lblVatExempt.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblVatExempt.ForeColor = Color.Black;
            lblVatExempt.Location = new Point(156, 115);
            lblVatExempt.Name = "lblVatExempt";
            lblVatExempt.Size = new Size(27, 19);
            lblVatExempt.TabIndex = 14;
            lblVatExempt.Text = "0.00";
            lblVatExempt.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // guna2ColorTransition1
            // 
            guna2ColorTransition1.ColorArray = new Color[]
    {
    Color.Red,
    Color.Blue,
    Color.Orange
    };
            // 
            // cbTransactionType
            // 
            cbTransactionType.BackColor = Color.White;
            cbTransactionType.BorderRadius = 5;
            cbTransactionType.CustomizableEdges = customizableEdges1;
            cbTransactionType.DrawMode = DrawMode.OwnerDrawFixed;
            cbTransactionType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTransactionType.FocusedColor = Color.FromArgb(94, 148, 255);
            cbTransactionType.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbTransactionType.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cbTransactionType.ForeColor = Color.FromArgb(105, 117, 101);
            cbTransactionType.ItemHeight = 30;
            cbTransactionType.Items.AddRange(new object[] { "RETAIL", "WHOLESALE" });
            cbTransactionType.Location = new Point(12, 73);
            cbTransactionType.Name = "cbTransactionType";
            cbTransactionType.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbTransactionType.Size = new Size(152, 36);
            cbTransactionType.StartIndex = 0;
            cbTransactionType.TabIndex = 18;
            cbTransactionType.SelectedIndexChanged += cbTransactionType_SelectedIndexChanged;
            // 
            // txtBarcode
            // 
            txtBarcode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBarcode.BackColor = Color.White;
            txtBarcode.BorderRadius = 5;
            txtBarcode.CustomizableEdges = customizableEdges3;
            txtBarcode.DefaultText = "";
            txtBarcode.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBarcode.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBarcode.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBarcode.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBarcode.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBarcode.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBarcode.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBarcode.Location = new Point(170, 73);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.PasswordChar = '\0';
            txtBarcode.PlaceholderText = "ENTER BARCODE";
            txtBarcode.SelectedText = "";
            txtBarcode.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtBarcode.Size = new Size(575, 36);
            txtBarcode.TabIndex = 17;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AllowUserToResizeColumns = false;
            dgvCart.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(246, 177, 0);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCart.ColumnHeadersHeight = 40;
            dgvCart.Cursor = Cursors.Hand;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(246, 177, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCart.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCart.GridColor = Color.White;
            dgvCart.Location = new Point(12, 115);
            dgvCart.Name = "dgvCart";
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowTemplate.Height = 25;
            dgvCart.Size = new Size(733, 514);
            dgvCart.TabIndex = 19;
            dgvCart.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvCart.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvCart.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvCart.ThemeStyle.BackColor = Color.White;
            dgvCart.ThemeStyle.GridColor = Color.White;
            dgvCart.ThemeStyle.HeaderStyle.BackColor = Color.White;
            dgvCart.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCart.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dgvCart.ThemeStyle.HeaderStyle.ForeColor = Color.Black;
            dgvCart.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCart.ThemeStyle.HeaderStyle.Height = 40;
            dgvCart.ThemeStyle.ReadOnly = false;
            dgvCart.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvCart.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCart.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgvCart.ThemeStyle.RowsStyle.ForeColor = Color.White;
            dgvCart.ThemeStyle.RowsStyle.Height = 25;
            dgvCart.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvCart.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(246, 177, 0);
            dgvCart.CellClick += dgvCart_CellClick;
            dgvCart.KeyDown += dgvCart_KeyDown;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2HtmlLabel2.AutoSize = false;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            guna2HtmlLabel2.ForeColor = Color.FromArgb(105, 117, 101);
            guna2HtmlLabel2.Location = new Point(9, 635);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(736, 19);
            guna2HtmlLabel2.TabIndex = 25;
            guna2HtmlLabel2.Text = "Shortcut Keys --->>> [↑]-Move Up [↓]-Move Down [DEL]-Remove Item [D]-Discount [T]-Change Transaction Type [+]-Add Qty [-]-Subtract Qty";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 247, 236);
            ClientSize = new Size(1069, 666);
            ControlBox = false;
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(btnSync);
            Controls.Add(dgvCart);
            Controls.Add(cbTransactionType);
            Controls.Add(txtBarcode);
            Controls.Add(guna2Panel2);
            Controls.Add(btnTender);
            Controls.Add(btnLogout);
            Controls.Add(btnCustomer);
            Controls.Add(btnSales);
            Controls.Add(btnCredits);
            Controls.Add(btnXReading);
            Controls.Add(btnCashDrawer);
            Controls.Add(btnHoldCustomer);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Load += Main_Load;
            KeyDown += Main_KeyDown;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Button btnHoldCustomer;
        private Button btnCashDrawer;
        private Button btnCredits;
        private Button btnXReading;
        private Button btnSales;
        private Button btnLogout;
        private Button btnSync;
        private Button btnCustomer;
        private Button btnTender;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDiscount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblVatSale;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblVatAmount;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalAmount;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblVatExempt;
        private Guna.UI2.WinForms.Guna2ComboBox cbTransactionType;
        private Guna.UI2.WinForms.Guna2TextBox txtBarcode;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTopTotalAmount;
        private Guna.UI2.WinForms.Guna2ColorTransition guna2ColorTransition1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCart;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}
