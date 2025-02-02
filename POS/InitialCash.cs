using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json.Linq;
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
        public int UserId { get; private set; }
        public int LocationId { get; private set; }
        public string Token { get; private set; }
        public int DrawerId { get; private set; }
        public InitialCash(int userId, int locationId, string token, int drawerId)
        {
            InitializeComponent();
            UserId = userId;
            LocationId = locationId;
            Token = token;
            DrawerId = drawerId;
        }

        private void InitialCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private async void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text) || string.IsNullOrWhiteSpace(txtAmount.Text) || string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Invalid amount entered.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            await DatabaseHelper.AddInitialCashAsync(DrawerId, amount, txtRemarks.Text, txtDescription.Text, Token);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
