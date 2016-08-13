using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace OverlayApp
{
    /// <summary>
    /// Interaction logic for OverlayWindow.xaml
    /// </summary>
    public partial class OverlayWindow : Window
    {
        OverlayManager mgr = null;
        Timer updateThread;
        public OverlayWindow()
        {
            InitializeComponent();
            updateThread = new Timer(new TimerCallback(update),null,new TimeSpan(0),Properties.Settings.Default.UpdateTime);
            OverlayInfo.onError += OverlayInfo_onError;
            Closing += OverlayInfo.UserControl_Unloaded;
        }
        /// <summary>
        /// Sets an error message onto the overlay. Overrides the previous error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The error information message, null to clear the message.</param>
        void OverlayInfo_onError(object sender, ErrorInfo e)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (e != null)
                {
                    ErrorInfo.image.Opacity = e.image.Opacity;
                    ErrorInfo.image.ToolTip = e.image.ToolTip;
                }
                else
                {
                    ErrorInfo.image.Opacity = 0;
                    ErrorInfo.image.ToolTip = "";
                }
            }));
        }
        private void Overlay_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed && e.ChangedButton == MouseButton.Left && Properties.Settings.Default.MoveMode)
                DragMove();
        }
        /// <summary>
        /// Used to change the timer update time for the updateThread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void onTimerUpdateChange(object sender, EventArgs e)
        {
            updateThread.Change(new TimeSpan(0), Properties.Settings.Default.UpdateTime);
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            updateThread.Dispose();
            if(mgr != null)
            {
                mgr.Close();
                mgr.Dispose();
            }
            Properties.Settings.Default.OverlayPosition = new System.Drawing.Point(System.Convert.ToInt32(Left), System.Convert.ToInt32(Top));
            Properties.Settings.Default.OverlaySize = new System.Drawing.Size(System.Convert.ToInt32(Width), System.Convert.ToInt32(Height));
            Properties.Settings.Default.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reload();
            // settings
            Left = Properties.Settings.Default.OverlayPosition.X;
            Top = Properties.Settings.Default.OverlayPosition.Y;
            Height = Properties.Settings.Default.OverlaySize.Height;
            Width = Properties.Settings.Default.OverlaySize.Width;

            MenuExpander.IsExpanded = Properties.Settings.Default.MenuExpanderSetting;

            MoveMode.IsChecked = Properties.Settings.Default.MoveMode;
            ResizeMode_.IsChecked = Properties.Settings.Default.ResizeMode;

            Opacity = (Properties.Settings.Default.Opacity / 100.0);
            TitleRect.Visibility = Properties.Settings.Default.MoveMode ? Visibility.Visible : Visibility.Hidden;
            ResizeMode = Properties.Settings.Default.ResizeMode ? ResizeMode.CanResizeWithGrip : ResizeMode.NoResize;
        }

        private void update(object obj)
        {
            OverlayWindow w = obj as OverlayWindow;
            {
                OverlayInfo.updateAccountInformation();
                OverlayInfo.updateItemCount();
                OverlayInfo.updateItemProjects();
            }
        }

        internal void onApiKeyCange(object sender, string e)
        {
            OverlayInfo.setAPIKey(e);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.MoveMode = MoveMode.IsChecked.Value;
            TitleRect.Visibility = MoveMode.IsChecked.Value ? Visibility.Visible : Visibility.Hidden;
        }

        private void ResizeMode__Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ResizeMode = ResizeMode_.IsChecked.Value;
            ResizeMode = ResizeMode_.IsChecked.Value ? ResizeMode.CanResizeWithGrip : ResizeMode.NoResize;
        }

        private void Options_Clicked(object sender, RoutedEventArgs e)
        {
            Settings options = new Settings();
            options.onOpacityChange+= onOpaticyChange;
            options.onAPIKeyChange += onApiKeyCange;
            options.onUpdateFrequencyChange += onTimerUpdateChange;
            options.Show();
        }
        private void onOpaticyChange(object sender, int e)
        {
            Opacity = e / 100.0;
        }

        private void ManageItems(object sender, RoutedEventArgs e)
        {
            if (mgr == null)
                mgr = new OverlayManager(this);
            mgr.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
