namespace POS
{
    partial class InitialCash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialCash));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnRemoveAll = new Button();
            txtRemarks = new Guna.UI2.WinForms.Guna2TextBox();
            txtAmount = new Guna.UI2.WinForms.Guna2TextBox();
            txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // btnRemoveAll
            // 
            resources.ApplyResources(btnRemoveAll, "btnRemoveAll");
            btnRemoveAll.BackColor = Color.FromArgb(255, 214, 90);
            btnRemoveAll.Cursor = Cursors.Hand;
            btnRemoveAll.FlatAppearance.BorderSize = 0;
            btnRemoveAll.ForeColor = Color.Black;
            btnRemoveAll.Name = "btnRemoveAll";
            btnRemoveAll.UseVisualStyleBackColor = false;
            btnRemoveAll.Click += btnRemoveAll_Click;
            // 
            // txtRemarks
            // 
            resources.ApplyResources(txtRemarks, "txtRemarks");
            txtRemarks.BackColor = Color.White;
            txtRemarks.BorderRadius = 5;
            txtRemarks.CustomizableEdges = customizableEdges1;
            txtRemarks.DefaultText = "";
            txtRemarks.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtRemarks.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtRemarks.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtRemarks.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtRemarks.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRemarks.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRemarks.Name = "txtRemarks";
            txtRemarks.PasswordChar = '\0';
            txtRemarks.PlaceholderText = "Remarks";
            txtRemarks.SelectedText = "";
            txtRemarks.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtRemarks.TextAlign = HorizontalAlignment.Center;
            // 
            // txtAmount
            // 
            resources.ApplyResources(txtAmount, "txtAmount");
            txtAmount.BackColor = Color.White;
            txtAmount.BorderRadius = 5;
            txtAmount.CustomizableEdges = customizableEdges3;
            txtAmount.DefaultText = "";
            txtAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtAmount.Name = "txtAmount";
            txtAmount.PasswordChar = '\0';
            txtAmount.PlaceholderText = "Amount";
            txtAmount.SelectedText = "";
            txtAmount.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // txtDescription
            // 
            resources.ApplyResources(txtDescription, "txtDescription");
            txtDescription.BackColor = Color.White;
            txtDescription.BorderRadius = 5;
            txtDescription.CustomizableEdges = customizableEdges5;
            txtDescription.DefaultText = "";
            txtDescription.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDescription.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDescription.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDescription.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDescription.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDescription.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDescription.Name = "txtDescription";
            txtDescription.PasswordChar = '\0';
            txtDescription.PlaceholderText = "Description";
            txtDescription.SelectedText = "";
            txtDescription.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtDescription.TextAlign = HorizontalAlignment.Center;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            resources.ApplyResources(guna2HtmlLabel1, "guna2HtmlLabel1");
            guna2HtmlLabel1.ForeColor = Color.LightCoral;
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            // 
            // InitialCash
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRemoveAll);
            Controls.Add(txtRemarks);
            Controls.Add(txtAmount);
            Controls.Add(txtDescription);
            Controls.Add(guna2HtmlLabel1);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Movable = false;
            Name = "InitialCash";
            Resizable = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Style = MetroFramework.MetroColorStyle.Yellow;
            KeyDown += InitialCash_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRemoveAll;
        private Guna.UI2.WinForms.Guna2TextBox txtRemarks;
        private Guna.UI2.WinForms.Guna2TextBox txtAmount;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}