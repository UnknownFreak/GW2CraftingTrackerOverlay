using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverlayApp
{
    public partial class LogWindow: Form
    {
        public LogWindow()
        {
            InitializeComponent();
        }

        private void LogWindow_Load(object sender, EventArgs e)
        {
            Logger.Logger.linkDataSource(logView);
            Logger.Logger.Log("Logger Initialized", Logger.Logger.MessageType.Info);
        }
    }
}
