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
    /// Interaction logic for SavingsWindow.xaml
    /// </summary>
    public partial class SavingsWindow : Window
    {
        public SavingsWindow()
        {
            InitializeComponent();
        }

        //private void Next_Click(object sender, RoutedEventArgs e)
        //{
            
        //}

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtSvAmount.Text = "";
            txtSvDate.Text = "";
            txtSReason.Text = "";
            
        }



        private void Saving_MouseDown(object sender, MouseButtonEventArgs e)
        {
             if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtSReason.Text) || String.IsNullOrEmpty(txtSvAmount.Text) || String.IsNullOrEmpty(txtSvDate.Text))
            {
                MessageBox.Show("Please fill in all fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);

                return;

            }
            else if (!Regex.Match(txtSvAmount.Text, @"^[0-9,]*$").Success)
            {
                MessageBox.Show("Please enter a Numerical Digit", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                txtSvAmount.Focus();
                return;

            }
            else
            {
                Expenses.savingReason = txtSReason.Text;
                Expenses.savingAmount = double.Parse(txtSvAmount.Text);
                Expenses.date = DateTime.Parse(txtSvDate.Text);

                Expenses.savings();
                MessageBox.Show("Monthly Savings\nR" + $"{(Expenses.monthlySavings)}", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

                CloseWindow clw = new CloseWindow();
                Close();
                clw.Show();

            }
        }
    }
}
