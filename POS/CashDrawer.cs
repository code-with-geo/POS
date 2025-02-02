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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace POS
{
    public partial class CashDrawer : MetroFramework.Forms.MetroForm
    {
        public int UserId { get; private set; }
        public int LocationId { get; private set; }
        public string Token { get; private set; }
        public List<InitialCashList> InitialCashList = new List<InitialCashList>();
        public List<WithdrawalsList> WithdrawalsList = new List<WithdrawalsList>();
        public List<ExpenseList> ExpenseList = new List<ExpenseList>();
        public int DrawerId { get; private set; }
        public bool isStartCashDrawer = false;

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
            var initialCash = new InitialCash(UserId, LocationId, Token, DrawerId);
            var result = initialCash.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadOngoingCashDrawerData();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var withdrawals = new Withdrawals(UserId,LocationId,Token, DrawerId);
            var result = withdrawals.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadOngoingCashDrawerData();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            var expenses = new Expenses(UserId, LocationId, Token, DrawerId);
            var result = expenses.ShowDialog();
            if(result == DialogResult.OK)
            {
                LoadOngoingCashDrawerData();
            }
        }

        private async void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (btnRemoveAll.Text == "Start")
            {
                if (decimal.TryParse(txtInitialCash.Text, out decimal amount))
                {
                   await DatabaseHelper.StartCashDrawerAsync(UserId, LocationId, amount, Token);
                   await DatabaseHelper.FetchAndStoreOngoingCashDrawerAsync(UserId, LocationId, Token);
                   LoadOngoingCashDrawerData();
                }
            }else
            {
                await DatabaseHelper.EndCashDrawerAsync(DrawerId, Token);
                this.Close();

            }
        }

        private void DisplayInitialCash()
        {
            decimal totalInitialCash = InitialCashList.Sum(entry => entry.Amount);
        }

        private void DisplayWithdrawals()
        {
            decimal totalWithdrawals = WithdrawalsList.Sum(entry => entry.Amount);
            txtWithdrawals.Text  = totalWithdrawals.ToString("C2");
        }

        private void DisplayExpenses()
        {
            decimal totalExpense = ExpenseList.Sum(entry => entry.Amount);
            txtExpense.Text = totalExpense.ToString("C2");
        }

        private async void CashDrawer_Load(object sender, EventArgs e)
        {
            dt  = DatabaseHelper.GetEmployeeByUserIdAndLocationId(UserId,LocationId);
            if (dt.Rows.Count > 0)
            {
                if (DatabaseHelper.HasOngoingCashDrawerLocal(UserId, LocationId))
                {
                    txtLocationId.Text = dt.Rows[0]["LocationId"].ToString();
                    txtCashier.Text = dt.Rows[0]["Name"].ToString();
                    Token = dt.Rows[0]["Token"].ToString();
                    await DatabaseHelper.FetchAndStoreOngoingCashDrawerAsync(UserId, LocationId, Token);
                    LoadOngoingCashDrawerData();
                }
                else
                {
                    btnRemoveAll.Text = "Start";
                    txtLocationId.Text = dt.Rows[0]["LocationId"].ToString();
                    txtCashier.Text = dt.Rows[0]["Name"].ToString();
                    txtTimeStart.Text = DateTime.Now.ToString();
                    Token = dt.Rows[0]["Token"].ToString();
                    txtWithdrawals.Text = 0m.ToString("C2");
                    txtExpense.Text = 0m.ToString("C2");
                    txtTotalSale.Text = 0m.ToString("C2");
                    txtCashDrawer.Text = 0m.ToString("C2");
                }
            }
        }

        private void LoadOngoingCashDrawerData()
        {
            DataTable dt = DatabaseHelper.GetOngoingCashDrawer();

            if (dt.Rows.Count > 0)
            {
               btnRemoveAll.Text = "End";
                DrawerId = Convert.ToInt32(dt.Rows[0]["DrawerId"].ToString());
                txtTimeStart.Text = Convert.ToDateTime(dt.Rows[0]["TimeStart"]).ToString("g"); // Formats DateTime
                txtWithdrawals.Text = Convert.ToDecimal(dt.Rows[0]["Withdrawals"]).ToString("C2");
                txtExpense.Text = Convert.ToDecimal(dt.Rows[0]["Expenses"]).ToString("C2");
                txtTotalSale.Text = Convert.ToDecimal(dt.Rows[0]["TotalSales"]).ToString("C2");
                txtCashDrawer.Text = Convert.ToDecimal(dt.Rows[0]["DrawerCash"]).ToString("C2");
                txtInitialCash.Text = Convert.ToDecimal(dt.Rows[0]["InitialCash"]).ToString("C2");
            }
            else
            {
                MessageBox.Show("No ongoing cash drawer found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
