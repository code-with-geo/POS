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
    public partial class Customer : MetroFramework.Forms.MetroForm
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.N)
            {
                NewCustomer customer = new NewCustomer();
                customer.ShowDialog();
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            NewCustomer customer = new NewCustomer();
            customer.ShowDialog();
        }
    }
}
