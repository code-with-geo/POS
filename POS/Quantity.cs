using Newtonsoft.Json.Linq;
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
    public partial class Quantity : MetroFramework.Forms.MetroForm
    {
        public int ChangeQuantity { get; private set; }
        public Quantity()
        {
            InitializeComponent();

        }
        private void Quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                ChangeQuantity = Convert.ToInt32(udQuantity.Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Quantity_Load(object sender, EventArgs e)
        {
            udQuantity.Focus();
        }
    }
}
