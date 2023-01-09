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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions; 

namespace WPF1_POE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //static Expenses exp;
        
        public MainWindow()
        {
            InitializeComponent();
            




        }

       
        

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(txtgrossIncome.Text) || String.IsNullOrEmpty(txttaxDeducted.Text) || String.IsNullOrEmpty(txtexGroceries.Text) || String.IsNullOrEmpty(txtexWaterLights.Text) || String.IsNullOrEmpty(txtexTravel.Text) || String.IsNullOrEmpty(txtexCell.Text) || String.IsNullOrEmpty(txtexOther.Text)
)
            {
                MessageBox.Show("Please fill in all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
               
                return;

            }
            else if (!Regex.Match(txtgrossIncome.Text,@"^[0-9,]*$").Success)
            {
                MessageBox.Show("Gross Monthly Income Must be Numerical Digit","Warning",MessageBoxButton.OK,MessageBoxImage.Error);
                txtgrossIncome.Focus();
                return;

            }
            else if (!Regex.Match(txttaxDeducted.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Estimated Tax Deducted Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txttaxDeducted.Focus();
                return;
            }
            else if (!Regex.Match(txtexGroceries.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Groceries Expensese Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtexGroceries.Focus();
                return;
            }
            else if (!Regex.Match(txtexWaterLights.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Water & Lights Expensese Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtexWaterLights.Focus();
                return;
            }
            else if (!Regex.Match(txtexTravel.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Travel Expensese Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtexTravel.Focus();
                return;
            }
            else if (!Regex.Match(txtexCell.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Cellphone Expensese Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtexCell.Focus();
                return;
            }
            else if (!Regex.Match(txtexOther.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Other Expenseses Must be Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtgrossIncome.Focus();
                return;
            }
            else
            {

               

                Expenses.grossIncome = double.Parse(txtgrossIncome.Text);
                Expenses.taxDeducted = double.Parse(txttaxDeducted.Text);
                Expenses.exGroceries = double.Parse(txtexGroceries.Text);
                Expenses.exWaterLights = double.Parse(txtexWaterLights.Text);
                Expenses.exTravel = double.Parse(txtexTravel.Text);
                Expenses.exCell = double.Parse(txtexCell.Text);
                Expenses.exOther = double.Parse(txtexOther.Text);


                Expenses.availableBalance = Expenses.grossIncome
                 - Expenses.taxDeducted - Expenses.exGroceries - Expenses.exWaterLights - Expenses.exTravel - Expenses.exCell - Expenses.exOther;

                RentOrBuyWindow rb = new RentOrBuyWindow();
                //rb.LstBoxEx.Items.Add(exp);
                Close();
                rb.Show();

                
                


            }


        }



        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtgrossIncome.Text = "";
            txttaxDeducted.Text = "";
            txtexGroceries.Text = "";
            txtexWaterLights.Text = "";
            txtexTravel.Text = "";
            txtexCell.Text= "";
            txtexOther.Text = "";

        }


        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        
    }
}
