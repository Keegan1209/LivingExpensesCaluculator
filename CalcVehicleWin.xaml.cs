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
using System.Text.RegularExpressions;

namespace WPF1_POE
{
    ///
    public partial class CalcVehicleWin : Window
    {
        public CalcVehicleWin()
        {
            InitializeComponent();
        }




        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
             String vModel;

            if (String.IsNullOrEmpty(txtVModel.Text) || String.IsNullOrEmpty(txtVPrice.Text) || String.IsNullOrEmpty(txtVInterest.Text) || String.IsNullOrEmpty(txtVDeposit.Text) || String.IsNullOrEmpty(txtVDeposit.Text) || String.IsNullOrEmpty(txtVInsurance.Text))
            {
                MessageBox.Show("Please fill in all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);

                return;

            }

            else if (!Regex.Match(txtVPrice.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Purchase Price Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtVPrice.Focus();
                return;

            }
            else if (!Regex.Match(txtVDeposit.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Purchase Price Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtVDeposit.Focus();
                return;

            }
            else if (!Regex.Match(txtVInterest.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Purchase Price Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtVInterest.Focus();
                return;

            }
            else if (!Regex.Match(txtVInsurance.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Purchase Price Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtVInsurance.Focus();
                return;

            }

            else
            {
                vModel = txtVModel.Text;
                Expenses.vPurchasePrice = double.Parse(txtVPrice.Text);
                Expenses.vInterest = double.Parse(txtVInterest.Text);
                Expenses.vDeposit = double.Parse(txtVDeposit.Text);
                Expenses.vInsPremium = double.Parse(txtVInsurance.Text);



                Expenses.CalculateVehicleCost();

                //Expenses.vNewBalance = Expenses.newBalance - Expenses.vCalcMonthlyRepay;

                Expenses.exceededIncome = Expenses.vNewBalance * 0.75;

                

                if (Expenses.vNewBalance < Expenses.exceededIncome)
                {
                    MessageBox.Show("You cannot afford this vehicle.\nYour new monthly income R" + $"{(Expenses.vNewBalance)}"+
                        "will exceed 75% of your current income R"
                        + $"{(Expenses.exceededIncome)}" + "\nwith Installments of R" + $"{(Expenses.vCalcMonthlyRepay)}","Sorry...",MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                   
                    Expenses.CalculateVehicleCost();
                    MessageBox.Show("You can afford this vehicle.\nYour new monthly income R" + $"{(Expenses.vNewBalance)}" +
                        "will not exceed 75% of your current income R"
                        + $"{(Expenses.exceededIncome)}" 
                        + "\nwith Installments of R" + $"{(Expenses.vCalcMonthlyRepay)}", "Congratulations!!", MessageBoxButton.OK, MessageBoxImage.Information);
                

                VDisplayCalcWin vdw = new VDisplayCalcWin();
                    Close();
                    vdw.Show(); 
                }
            }

           


        }







        private void CV_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtVDeposit.Text = "";
            txtVInsurance.Text = "";
            txtVInterest.Text = "";
            txtVModel.Text = "";
            txtVPrice.Text = "";
        }
    }
}
