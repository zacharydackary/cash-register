using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace cash_register
{
    public partial class Form1 : Form
    {
        //global constants
        const double BURGER_COST = 2.49;
        const double FRIES_COST = 1.89;
        const double DRINK_COST = 0.99;
        const double TAX = (0.13); 

        //global variables
        int burgerPurchase = 0;
        int friesPurchase = 0;
        int drinksPurchase = 0;
        double totalOrder = 0;
        double taxAmt = 0;
        string tendered;
        double totalTax = 0;
        double change = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void foodButton_Click(object sender, EventArgs e)
        {
            try
            {
                burgerPurchase = Convert.ToInt16(textBox1.Text);
                friesPurchase = Convert.ToInt16(textBox2.Text);
                drinksPurchase = Convert.ToInt16(textBox3.Text);
                //#of items * the amount they cost
                totalOrder = burgerPurchase * BURGER_COST
                    + friesPurchase * FRIES_COST
                    + drinksPurchase * DRINK_COST;
                totalTax = totalOrder * TAX;
                taxAmt = totalOrder + totalTax;

                label9.Text = "" + totalOrder.ToString("c");
                label10.Text = "" + totalTax.ToString("c");
                label11.Text = "" + taxAmt.ToString("c");
            }
            catch
            {
                //in the event someone tries to calculate without any numbers
                label9.Text = "error";
                label10.Text = "error";
                label11.Text = "error";
            }
        }
            private void tenderedButton_Click(object sender, EventArgs e)
            {
                tendered = textBox4.Text;
                change = (Convert.ToDouble(tendered) - taxAmt);

                label12.Text = "" + change.ToString("C");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Graphics formGraphics = this.CreateGraphics();
            Font drawFont = new Font("Arial", 12, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            //audio
            SoundPlayer player = new SoundPlayer(Properties.Resources.tpse);
            SoundPlayer playertwo = new SoundPlayer(Properties.Resources.register);
            //print receipt in order
            player.Play();
            Thread.Sleep(10);
            formGraphics.FillRectangle(drawBrush, 500, 500, 500, 500);
            formGraphics.DrawString("Mick Dons", drawFont, drawBrush, 255, 90);
            Thread.Sleep(500);
            formGraphics.DrawString("Order#723", drawFont, drawBrush, 210, 140);
            Thread.Sleep(50);
            formGraphics.DrawString("10.18.17", drawFont, drawBrush, 210, 160);
            Thread.Sleep(50);
            formGraphics.DrawString("Hamburgers   x" + burgerPurchase + "  @  " + burgerPurchase * BURGER_COST, drawFont, drawBrush, 210, 200);
            Thread.Sleep(50);
            formGraphics.DrawString("Fries                x" + friesPurchase + "  @  " + friesPurchase * FRIES_COST, drawFont, drawBrush, 210, 220);
            Thread.Sleep(50);
            formGraphics.DrawString("Drinks             x" + drinksPurchase + "  @  " + drinksPurchase * DRINK_COST, drawFont, drawBrush, 210, 240);
            Thread.Sleep(200);
            formGraphics.DrawString("Subtotal            " + totalOrder, drawFont, drawBrush, 210, 280);
            Thread.Sleep(50);
            formGraphics.DrawString("Tax                    " + totalTax.ToString("C"), drawFont, drawBrush, 210, 300);
            Thread.Sleep(50);
            formGraphics.DrawString("Total                 " + taxAmt.ToString("C"), drawFont, drawBrush, 210, 320);
            Thread.Sleep(200);
            formGraphics.DrawString("Tendered          " + tendered, drawFont, drawBrush, 210, 360);
            Thread.Sleep(50);
            formGraphics.DrawString("Change            " + change.ToString("C"), drawFont, drawBrush, 210, 380);
            player.Stop(); 
            playertwo.Play();
        }
    }
}