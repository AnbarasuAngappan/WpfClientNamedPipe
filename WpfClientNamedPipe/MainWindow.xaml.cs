using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfClientNamedPipe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAgeCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if((txtday != null && txtMonth !=null && txtYear !=null) && (txtday.Text.Length > 0 && txtMonth.Text.Length >0 && txtYear.Text.Length > 0))
                {
                    int day, Month, Year, TotalDays;
                    WCFNamedPipe.WCFNamedPipeClient wCFNamedPipeClient = new WCFNamedPipe.WCFNamedPipeClient("NetNamedPipeBinding_IWCFNamedPipe");

                    day = int.Parse(txtday.Text);
                    Month = int.Parse(txtMonth.Text);
                    Year = int.Parse(txtYear.Text);

                    TotalDays = wCFNamedPipeClient.calculateDays(day, Month, Year);

                    MessageBox.Show(Environment.UserName + "You are Currently " + Convert.ToString(TotalDays) + " days old", "Response From the Server", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Fields Should Not be Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        private void txtMonth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[1-12]|1[012]");
            //e.Handled = regex.IsMatch(e.Text);
            //if (e.Handled == true)
            //{
            //    txtMonth.Text = e.Text;
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Range");
            //    txtMonth.Focus();
            //}
        }
    }
}
