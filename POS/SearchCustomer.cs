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
    public partial class SearchCustomer : MetroFramework.Forms.MetroForm
    {
        public int UserId { get; private set; }
        public int LocationId { get; private set; }
        public int CustomerId { get; private set; }
        private List<Cart> Cart;
        public SearchCustomer(int userId,int locationId, List<Cart> cart)
        {
            InitializeComponent();
            UserId = userId;
            LocationId = locationId;
            Cart = cart;
        }

        private void SearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CustomerId.ToString());
            // Tenders tenders = new Tenders();
            //tenders.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            var customer = new Customer(UserId,LocationId);
            var result = customer.ShowDialog();
            if (result == DialogResult.OK)
            {
                CustomerId = customer.CustomerId;
                var tender = new Tenders(UserId, LocationId, CustomerId, Cart);
                var showTender = tender.ShowDialog();
                if (showTender == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
