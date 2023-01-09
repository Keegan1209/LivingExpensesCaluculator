using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF1_POE
{
    /// <summary>
    /// Interaction logic for RentOrBuyWindow.xaml
    /// </summary>
    /// 

    public partial class RentOrBuyWindow : Window
    {


        public String dsp = "Your Gross Monthly Income is: R";

        public RentOrBuyWindow()
        {
            InitializeComponent();
            dsp = dsp + Expenses.grossIncome.ToString() + "\nYour tax deducted is: R";
            dsp = dsp + Expenses.taxDeducted.ToString() + "\nYour groceries expenses are: R";
            dsp = dsp + Expenses.exGroceries.ToString() + "\nYour Water & Lights expenses are: R";
            dsp = dsp + Expenses.exWaterLights.ToString() + "\nYour Travel expenses are: R";
            dsp = dsp + Expenses.exTravel.ToString() + "\nYour Cell Phone expenses are: R";
            dsp = dsp + Expenses.exCell.ToString() + "\nYour Other expenses are: R";
            dsp = dsp + Expenses.exOther.ToString() +"\nYour Available Balance is: R";
            dsp = dsp + Expenses.availableBalance.ToString(); 
           
            DspExp.Text = dsp;
        }

       

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            PurchasePropWindow pw = new PurchasePropWindow();
                Close();
                pw.Show(); 
            
        }

        private void btnRent_Click(object sender, RoutedEventArgs e)
        {
            RentWindow rw = new RentWindow();
            Close(); 
            rw.Show(); 
            
        }

          private void RentBuy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

    }
}
