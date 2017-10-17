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
        private object formGraphics;
        private readonly Brush arial;

        public Form1()
        {
        InitializeComponent();
        }

        private void foodButton_Click(object sender, EventArgs e)
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
            
            label9.Text = ""+totalOrder;
            label10.Text = ""+totalTax;
            label11.Text = ""+taxAmt;
            
        }
        private void tenderedButton_Click(object sender, EventArgs e)
        {
            tendered = textBox4.Text;
            change = (Convert.ToDouble(tendered) - taxAmt);

            label12.Text = "" + change;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics formGraphics = this.CreateGraphics();

            formGraphics.DrawString("Mick Dons", Font, 10, 10);
        }
    }
}
