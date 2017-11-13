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
using System.Windows.Interop;
using System.Drawing;
using System.Threading;
using System.Windows.Threading;

namespace XB1ControllerBatteryIndicator
{
    /// <summary>
    /// Interaction logic for BatteryWindow.xaml
    /// </summary>
    public partial class BatteryWindow : Window
    {
        //private Button uiObject;

        public BatteryWindow()
        {
            InitializeComponent();
        }

        // MAKES WINDOW DRAGGLE
        private void DragWindows(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        


        public void UpdateImage(string icon)
        {
            Icon newIcon = null;

            if (icon.Contains("full"))
            {
                newIcon = Properties.Resources.battery_full;
            }
            else if (icon.Contains("medium"))
            {
                newIcon = Properties.Resources.battery_medium;
            }
            else if (icon.Contains("low"))
            {
                newIcon = Properties.Resources.battery_low;
            }
            else if (icon.Contains("empty"))
            {
                newIcon = Properties.Resources.battery_empty;
            }
            else if (icon.Contains("disconnected"))
            {
                newIcon = Properties.Resources.battery_disconnected;
            }
            else if (icon.Contains("wired"))
            {
                newIcon = Properties.Resources.battery_wired;
            }
            else if (icon.Contains("unknown"))
            {
                newIcon = Properties.Resources.battery_unknown;
            }
            ImageSource WBI = ConvertToImageSource(newIcon);

            // UPDATES IMAGE ACCORDING TO 'SystemTrayViewModel.cs'
            BatteryImage.Dispatcher.Invoke(() =>
            {
                BatteryImage.Source = WBI;
            });
        }

        public static ImageSource ConvertToImageSource(Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

    }
}
