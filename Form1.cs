using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System_Group_2
{
    public partial class Form1 : Form
    {
        Double FirstNumber;
        Double SecondNumber;
        Double Answer;
        String op;

        double[] i = new double[5];

        Double British_Pound = 0.0017;
        Double US_Dollar = 0.0024;
        Double Ghana_Cedis = 0.015;
        Double Japanese_Yen= 0.27;
        Double Canadian_Dollar = 0.0031;
        Double Indian_Rupee = 0.18;
        Double Chinese_Yuan = 0.016;
        Double Euro = 0.0020;
        Double mcSubTotal;
        Double mcTotal;
        Double MealCost;
        double buyDrink;

        const double Afang_Price = 2500;
        const double OfeNsala_Price = 4000;
        const double Pepper_Soup_Price = 3500;
        const double Nkwobi_Price = 5000;
        const double Drinks_Price = 200;
        const double Delivery_Price = 150;
        const double Tax_rate = 0.2;
        public Form1()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void tbOpen_Click(object sender, EventArgs e)
        {
            //This Code will open Text Files
            OpenFileDialog openFile = new OpenFileDialog();
            
            openFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                rtfReceipt.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText);
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            // This Code will Save Text Files
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "Notepad Text";
            saveFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFile.FileName))
                    sw.WriteLine(rtfReceipt.Text);
            }
        }

        private void tbCut_Click(object sender, EventArgs e)
        {
            // This code will cut Text
            if (rtfReceipt.SelectedText != "")
            {
                rtfReceipt.Cut();
            }
        }

        private void tbCopy_Click(object sender, EventArgs e)
        {
            // This code will Copy Text
            if (rtfReceipt.SelectionLength > 0)
            {
                rtfReceipt.Copy();
            }
        }

        private void tbPaste_Click(object sender, EventArgs e)
        {
            // This Code will Paste Text
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text)== true)
            {
                if (rtfReceipt.SelectionLength > 0)
                {
                    rtfReceipt.SelectionStart = rtfReceipt.SelectionStart + rtfReceipt.SelectionLength;
                }
                rtfReceipt.Paste();
            }
        }

        private void tbBold_Click(object sender, EventArgs e)
        {
            // This code will make Text Bold
            Font bFont = new Font(rtfReceipt.Font, FontStyle.Bold);
            Font rFont = new Font(rtfReceipt.Font, FontStyle.Regular);

            if (rtfReceipt.SelectedText.Length == 0)
                return;
            if (rtfReceipt.SelectionFont.Bold)
            {
                rtfReceipt.SelectionFont = rFont;
            }
            else
            {
                rtfReceipt.SelectionFont = bFont;
            }
        }

        private void tbItalic_Click(object sender, EventArgs e)
        {
            // This Code will make Text Italic
            Font iFont = new Font(rtfReceipt.Font, FontStyle.Italic);
            Font rFont = new Font(rtfReceipt.Font, FontStyle.Regular);

            if (rtfReceipt.SelectedText.Length == 0)
                return;
            if (rtfReceipt.SelectionFont.Italic)
            {
                rtfReceipt.SelectionFont = rFont;
            }
            else
            {
                rtfReceipt.SelectionFont = iFont;
            }
        }

        private void tbUnderLine_Click(object sender, EventArgs e)
        {
            Font uFont = new Font(rtfReceipt.Font, FontStyle.Underline);
            Font rFont = new Font(rtfReceipt.Font, FontStyle.Regular);

            if (rtfReceipt.SelectedText.Length == 0)
                return;
            if (rtfReceipt.SelectionFont.Underline)
            {
                rtfReceipt.SelectionFont = rFont;
            }
            else
            {
                rtfReceipt.SelectionFont = uFont;
            }
        }

        private void tbAlignLeft_Click(object sender, EventArgs e)
        {
            // This Code will Align Text Left
            rtfReceipt.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void tbAlignCenter_Click(object sender, EventArgs e)
        {
            // This Code will Align Text Center
            rtfReceipt.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void tbAlignRight_Click(object sender, EventArgs e)
        {
            // This Code will Align Text Right
            rtfReceipt.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void tbClear_Click(object sender, EventArgs e)
        {
            rtfReceipt.Clear();
        }

        private void button_click(object sender, EventArgs e)
        {
            // Calaculator Number Click Event
            Button Numbers = (Button)sender;

            if (lblDisplay.Text == "0")
            {
                lblDisplay.Text = Numbers.Text;
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text + Numbers.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            lblShowOp.Text = "";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 0)
            {
                lblDisplay.Text = lblDisplay.Text.Remove(lblDisplay.Text.Length - 1, 1);
            }
            else
            {
                if ((lblShowOp.Text.Length > 0) && (lblDisplay.Text != "0"))
                {
                    lblShowOp.Text = lblShowOp.Text.Remove(lblShowOp.Text.Length - 1, 1);
                    //lblDisplay.Text = "0";

                }
                else if ((lblShowOp.Text.Length) <= 0 | (lblDisplay.Text=="0"))
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void Arithmetic_ops(object sender, EventArgs e)
        {
            double displaynumber;
            if (double.TryParse(lblDisplay.Text, out displaynumber))
            {
                Button operation = (Button)sender;
                FirstNumber = Double.Parse(lblDisplay.Text);
                lblDisplay.Text = "";
                op = operation.Text;
                lblShowOp.Text = System.Convert.ToString(FirstNumber) + "" + op;
            } 
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            Double display_number;
            if (double.TryParse(lblDisplay.Text, out display_number))
            {
                lblShowOp.Text = "";
                SecondNumber = Double.Parse(lblDisplay.Text);
                switch (op)
                {
                    case "+":
                        Answer = (FirstNumber + SecondNumber);
                        lblDisplay.Text = System.Convert.ToString(Answer);
                        break;

                    case "-":
                        Answer = (FirstNumber - SecondNumber);
                        lblDisplay.Text = System.Convert.ToString(Answer);
                        break;

                    case "*":
                        Answer = (FirstNumber * SecondNumber);
                        lblDisplay.Text = System.Convert.ToString(Answer);
                        break;

                    case "/":
                        Answer = (FirstNumber / SecondNumber);
                        lblDisplay.Text = System.Convert.ToString(Answer);
                        break;

                }
            }
        }

        private void lblShowOp_Click(object sender, EventArgs e)
        {

        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            btnCurrency.Visible = false;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            Double Currency;
            Double Conversion;
            if (double.TryParse(txtConvert.Text, out Currency))

            {
                

                Double Nigerian_Naira = Double.Parse(txtConvert.Text);

                if (cmbCurrency.Text == "Select Country ......")
                {
                    errorProvider2.SetError(cmbCurrency, "Insert a Valid Country");
                    lblConvert.Text = "";
                }
                else
                {
                    errorProvider2.SetError(cmbCurrency,null);
                }

                if (cmbCurrency.Text == "UK")
                {
                    lblConvert.Text = System.Convert.ToString(("£ " + British_Pound * Nigerian_Naira));
                }

                if (cmbCurrency.Text == "Europe")
                {
                    lblConvert.Text = System.Convert.ToString(("€ " + Nigerian_Naira * Euro));
                }

                if (cmbCurrency.Text == "USA")
                {
                    lblConvert.Text = System.Convert.ToString(("$ " + Nigerian_Naira * US_Dollar));
                }

                if (cmbCurrency.Text == "Canada")
                {
                    lblConvert.Text = System.Convert.ToString(("C$ " + Nigerian_Naira * Canadian_Dollar));
                }

                if (cmbCurrency.Text == "Japan")
                {
                    lblConvert.Text = System.Convert.ToString(("J¥ " + Nigerian_Naira * Japanese_Yen));
                }

                if (cmbCurrency.Text == "India")
                {
                    lblConvert.Text = System.Convert.ToString(("₹ " + Nigerian_Naira * Indian_Rupee));
                }

                if (cmbCurrency.Text == "Ghana")
                {
                    lblConvert.Text = System.Convert.ToString(("GH₵  " + Nigerian_Naira * Ghana_Cedis));
                }

                if (cmbCurrency.Text == "China")
                {
                    lblConvert.Text = System.Convert.ToString(("C¥ " + Nigerian_Naira * Chinese_Yuan));

                }


                if (double.TryParse(txtConvert.Text, out Conversion))
                {
                    if (double.Parse(txtConvert.Text) >= 0)
                    {
                        errorProvider2.SetError(txtConvert,null);

                    }

                }
            }
            else
            {
               
                errorProvider2.SetError(txtConvert, "Enter a number");
                lblConvert.Text = "";

                if (double.TryParse(txtConvert.Text, out Conversion))
                {
                    if (double.Parse(txtConvert.Text) >= 0)
                    {
                        errorProvider2.SetError(txtConvert,null);

                    }

                }
            }

            





        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnCurrency.Visible = true;
            txtConvert.Text = "0";
            lblConvert.Text = "";
            cmbCurrency.Text = "Select Country ......";
            errorProvider2.Clear();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            const string message = "Please confirm if you want to exit?";
            const string closing = "Closing Program";
            var result = MessageBox.Show(message, closing, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAfang.Text = "0";
            txtOfeNsala.Text = "0";
            txtPeppersoup.Text = "0";
            txtNkwobi.Text = "0";
            txtDelivery.Text = "0";
            txtConvert.Text = "0";
            lblConvert.Text = "";
            lblDisplay.Text = "";
            lblDrinkSold.Text = "0";
            numDrink.Text = "0";
            lblDeliveryCost.Text = "";
            lblMealCost.Text = "";
            lblShowOp.Text = "";
            lblSubTotal.Text = "";
            lblTax.Text = "";
            lblTotal.Text = "";
            lblConvert.Text = "";
            cmbCurrency.Text = "Select Country ......";
            cboDrinks.Text = "Select Drink";
            rtfReceipt.Clear();

            chkAfang.Checked = false;
            chkNkwobi.Checked = false;
            chkOfeNsala.Checked = false;
            chkPepperSoup.Checked = false;
            errorProvider1.Clear();
        }

        

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Double AfangCost;
            Double OfeNsalaCost;
            Double CatFishPepperSoupCost;
            Double NkwobiCost;
            Double ItemAfang;
            Double ItemOfeNsala;
            Double ItemCatFishPepperSoup;
            Double ItemNkwobi;
            //Double ItemDelivery;
            //Double ItemMileage;
            //Double MealCostC;
            Double MealCostF;
            Double MealCostB;
            Double MealCostD;
            Double MealCostE;
            //Double iDelivery;
            //Double DrinksOrder;
            Double cTax;
            Double TotalAmount;

            int NumberofOrder;
            AfangCost = Afang_Price;
            NkwobiCost = Nkwobi_Price;
            CatFishPepperSoupCost = Pepper_Soup_Price;
            OfeNsalaCost = OfeNsala_Price;

            if (chkAfang.Checked)
            {
                AfangCost = Afang_Price;
            }

            if (chkNkwobi.Checked)
            {
                NkwobiCost = Nkwobi_Price;
            }

            if (chkOfeNsala.Checked)
            {
                OfeNsalaCost = OfeNsala_Price;
            }

            if (chkNkwobi.Checked)
            {
                NkwobiCost = Nkwobi_Price;
            }

            if (chkPepperSoup.Checked)
            {
                CatFishPepperSoupCost = Pepper_Soup_Price;
            }


            if (int.TryParse(txtAfang.Text, out NumberofOrder))
            {
                ItemAfang = Double.Parse(txtAfang.Text);
                MealCostF = AfangCost * ItemAfang;
              

                if (int.TryParse(txtOfeNsala.Text, out NumberofOrder))
                {
                    ItemOfeNsala = Double.Parse(txtOfeNsala.Text);
                    MealCostB = OfeNsalaCost * ItemOfeNsala;
                  

                    if (int.TryParse(txtPeppersoup.Text, out NumberofOrder))
                    {
                        ItemCatFishPepperSoup = Double.Parse(txtPeppersoup.Text);
                        MealCostD = CatFishPepperSoupCost * ItemCatFishPepperSoup;
                        

                        if (int.TryParse(txtNkwobi.Text, out NumberofOrder))
                        {
                            ItemNkwobi = Double.Parse(txtNkwobi.Text);
                            MealCostE = NkwobiCost * ItemNkwobi;

                            // Add Delivery
                            lblDeliveryCost.Text = System.Convert.ToString(txtDelivery.Text);
                            double delivery = Double.Parse(lblDeliveryCost.Text);
                            delivery = Delivery_Price * delivery;
                            lblDeliveryCost.Text = Convert.ToString(delivery);

                            //Add Drinks
                            String numDrinks = System.Convert.ToString(numDrink.Text);
                 
                            //double buyDrink = Double.Parse(lblDrinkSold.Text);
                            double addDrink = Double.Parse(numDrinks);
                            lblDrinkSold.Text = System.Convert.ToString(buyDrink * addDrink);

                            // Final Sumup (Total = Tax + Subtotal + Delivery + Drink)
                            MealCost = MealCostF + MealCostB + MealCostD + MealCostE;
                            mcSubTotal = MealCostF + MealCostB + MealCostD + MealCostE + delivery + (buyDrink * addDrink);
                            lblSubTotal.Text = Convert.ToString( mcSubTotal);
                            lblMealCost.Text = Convert.ToString(MealCost);
                            cTax = (mcSubTotal * Tax_rate)/100;
                            lblTax.Text = Convert.ToString(cTax);
                            lblTotal.Text = Convert.ToString(mcSubTotal + cTax);
                            //lblDrinkSold.Text = System.Convert.ToString(buyDrink);
                        }



                    }

                }
            }

            //=============================Receipt Code =====================
            rtfReceipt.Clear();

            rtfReceipt.AppendText(Environment.NewLine);
            rtfReceipt.AppendText("-------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("\t" + "Group 2 Restaurant " + Environment.NewLine);
            rtfReceipt.AppendText("Time: " + "\t\t\t" + "        " + lblTime.Text + Environment.NewLine);
            rtfReceipt.AppendText("Date:" + "\t\t" + "            " + lblDate.Text + Environment.NewLine);
            rtfReceipt.AppendText("Afang Soup:" + "\t\t\t" + txtAfang.Text + " " + Environment.NewLine);

            rtfReceipt.AppendText("Ofe Nsala:" + "\t\t\t" + txtOfeNsala.Text + " " + Environment.NewLine);
            rtfReceipt.AppendText("Nkwobi:" + "\t\t\t\t" + txtNkwobi.Text + " " + Environment.NewLine);
            rtfReceipt.AppendText("Cat Fish Pepper Soup:" + "\t\t" + txtPeppersoup.Text + " " + Environment.NewLine);
            rtfReceipt.AppendText("Drinks:" + "\t\t\t\t" + numDrink.Text + Environment.NewLine + Environment.NewLine);
            rtfReceipt.AppendText("Home Delivery:" + "\t\t\t" + txtDelivery.Text + Environment.NewLine);
            rtfReceipt.AppendText("Sub Total:" + "\t\t" + "         N" + lblSubTotal.Text + Environment.NewLine + Environment.NewLine);

            rtfReceipt.AppendText("Tax:" + "\t\t\t" + "         N" + lblTax.Text + Environment.NewLine);

            rtfReceipt.AppendText("Total:" + "\t\t\t" + "         N" + lblTotal.Text + Environment.NewLine + Environment.NewLine);
            rtfReceipt.AppendText("-------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("\t\t THANK YOU " + Environment.NewLine);
            rtfReceipt.AppendText("-------------------------------------------------" + Environment.NewLine);

            







            //=======================Error Handler============================================================

            // Error Exception For Afang
            if (int.TryParse(txtAfang.Text, out NumberofOrder) /*&& (chkAfang.Checked = true)*/)
            {
                if (int.Parse(txtAfang.Text) == 0)
                {
                    errorProvider1.SetError(txtAfang, null);
                }

                if (int.Parse(txtAfang.Text) > 0)
                {
                    chkAfang.Checked = true;
                    errorProvider1.SetError(txtAfang,null);
                }
                else
                {
                    chkAfang.Checked = false;
                }
            }
            else
            {
                errorProvider1.SetError(txtAfang, "Enter a number");
                chkAfang.Checked = false;
                lblMealCost.Text = "";
                lblSubTotal.Text = "";
                lblTax.Text = "";
                lblTotal.Text = "";
            }

            // Error Exception for txtOfeNsala
            if (int.TryParse(txtOfeNsala.Text, out NumberofOrder) /*&& (chkOfeNsala.Checked = true)*/)
            {

                if (int.Parse(txtOfeNsala.Text) == 0)
                {
                    errorProvider1.SetError(txtOfeNsala, null);
                }

                if (int.Parse(txtOfeNsala.Text) > 0)
                {
                    chkOfeNsala.Checked = true;
                    errorProvider1.SetError(txtOfeNsala, null);
                }
                else
                {
                    chkOfeNsala.Checked = false;
                }
            }
            else
            {
                errorProvider1.SetError(txtOfeNsala, "Enter a number");
                chkOfeNsala.Checked = false;
                lblMealCost.Text = "";
                lblSubTotal.Text = "";
                lblTax.Text = "";
                lblTotal.Text = "";
            }


            // Error Exception for Peppersoup
            if (int.TryParse(txtPeppersoup.Text, out NumberofOrder) /*&& (chkPepperSoup.Checked = true)*/)
            {

                if (int.Parse(txtPeppersoup.Text) == 0)
                {
                    errorProvider1.SetError(txtPeppersoup, null);
                }

                if (int.Parse(txtPeppersoup.Text) > 0)
                {
                    chkPepperSoup.Checked = true;
                    errorProvider1.SetError(txtPeppersoup, null);
                }
                else
                {
                    chkPepperSoup.Checked = false;
                }

            }
            else
            {
                errorProvider1.SetError(txtPeppersoup, "Enter a number");
                chkPepperSoup.Checked = false;
                lblMealCost.Text = "";
                lblSubTotal.Text = "";
                lblTax.Text = "";
                lblTotal.Text = "";
            }
            // Error Exception for Nkwobi
            if (int.TryParse(txtNkwobi.Text, out NumberofOrder) /*&& (chkNkwobi.Checked = true)*/)
            {
                if (int.Parse(txtNkwobi.Text) == 0)
                {
                    errorProvider1.SetError(txtNkwobi, null);
                }
                
                if (int.Parse(txtNkwobi.Text) > 0)
                {
                    chkNkwobi.Checked = true;
                    errorProvider1.SetError(txtNkwobi, null);
                }
                else
                {
                    chkNkwobi.Checked = false;
                }

            }
            else
            {
                errorProvider1.SetError(txtNkwobi, "Enter a number");
                chkNkwobi.Checked = false;
                lblMealCost.Text = "";
                lblSubTotal.Text = "";
                lblTax.Text = "";
                lblTotal.Text = "";

            }
            //====================================================Check if greater than or equal to zero========================================

            if (double.TryParse(lblTotal.Text, out TotalAmount))
            {
                if (double.Parse(lblTotal.Text) >= 0)
                {
                    errorProvider1.Clear();
                }

            }
            else
            {
               
            }


        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void lblDrinkSold_Click(object sender, EventArgs e)
        {

        }

        private void cboDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDrinks.Text == "La casera")
            {
                //lblDrinkSold.Text = "150";
                buyDrink = 150;
            }

            if (cboDrinks.Text == "Sprite")
            {
                //lblDrinkSold.Text = "150";
                buyDrink = 150;
            }

            if (cboDrinks.Text == "Coke")
            {
                //lblDrinkSold.Text = "150";
                buyDrink = 150;
            }

            if (cboDrinks.Text == "RC")
            {
                //lblDrinkSold.Text = "120";
                buyDrink = 120;
            }

            if (cboDrinks.Text == "Pepsi")
            {
                //lblDrinkSold.Text = "150";
                buyDrink = 150;
            }

            if (cboDrinks.Text == "Select Drink")
            {
                //lblDrinkSold.Text = "0";
                buyDrink = 0;
            }

            



           
        }

        
        

        

        private void txtDelivery_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numDrink_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblDeliveryCost_Click(object sender, EventArgs e)
        {

        }

        private void lblMealCost_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tbPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();       
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtfReceipt.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, 120, 120);
        }

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCurrency.Text != "Select Country ......")
            {
                errorProvider2.Clear();
            }
        }
    }
}
