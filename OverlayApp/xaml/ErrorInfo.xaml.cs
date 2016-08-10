using System.Collections.Generic;
using System.Windows.Controls;

namespace OverlayApp
{
    /// <summary>
    /// Interaction logic for ErrorInfo.xaml
    /// </summary>
    public partial class ErrorInfo : UserControl
    {
        /// <summary>
        /// Initializes a empty ErrorInfo
        /// </summary>
        public ErrorInfo()
        {
            InitializeComponent();
            image.Opacity = 0;
            //image.Source = null;
        }
        /// <summary>
        /// Initializes a ErrorInfo with a error message
        /// </summary>
        /// <param name="errorMessage">The message text that will be displayed in the hover tooltip</param>
        public ErrorInfo(string errorMessage)
        {
            InitializeComponent();
            image.Opacity = .5;
            image.ToolTip = errorMessage;
        }
        /// <summary>
        /// Initializes a ErrorInfo with a error message
        /// </summary>
        /// <param name="errorMessages">The message text that will be displayed in the hover tooltip</param>
        public ErrorInfo(List<string> errorMessages)
        {
            InitializeComponent();
            image.Opacity = .5;
            string str = "";
            foreach (string _str in errorMessages)
                str += _str;
            image.ToolTip = str;
        }
    }
}
