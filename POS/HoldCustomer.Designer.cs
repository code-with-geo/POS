namespace POS
{
    partial class HoldCustomer
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvHoldCustomer = new Guna.UI2.WinForms.Guna2DataGridView();
            btnRemoveAll = new Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)dgvHoldCustomer).BeginInit();
            SuspendLayout();
            // 
            // dgvHoldCustomer
            // 
            dgvHoldCustomer.AllowUserToAddRows = false;
            dgvHoldCustomer.AllowUserToDeleteRows = false;
            dgvHoldCustomer.AllowUserToResizeColumns = false;
            dgvHoldCustomer.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvHoldCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHoldCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(246, 177, 0);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvHoldCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHoldCustomer.ColumnHeadersHeight = 40;
            dgvHoldCustomer.Cursor = Cursors.Hand;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(246, 177, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvHoldCustomer.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHoldCustomer.GridColor = Color.White;
            dgvHoldCustomer.Location = new Point(23, 54);
            dgvHoldCustomer.Name = "dgvHoldCustomer";
            dgvHoldCustomer.RowHeadersVisible = false;
            dgvHoldCustomer.RowTemplate.Height = 25;
            dgvHoldCustomer.Size = new Size(754, 385);
            dgvHoldCustomer.TabIndex = 28;
            dgvHoldCustomer.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvHoldCustomer.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvHoldCustomer.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvHoldCustomer.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvHoldCustomer.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvHoldCustomer.ThemeStyle.BackColor = Color.White;
            dgvHoldCustomer.ThemeStyle.GridColor = Color.White;
            dgvHoldCustomer.ThemeStyle.HeaderStyle.BackColor = Color.White;
            dgvHoldCustomer.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHoldCustomer.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dgvHoldCustomer.ThemeStyle.HeaderStyle.ForeColor = Color.Black;
            dgvHoldCustomer.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHoldCustomer.ThemeStyle.HeaderStyle.Height = 40;
            dgvHoldCustomer.ThemeStyle.ReadOnly = false;
            dgvHoldCustomer.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvHoldCustomer.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHoldCustomer.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dgvHoldCustomer.ThemeStyle.RowsStyle.ForeColor = Color.White;
            dgvHoldCustomer.ThemeStyle.RowsStyle.Height = 25;
            dgvHoldCustomer.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvHoldCustomer.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(246, 177, 0);
            dgvHoldCustomer.CellClick += dgvHoldCustomer_CellClick;
            // 
            // btnRemoveAll
            // 
            btnRemoveAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveAll.BackColor = Color.FromArgb(255, 214, 90);
            btnRemoveAll.Cursor = Cursors.Hand;
            btnRemoveAll.FlatAppearance.BorderSize = 0;
            btnRemoveAll.FlatStyle = FlatStyle.Flat;
            btnRemoveAll.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoveAll.ForeColor = Color.Black;
            btnRemoveAll.Location = new Point(633, 454);
            btnRemoveAll.Name = "btnRemoveAll";
            btnRemoveAll.Size = new Size(144, 51);
            btnRemoveAll.TabIndex = 29;
            btnRemoveAll.Text = "Remove All";
            btnRemoveAll.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRemoveAll.UseVisualStyleBackColor = false;
            btnRemoveAll.Click += btnRemoveAll_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.ForeColor = Color.LightCoral;
            guna2HtmlLabel1.Location = new Point(675, 21);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(102, 15);
            guna2HtmlLabel1.TabIndex = 30;
            guna2HtmlLabel1.Text = "Press [ESC] to close";
            // 
            // HoldCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 516);
            ControlBox = false;
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(btnRemoveAll);
            Controls.Add(dgvHoldCustomer);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Movable = false;
            Name = "HoldCustomer";
            SizeGripStyle = SizeGripStyle.Hide;
            Style = MetroFramework.MetroColorStyle.Yellow;
            Load += HoldCustomer_Load;
            KeyDown += HoldCustomer_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvHoldCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvHoldCustomer;
        private Button btnRemoveAll;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}