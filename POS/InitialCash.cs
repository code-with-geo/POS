using POS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class InitialCash : MetroFramework.Forms.MetroForm
    {
        private List<InitialCashList> initialCashList;
        public InitialCash(List<InitialCashList> initialCash)
        {
            InitializeComponent();
            initialCashList = initialCash;
        }

        private void InitialCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtDescription.Text) || string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate the amount entered is a valid decimal
            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Invalid amount entered.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create an InitialCash object
            var newInitialCash = new InitialCashList()
            {
                Description = txtDescription.Text,
                Amount = amount,
                Remarks = txtRemarks.Text
            };

            // Add the new entry to the list
            initialCashList.Add(newInitialCash);

            // Optionally, update the UI or notify the user that the entry was added
            MessageBox.Show("Initial cash entry added.");

            // Close the form after saving
            this.Close();
        }
    }
}
