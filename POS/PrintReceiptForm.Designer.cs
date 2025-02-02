namespace POS
{
    partial class PrintReceiptForm
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
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnPrint = new Button();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            printDocument = new System.Drawing.Printing.PrintDocument();
            SuspendLayout();
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel2.ForeColor = Color.Black;
            guna2HtmlLabel2.Location = new Point(30, 51);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(354, 27);
            guna2HtmlLabel2.TabIndex = 45;
            guna2HtmlLabel2.Text = "Do you want to print transaction receipt?";
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrint.BackColor = Color.FromArgb(255, 214, 90);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI Semilight", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnPrint.ForeColor = Color.Black;
            btnPrint.Location = new Point(269, 99);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(126, 51);
            btnPrint.TabIndex = 43;
            btnPrint.Text = "Print";
            btnPrint.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.ForeColor = Color.LightCoral;
            guna2HtmlLabel1.Location = new Point(293, 18);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(102, 15);
            guna2HtmlLabel1.TabIndex = 42;
            guna2HtmlLabel1.Text = "Press [ESC] to close";
            // 
            // printDocument
            // 
            printDocument.PrintPage += printDocument_PrintPage;
            // 
            // PrintReceiptForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 173);
            ControlBox = false;
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(btnPrint);
            Controls.Add(guna2HtmlLabel1);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PrintReceiptForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Style = MetroFramework.MetroColorStyle.Yellow;
            KeyDown += PrintReceiptForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Button btnPrint;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}