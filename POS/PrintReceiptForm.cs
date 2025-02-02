using POS.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class PrintReceiptForm : MetroFramework.Forms.MetroForm
    {
        private List<Cart> Cart;
        public string InvoiceNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalVatSale { get; set; }
        public decimal TotalVatAmount { get; set; }
        public decimal TotalVatExempt { get; set; }
        public decimal AmountChange { get; set; }
        public decimal AmountReceived { get; set; }

        private string receiptText; // Store the receipt text
        public PrintReceiptForm(List<Cart> cart, string invoiceNo, decimal totalAmount, decimal totalDiscount, decimal totalVatSale, decimal totalVatAmount, decimal totalVatExempt, decimal amountChange, decimal amountReceived)
        {
            InitializeComponent();
            Cart = cart;
            InvoiceNo = invoiceNo;
            TotalAmount = totalAmount;
            TotalDiscount = totalDiscount;
            TotalVatSale = totalVatSale;
            TotalVatAmount = totalVatAmount;
            TotalVatExempt = totalVatExempt;
            AmountChange = amountChange;
            AmountReceived = amountReceived;
        }

        public void PrintReceipt(string invoiceNumber, decimal totalAmount, decimal cashReceived, decimal change)
        {
            receiptText = GenerateReceipt(invoiceNumber, totalAmount, cashReceived, change, Cart);

            // Configure PrintDocument and Print automatically
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);

            // Set the default printer and print automatically
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.PrinterSettings.IsValid)
            {
                printDocument.Print(); // Automatically prints without preview
            }
            else
            {
                MessageBox.Show("No valid printer found. Please check your printer settings.", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateReceipt(string invoiceNumber, decimal totalAmount, decimal cashReceived, decimal change, List<Cart> cart)
        {
            StringBuilder receipt = new StringBuilder();

            receipt.AppendLine("=====================================");
            receipt.AppendLine("          My Store Receipt          ");
            receipt.AppendLine("=====================================");
            receipt.AppendLine($" Invoice No: {invoiceNumber}");
            receipt.AppendLine($" Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            receipt.AppendLine("-------------------------------------");
            receipt.AppendLine($"{"Item",-20} {"Qty",-5} {"Subtotal",10}"); // Column headers aligned
            receipt.AppendLine("-------------------------------------");

            // Format the items dynamically
            foreach (var item in cart)
            {
                receipt.AppendLine($"{item.Name,-20} x{item.Quantity,-4} {item.SubTotal,10:C2}");
            }

            receipt.AppendLine("-------------------------------------");
            receipt.AppendLine($"{"Total Discount:",-25} {TotalDiscount,10:C2}");
            receipt.AppendLine($"{"Total VAT Amount:",-25} {TotalVatAmount,10:C2}");
            receipt.AppendLine($"{"Total VAT Exempt:",-25} {TotalVatExempt,10:C2}");
            receipt.AppendLine($"{"Total VAT Sale:",-25} {TotalVatSale,10:C2}");
            receipt.AppendLine($"{"Cash Received:",-25} {cashReceived,10:C2}");
            receipt.AppendLine($"{"Change:",-25} {change,10:C2}");
            receipt.AppendLine("=====================================");
            receipt.AppendLine("     THANK YOU FOR YOUR PURCHASE!    ");
            receipt.AppendLine("=====================================");

            return receipt.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReceipt(InvoiceNo, TotalAmount, AmountReceived, AmountChange);
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Courier New", 12);
            float yPos = 10;
            float leftMargin = e.MarginBounds.Left;

            using (StringReader reader = new StringReader(receiptText))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    e.Graphics.DrawString(line, font, Brushes.Black, leftMargin, yPos);
                    yPos += font.GetHeight(e.Graphics);
                }
            }
        }

        private void PrintReceiptForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
