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
    /// Interaction logic for VehicleWindow.xaml
    /// </summary>
    public partial class VehicleWindow : Window
    {

        public String NEWdsp = "Your current balance:\nafter expenses and monthly home installments\nR";

        public VehicleWindow()
        {
            InitializeComponent();
            NEWdsp = NEWdsp + Expenses.newBalance.ToString() + "\nYour property installments are: \nR";
            NEWdsp = NEWdsp + Expenses.monthlyInstallments.ToString(); 
            DspExp.Text = NEWdsp;
        }

        private void btnVNext_Click(object sender, RoutedEventArgs e)
        {
            CalcVehicleWin cvw = new CalcVehicleWin();
            Close(); 
            cvw.Show(); 
        }

        private void btnVClose_Click(object sender, RoutedEventArgs e)
        {
           MessageBoxResult result = MessageBox.Show("Are you sure you want to exit the application?", "Notice",MessageBoxButton.YesNoCancel,MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Good Bye!", "Exiting App", MessageBoxButton.OK);
                Close(); 
            }
            else if (result== MessageBoxResult.No)
            {
                MessageBox.Show("Press OK to resume", "Continue App", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
        private void VW_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
