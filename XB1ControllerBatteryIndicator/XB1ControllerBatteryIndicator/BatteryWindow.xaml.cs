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

namespace XB1ControllerBatteryIndicator
{
    /// <summary>
    /// Interaction logic for BatteryWindow.xaml
    /// </summary>
    public partial class BatteryWindow : Window
    {
        public BatteryWindow()
        {
            InitializeComponent();
        }

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
            if (icon.Contains("medium"))
            {
                newIcon = Properties.Resources.battery_medium;
            }
            if (icon.Contains("low"))
            {
                newIcon = Properties.Resources.battery_low;
            }
            if (icon.Contains("empty"))
            {
                newIcon = Properties.Resources.battery_empty;
            }
            if (icon.Contains("connected"))
            {
                newIcon = Properties.Resources.battery_disconnected;
            }
            if (icon.Contains("wired"))
            {
                newIcon = Properties.Resources.battery_wired;
            }
            if (icon.Contains("unknown"))
            {
                newIcon = Properties.Resources.battery_unknown;
            }
            this.Icon = ConvertToImageSource(newIcon);
        }

        public static ImageSource ConvertToImageSource(Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

    }
}
