using System.Windows;
using System.IO;
using IWshRuntimeLibrary;

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
            BattWin.Hide();
        }

        // ADDS SHORCUT TO STARTUP FOLDER OF USER
        private void AutoStart(object sender, RoutedEventArgs e)
        {
            string appData = System.Environment.GetEnvironmentVariable("AppData");
            var startupFolderPath = appData + @"\Microsoft\Windows\Start Menu\Programs\Startup";

            if (!Directory.Exists(startupFolderPath + @"\XB1ControllerBatteryIndicator.lnk"))
            {
                var shell = new WshShell();
                var shortCutLinkFilePath = startupFolderPath + @"\XB1ControllerBatteryIndicator.lnk";

                var windowsApplicationShortcut = (IWshShortcut)shell.CreateShortcut(shortCutLinkFilePath);
                windowsApplicationShortcut.Description = "How to create short for application example";
                windowsApplicationShortcut.WorkingDirectory = Directory.GetCurrentDirectory();
                windowsApplicationShortcut.TargetPath = Directory.GetCurrentDirectory() + @"\XB1ControllerBatteryIndicator.exe";
                windowsApplicationShortcut.Save();
            }
        }

        // REMOVES SHORTCUT FROM STARTUP FOLDER
        private void RemoveStartup(object sender, RoutedEventArgs e)
        {
            string appData = System.Environment.GetEnvironmentVariable("AppData");
            var startupFolderPath = appData + @"\Microsoft\Windows\Start Menu\Programs\Startup";
            System.IO.File.Delete(startupFolderPath + @"\XB1ControllerBatteryIndicator.lnk");
        }
    }    
}