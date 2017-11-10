using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SharpDX.XInput;
using System.Windows.Forms;

namespace XB1ControllerBatteryIndicator
{
    public class SystemTrayViewModel : Caliburn.Micro.Screen
    {
        private string _activeIcon;
        private Controller _controller;
        private string _tooltipText;
        private bool balloon_shown = false;
        NotifyIcon balloon = new NotifyIcon();
        WindowBattery batteryWin = new WindowBattery();
        

        public SystemTrayViewModel()
        {
            ActiveIcon = "Resources/battery_unknown.ico";
            GetController();
            Thread th = new Thread(RefreshControllerState);
            th.IsBackground = true;
            th.Start();
            
        }

        public string ActiveIcon
        {
            get { return _activeIcon; }
            set
            {
                _activeIcon = value;
                NotifyOfPropertyChange();
            }
        }

        public string TooltipText
        {
            get { return _tooltipText; }
            set
            {
                _tooltipText = value;
                NotifyOfPropertyChange();
            }
        }

        private void GetController()
        {
            var controllers = new[]
            {
                new Controller(UserIndex.One), new Controller(UserIndex.Two), new Controller(UserIndex.Three),
                new Controller(UserIndex.Four)
            };
            _controller = controllers.FirstOrDefault(selectControler => selectControler.IsConnected);
        }

        private void RefreshControllerState()
        {
            while (true)
            {
                GetController();
                if (_controller != null)
                {
                    var batteryInfo = _controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
                    if (batteryInfo.BatteryType == BatteryType.Disconnected ||
                        batteryInfo.BatteryType == BatteryType.Wired ||
                        batteryInfo.BatteryType == BatteryType.Unknown)
                    {
                        TooltipText = $"Controller {_controller.UserIndex} - {batteryInfo.BatteryType}";
                        ActiveIcon = $"Resources/battery_{batteryInfo.BatteryType.ToString().ToLower()}.ico";
                        //batteryWin.UpdateImage($"battery_{ batteryInfo.BatteryType.ToString().ToLower()}");
                    }
                    else
                    {
                        TooltipText = $"Controller {_controller.UserIndex} - Battery level: {batteryInfo.BatteryLevel}";
                        ActiveIcon = $"Resources/battery_{batteryInfo.BatteryLevel.ToString().ToLower()}.ico";
                        if (batteryInfo.BatteryLevel == BatteryLevel.Empty)
                        {
                            if (balloon_shown == false)
                            {
                                balloon_shown = true;
                                balloon.Icon = System.Drawing.SystemIcons.Information;
                                balloon.Visible = true;
                                balloon.Text = $"Battery of controller {_controller.UserIndex} is (almost) empty.";
                                balloon.ShowBalloonTip(10000, $"Controller {_controller.UserIndex} battery low", $"Battery of controller {_controller.UserIndex} is (almost) empty.", ToolTipIcon.Info);
                            }
                        }

                        else
                        {
                            balloon_shown = false;
                            balloon.Visible = false;

                        }
                    }
                }
                else
                {
                    TooltipText = $"No controller detected";
                    ActiveIcon = $"Resources/battery_unknown.ico";
                }
                Thread.Sleep(1000);
            }
        }

        public void ExitApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}