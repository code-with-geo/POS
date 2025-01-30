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
    public partial class Withdrawals : MetroFramework.Forms.MetroForm
    {
        private List<WithdrawalsList> withdrawalsLists;
        public Withdrawals(List<WithdrawalsList> withdrawalsLists)
        {
            InitializeComponent();
            this.withdrawalsLists = withdrawalsLists;
        }

        private void Withdrawals_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text) || string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Invalid amount entered.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newWithdrawals = new WithdrawalsList()
            {
                Description = txtDescription.Text,
                Amount = amount,
                Remarks = txtRemarks.Text
            };

            withdrawalsLists.Add(newWithdrawals);
            this.Close();
        }
    }
}
