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

        // CREATES SHORTCUT '.lnk' IN THE STARTUP FOLDER OF THE USER
        private void ShowAtStartup(object sender, RoutedEventArgs e)
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
        private void DeleteStartup(object sender, RoutedEventArgs e)
        {
            string appData = System.Environment.GetEnvironmentVariable("AppData");
            var startupFolderPath = appData + @"\Microsoft\Windows\Start Menu\Programs\Startup";
            System.IO.File.Delete(startupFolderPath + @"\XB1ControllerBatteryIndicator.lnk");
        }

        private void OpenBatteryWin(object sender, RoutedEventArgs e)
        {

        }

        private void CloseBatteryWin(object sender, RoutedEventArgs e)
        {

        }
    }
}