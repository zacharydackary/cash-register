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
        int totalOrder = 0;
        int taxAmt = 0;
        int tendered = 0;
        int totalwTax = 0;
        int change = 0;

        public Form1()
        {
        InitializeComponent();
        }

        private void foodButton_Click(object sender, EventArgs e)
        {
            burgerPurchase = Convert.ToInt16(textBox1.Text);
            friesPurchase = Convert.ToInt16(textBox2.Text);
            drinksPurchase = Convert.ToInt16(textBox3.Text);

            totalOrder = burgerPurchase + friesPurchase + drinksPurchase;
            totalwTax = Convert.ToInt16(totalOrder * TAX);
            taxAmt = totalwTax - totalOrder;

            label9.Text = ""+totalOrder;
            label10.Text = ""+taxAmt;
            label11.Text = ""+totalwTax;






        }
        private void tenderedButton_Click(object sender, EventArgs e)
        {

        }
    }
}
