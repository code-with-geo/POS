namespace POS
{
    partial class Quantity
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
            udQuantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)udQuantity).BeginInit();
            SuspendLayout();
            // 
            // udQuantity
            // 
            udQuantity.BackColor = Color.Transparent;
            udQuantity.BorderRadius = 5;
            udQuantity.CustomizableEdges = customizableEdges1;
            udQuantity.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            udQuantity.Location = new Point(14, 26);
            udQuantity.Margin = new Padding(9);
            udQuantity.Name = "udQuantity";
            udQuantity.ShadowDecoration.CustomizableEdges = customizableEdges2;
            udQuantity.Size = new Size(156, 116);
            udQuantity.TabIndex = 0;
            udQuantity.TextOffset = new Point(20, 0);
            udQuantity.UpDownButtonFillColor = Color.White;
            // 
            // Quantity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(187, 161);
            Controls.Add(udQuantity);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Movable = false;
            Name = "Quantity";
            Resizable = false;
            SizeGripStyle = SizeGripStyle.Show;
            Style = MetroFramework.MetroColorStyle.Yellow;
            Load += Quantity_Load;
            KeyDown += Quantity_KeyDown;
            ((System.ComponentModel.ISupportInitialize)udQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2NumericUpDown udQuantity;
    }
}