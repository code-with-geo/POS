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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace POS
{
    public partial class CashDrawer : MetroFramework.Forms.MetroForm
    {
        public int UserId { get; private set; }
        public int LocationId { get; private set; }

        public List<InitialCashList> InitialCashList = new List<InitialCashList>();
        public List<WithdrawalsList> WithdrawalsList = new List<WithdrawalsList>();
        public List<ExpenseList> ExpenseList = new List<ExpenseList>();

        DataTable dt = new DataTable();
        public CashDrawer(int userId, int locationId)
        {
            InitializeComponent();
            UserId = userId;
            LocationId = locationId;
        }

        private void CashDrawer_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public static int GenerateRandomDrawerId()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999); // Random 4-digit number
            return randomNumber;
        }

        private void StartCashDrawer()
        {
            int userCount = DatabaseHelper.GetCashDrawerCountByUserId(UserId);
            if(userCount == 0)
            {
                if (!decimal.TryParse(txtInitialCash.Text, out decimal amount))
                {
                    MessageBox.Show("Invalid initial cash amount entered.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DatabaseHelper.InsertCashDrawerEntry(GenerateRandomDrawerId(), UserId, LocationId, Convert.ToDecimal(txtInitialCash.Text), 0, 0, Convert.ToDecimal(txtInitialCash.Text), Convert.ToDateTime(txtTimeStart.Text));
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the InitialCash form and pass the list to it
            InitialCash initialCashForm = new InitialCash(InitialCashList);
            initialCashForm.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Withdrawals withdrawals = new Withdrawals(WithdrawalsList);
            withdrawals.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            var expenses = new Expenses(ExpenseList);
            var result = expenses.ShowDialog();

            // If the user successfully logged in, set the token
            if (result == DialogResult.OK)
            {
                DisplayExpenses();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {

            StartCashDrawer();


        }

        private void DisplayInitialCash()
        {
            // Calculate the total sum of all initial cash entries
            decimal totalInitialCash = InitialCashList.Sum(entry => entry.Amount);

            // Display the total sum in a label or wherever needed
            MessageBox.Show(totalInitialCash.ToString("C2"));
        }

        private void DisplayWithdrawals()
        {
            // Calculate the total sum of all initial cash entries
            decimal totalWithdrawals = WithdrawalsList.Sum(entry => entry.Amount);

            // Display the total sum in a label or wherever needed
          txtWithdrawals.Text  = totalWithdrawals.ToString("C2");
        }

        private void DisplayExpenses()
        {
            // Calculate the total sum of all initial cash entries
            decimal totalExpense = ExpenseList.Sum(entry => entry.Amount);

            // Display the total sum in a label or wherever needed
            txtExpense.Text = totalExpense.ToString("C2");
        }

        private void CashDrawer_Load(object sender, EventArgs e)
        {
            dt  = DatabaseHelper.GetEmployeeByUserIdAndLocationId(UserId,LocationId);
            if (dt.Rows.Count > 0)
            {
                txtLocationId.Text = dt.Rows[0]["LocationId"].ToString();
                txtCashier.Text = dt.Rows[0]["Name"].ToString();
                txtTimeStart.Text = DateTime.Now.ToString();
            }
            DisplayWithdrawals();
            DisplayExpenses();
        }
    }
}
