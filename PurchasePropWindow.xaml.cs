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
    /// <summary>
    /// Interaction logic for PurchasePropWindow.xaml
    /// </summary>
    public partial class PurchasePropWindow : Window
    {
        public PurchasePropWindow()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int Mmin = 240;
            int Mmax = 360;
            int Imax = 100;


            

            if (String.IsNullOrEmpty(txtPurchaseP.Text) || String.IsNullOrEmpty(txtTotalDep.Text) || String.IsNullOrEmpty(txtInterest.Text) || String.IsNullOrEmpty(txtRepMon.Text))
            {
                MessageBox.Show("Please fill in all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);

                return;

            }
            else if (!Regex.Match(txtPurchaseP.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Purchase Price Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPurchaseP.Focus();
                return;

            }
            else if (!Regex.Match(txtTotalDep.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Total Deposit Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtTotalDep.Focus();
                return;

            }
            else if (!Regex.Match(txtInterest.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Interest Must be Numerical Digit eg. 1.9 , 0.4, 25 ", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtInterest.Focus();
                return;

            }
            else if (double.Parse(txtInterest.Text) > Imax)
            {
                MessageBox.Show("Interest rate percentage cannot be larger than 100", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtInterest.Focus();
                return;
            }
            else if (!Regex.Match(txtRepMon.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Interest Must be Numerical Digit eg. 1.9 , 0.4, 25 ", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtRepMon.Focus();
                return;

            }
            else if (double.Parse(txtRepMon.Text) < Mmin)
            {
                MessageBox.Show("number of months are greater than 240", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtRepMon.Focus();
                return;
            }
            else if (double.Parse(txtRepMon.Text) > Mmax)
            {
                MessageBox.Show("number of months are less than 360", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtRepMon.Focus();
                return;
            }

            else
            {
                Expenses.purchasePrice = double.Parse(txtPurchaseP.Text);
                Expenses.totalDeposit = double.Parse(txtTotalDep.Text);
                Expenses.interestRate = double.Parse(txtInterest.Text);
                Expenses.repayMonths = double.Parse(txtRepMon.Text);


                 Expenses.thirdIncome = Expenses.availableBalance / 3;

                if (Expenses.monthlyInstallments > Expenses.thirdIncome)
                {
                    MessageBox.Show("Sorry... You do not qualify for a homeloan \nYour Monthly installments of R" + $"{ (Expenses.monthlyInstallments)}" + 
                        "\nExceeds a third (1/3) of your available balance - R" + $"{ (Expenses.thirdIncome)}"
                    , "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                    return; 
                }
                else
                {
                   
                    Expenses.CalcHomeLoan();

                    MessageBox.Show("Congratulations! You qualify for the homeloan", "Success!", MessageBoxButton.OK);

                    VehicleWindow vw = new VehicleWindow();
                    Close();
                    vw.Show();
                    return;
                }

            }

            


        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtPurchaseP.Text = "";
            txtRepMon.Text = "";
            txtTotalDep.Text = "";
            txtInterest.Text = "";
            
        }


        private void PP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
