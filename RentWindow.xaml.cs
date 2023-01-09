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
    /// Interaction logic for RentWindow.xaml
    /// </summary>
    public partial class RentWindow : Window
    {
        public RentWindow()
        {
            InitializeComponent();
        }

        private void btnRNext_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtRentAm.Text))
            {
                MessageBox.Show("Please fill in the fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            else if (!Regex.Match(txtRentAm.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Entry Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtRentAm.Focus();
                return;

            }
            else
            {
                Expenses.monthlyInstallments = double.Parse(txtRentAm.Text);


                if (Expenses.monthlyInstallments > Expenses.availableBalance)
                {
                    MessageBox.Show("Your rent cannot be higher than your available balance\nR" + $"{(Expenses.availableBalance)}", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }
                else
                {

                    Expenses.CalcRent();
                    Expenses.availableBalance = Expenses.availableBalance - Expenses.monthlyInstallments;
                    MessageBox.Show("Congratulations! You qualify to Rent this Accomodation", "Success!", MessageBoxButton.OK);

                    VehicleWindow vw = new VehicleWindow();
                    Close();
                    vw.Show();
                }
            }
            



        }




        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtRentAm.Text = "";
        }
    }
}
