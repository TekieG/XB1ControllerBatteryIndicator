using System.Windows;

namespace XB1ControllerBatteryIndicator
{
    /// <summary>
    ///     Interaction logic for SystemTrayView.xaml
    /// </summary>
    public partial class SystemTrayView : Window
    {
        public SystemTrayView()
        {
            InitializeComponent();
        }
        BatteryWindow BattWin = new BatteryWindow();

        private void ShowBatteryWin(object sender, RoutedEventArgs e)
        {            
            BattWin.Show();
        }

        private void CloseBatteryWin(object sender, RoutedEventArgs e)
        {
            BattWin.Close();
        }

        private void AutoStart(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveStartup(object sender, RoutedEventArgs e)
        {

        }


    }
}