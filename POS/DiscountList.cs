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
    public partial class DiscountList : MetroFramework.Forms.MetroForm
    {
        private List<Discounts> _discounts;
        public Discounts SelectedDiscount { get; private set; }
        public DiscountList(List<Discounts> discounts)
        {
            InitializeComponent();
            _discounts = discounts;
            CreateDiscountButtons();
        }

        private void CreateDiscountButtons()
        {
            int topPosition = 20;  // Starting vertical position for the first button

            // Create a button for each discount
            foreach (var discount in _discounts)
            {
                var button = new Button
                {
                    Text = $"{discount.Name} ({discount.Percentage}%)",  // Button text shows discount name and percentage
                    Tag = discount,  // Store the discount object in the button's Tag property
                    Width = 200,     // Set a fixed width for all buttons
                    Height = 40,     // Set height for buttons
                    Top = topPosition, // Positioning the buttons vertically
                    Left = 20         // Fixed horizontal position
                };

                // Add event handler for button click
                button.Click += DiscountButton_Click;

                // Add the button to the form
                this.Controls.Add(button);

                // Update the top position for the next button
                topPosition += 50;
            }
        }

        private void DiscountButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                SelectedDiscount = (Discounts)button.Tag; // Get the discount object from the button's Tag
                this.DialogResult = DialogResult.OK; // Close the dialog with OK result
                this.Close(); // Close the form after selecting a discount
            }
        }

        private void DiscountList_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
