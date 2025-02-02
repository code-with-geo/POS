namespace POS
{
    partial class Cash
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnContinue = new Button();
            txtAmountReceived = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTotalAmount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblChange = new Guna.UI2.WinForms.Guna2HtmlLabel();
            printDocument = new System.Drawing.Printing.PrintDocument();
            SuspendLayout();
            // 
            // btnContinue
            // 
            btnContinue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnContinue.BackColor = Color.FromArgb(255, 214, 90);
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnContinue.ForeColor = Color.Black;
            btnContinue.Location = new Point(263, 273);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new Size(144, 51);
            btnContinue.TabIndex = 50;
            btnContinue.Text = "Continue";
            btnContinue.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnContinue.UseVisualStyleBackColor = false;
            btnContinue.Click += btnContinue_Click;
            // 
            // txtAmountReceived
            // 
            txtAmountReceived.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAmountReceived.BackColor = Color.White;
            txtAmountReceived.BorderRadius = 5;
            txtAmountReceived.CustomizableEdges = customizableEdges3;
            txtAmountReceived.DefaultText = "";
            txtAmountReceived.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtAmountReceived.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtAmountReceived.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtAmountReceived.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtAmountReceived.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAmountReceived.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtAmountReceived.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAmountReceived.Location = new Point(62, 158);
            txtAmountReceived.Name = "txtAmountReceived";
            txtAmountReceived.PasswordChar = '\0';
            txtAmountReceived.PlaceholderText = "Amount Receive";
            txtAmountReceived.SelectedText = "";
            txtAmountReceived.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtAmountReceived.Size = new Size(324, 36);
            txtAmountReceived.TabIndex = 49;
            txtAmountReceived.TextAlign = HorizontalAlignment.Center;
            txtAmountReceived.TextChanged += txtAmountReceived_TextChanged;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.ForeColor = Color.LightCoral;
            guna2HtmlLabel1.Location = new Point(305, 38);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(102, 15);
            guna2HtmlLabel1.TabIndex = 46;
            guna2HtmlLabel1.Text = "Press [ESC] to close";
            // 
            // guna2HtmlLabel10
            // 
            guna2HtmlLabel10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guna2HtmlLabel10.BackColor = Color.Transparent;
            guna2HtmlLabel10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel10.ForeColor = Color.Black;
            guna2HtmlLabel10.Location = new Point(62, 125);
            guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            guna2HtmlLabel10.Size = new Size(126, 23);
            guna2HtmlLabel10.TabIndex = 53;
            guna2HtmlLabel10.Text = "TOTAL AMOUNT";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalAmount.BackColor = Color.Transparent;
            lblTotalAmount.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalAmount.ForeColor = Color.DarkGreen;
            lblTotalAmount.Location = new Point(305, 114);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(48, 34);
            lblTotalAmount.TabIndex = 52;
            lblTotalAmount.Text = "0.00";
            lblTotalAmount.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel2.ForeColor = Color.Black;
            guna2HtmlLabel2.Location = new Point(62, 208);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(121, 23);
            guna2HtmlLabel2.TabIndex = 55;
            guna2HtmlLabel2.Text = "Change Amount";
            // 
            // lblChange
            // 
            lblChange.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblChange.BackColor = Color.Transparent;
            lblChange.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblChange.ForeColor = Color.DarkGreen;
            lblChange.Location = new Point(305, 200);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(48, 34);
            lblChange.TabIndex = 54;
            lblChange.Text = "0.00";
            lblChange.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // Cash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(445, 385);
            ControlBox = false;
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(lblChange);
            Controls.Add(guna2HtmlLabel10);
            Controls.Add(lblTotalAmount);
            Controls.Add(btnContinue);
            Controls.Add(txtAmountReceived);
            Controls.Add(guna2HtmlLabel1);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Movable = false;
            Name = "Cash";
            Resizable = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Style = MetroFramework.MetroColorStyle.Yellow;
            Load += Cash_Load;
            KeyDown += Cash_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnContinue;
        private Guna.UI2.WinForms.Guna2TextBox txtAmountReceived;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalAmount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChange;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}