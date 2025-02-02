using Newtonsoft.Json;
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
    public partial class DigitalPayments : MetroFramework.Forms.MetroForm
    {
        public int UserId { get; private set; }
        public int LocationId { get; private set; }
        public int CustomerId { get; private set; }
        public string Token { get; private set; }
        private List<Cart> Cart;
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalVatSale { get; set; }
        public decimal TotalVatAmount { get; set; }
        public decimal TotalVatExempt { get; set; }
        public decimal AmountChange { get; set; }
        public decimal AmountReceived { get; set; }
        public int PaymentType { get; set; }
        public DigitalPayments(int userId, int locationId, int customerId, List<Cart> cart, int paymentType)
        {
            InitializeComponent();
            UserId = userId;
            LocationId = locationId;
            CustomerId = customerId;
            Cart = cart;
            PaymentType = paymentType;
        }

        private void EWallet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private async Task<bool> AddOrderAsync(int locationId, int userId, int customerId, int transactionType, int paymentType,
                                      decimal totalVatSale, decimal totalVatAmount, decimal totalVatExempt,
                                      string accountName, string accountNumber, string referenceNo,
                                      decimal digitalPaymentAmount)
        {
            try
            {
                DataTable data = new DataTable();
                data = DatabaseHelper.GetEmployeeByUserIdAndLocationId(UserId, LocationId);
                if (data.Rows.Count > 0)
                {
                    Token = data.Rows[0]["Token"].ToString();
                }
                // API endpoint
                string apiUrl = "https://localhost:7148/api/orders";

                using (var _httpClient = new HttpClient())
                {
                    // Set Authorization header
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);

                    // Prepare the products array from the _cart list
                    var products = Cart.Select(cartItem => new
                    {
                        ProductId = cartItem.Id,
                        Quantity = cartItem.Quantity,
                        DiscountId = cartItem.DiscountId
                    }).ToList();

                    // Create the request body
                    var requestBody = new
                    {
                        UserId = userId,
                        CustomerId = customerId,
                        LocationId = locationId,
                        TransactionType = transactionType,
                        PaymentType = paymentType,
                        TotalVatSale = totalVatSale,
                        TotalVatAmount = totalVatAmount,
                        TotalVatExempt = totalVatExempt,
                        AccountName = (paymentType == 1 || paymentType == 2) ? accountName : "",
                        AccountNumber = (paymentType == 1 || paymentType == 2) ? accountNumber : "",
                        ReferenceNo = (paymentType == 1 || paymentType == 2) ? referenceNo : "",
                        DigitalPaymentAmount = (paymentType == 1 || paymentType == 2) ? digitalPaymentAmount : 0,
                        Products = products
                    };

                    var json = JsonConvert.SerializeObject(requestBody);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Send POST request
                    var response = await _httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize the response JSON into OrderResponse class
                        string responseString = await response.Content.ReadAsStringAsync();
                        var orderResponse = JsonConvert.DeserializeObject<OrderResponse>(responseString);

                        InvoiceNo = orderResponse.InvoiceNo;
                        TotalAmount = orderResponse.TotalAmount;
                        TotalDiscount = orderResponse.TotalDiscount;
                        TotalVatSale = orderResponse.TotalVatSale;
                        TotalVatAmount = orderResponse.TotalVatAmount;
                        TotalVatExempt = orderResponse.TotalVatExempt;

                        MessageBox.Show($"Order created successfully!",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return true; // Return the order details
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Failed to add order.\nError: {response.StatusCode}\nDetails: {errorResponse}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Indicate failure
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Indicate failure
            }
        }

        private async void btnContinue_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amountReceived))
            {

           
            decimal vatSale = Cart.Any(p => p.IsVat == 1) ? Cart.Where(p => p.IsVat == 1).Sum(p => p.SubTotal) : 0;
            decimal vatAmount = Cart.Any() ? Cart.Sum(p => p.VatAmount) : 0;
            decimal vatExempt = Cart.Any(p => p.IsVat == 0) ? Cart.Where(p => p.IsVat == 0).Sum(p => p.SubTotal) : 0;

            bool result = await AddOrderAsync(
            locationId: LocationId,
            userId: UserId,
            customerId: CustomerId,
            transactionType: 1,
            paymentType: PaymentType,
            totalVatSale: vatSale,
            totalVatAmount: vatAmount,
            totalVatExempt: vatExempt,
            accountName: txtAccountName.Text,
            accountNumber: txtAccountNumber.Text,
            referenceNo: txtReferenceNo.Text,
            digitalPaymentAmount: amountReceived
             );

            if (result)
            {
                var print = new PrintReceiptForm(Cart, InvoiceNo, TotalAmount, TotalDiscount, TotalVatSale, TotalVatAmount, TotalVatExempt, AmountChange, AmountReceived);
                this.Visible = false;
                var openPrint = print.ShowDialog();

                if (openPrint == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                }
            }
        }
    }
}
