namespace POS
{
    partial class SearchCustomer
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
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnSkip = new Button();
            btnCustomer = new Button();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.ForeColor = Color.LightCoral;
            guna2HtmlLabel1.Location = new Point(326, 23);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(102, 15);
            guna2HtmlLabel1.TabIndex = 33;
            guna2HtmlLabel1.Text = "Press [ESC] to close";
            // 
            // btnSkip
            // 
            btnSkip.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSkip.BackColor = Color.FromArgb(255, 214, 90);
            btnSkip.Cursor = Cursors.Hand;
            btnSkip.FlatAppearance.BorderSize = 0;
            btnSkip.FlatStyle = FlatStyle.Flat;
            btnSkip.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSkip.ForeColor = Color.Black;
            btnSkip.Location = new Point(288, 110);
            btnSkip.Name = "btnSkip";
            btnSkip.Size = new Size(126, 51);
            btnSkip.TabIndex = 40;
            btnSkip.Text = "Skip";
            btnSkip.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSkip.UseVisualStyleBackColor = false;
            btnSkip.Click += btnSkip_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCustomer.BackColor = Color.FromArgb(255, 214, 90);
            btnCustomer.Cursor = Cursors.Hand;
            btnCustomer.FlatAppearance.BorderSize = 0;
            btnCustomer.FlatStyle = FlatStyle.Flat;
            btnCustomer.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCustomer.ForeColor = Color.Black;
            btnCustomer.Location = new Point(24, 110);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(126, 51);
            btnCustomer.TabIndex = 39;
            btnCustomer.Text = "Customers";
            btnCustomer.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCustomer.UseVisualStyleBackColor = false;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel2.ForeColor = Color.Black;
            guna2HtmlLabel2.Location = new Point(29, 63);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(385, 27);
            guna2HtmlLabel2.TabIndex = 41;
            guna2HtmlLabel2.Text = "Would you like to add customer on this sale?";
            // 
            // SearchCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 173);
            ControlBox = false;
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(btnSkip);
            Controls.Add(btnCustomer);
            Controls.Add(guna2HtmlLabel1);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Movable = false;
            Name = "SearchCustomer";
            Resizable = false;
            Style = MetroFramework.MetroColorStyle.Yellow;
            KeyDown += SearchCustomer_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Button btnSkip;
        private Button btnCustomer;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}