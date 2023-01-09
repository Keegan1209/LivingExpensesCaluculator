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
    /// Interaction logic for VDisplayCalcWin.xaml
    /// </summary>
    /// 

    
    public partial class VDisplayCalcWin : Window
    {


        public String vDsp = "Your Updated available monthly income:\nR";
        
        public VDisplayCalcWin()
        {
            InitializeComponent();
            vDsp = vDsp + Expenses.vNewBalance.ToString() + "\nYour vehicle Installments are :\nR";
            vDsp = vDsp + Expenses.vCalcMonthlyRepay.ToString() + "\nYour Housing installments are :\nR";
            vDsp = vDsp + Expenses.monthlyInstallments.ToString(); 
            DspExp2.Text = vDsp;

          }






        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {


            SavingsWindow sw = new SavingsWindow();
            Close();
            sw.Show(); 





        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit the application?", "Notice", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Good Bye!", "Exiting App", MessageBoxButton.OK);
                Close();
            }
            else if (result == MessageBoxResult.No)
            {
                MessageBox.Show("Press OK to resume", "Continue App", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }





        private void VCalc_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void DspExp2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
