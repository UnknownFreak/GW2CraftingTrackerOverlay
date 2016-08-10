using System;
using System.Windows;

namespace OverlayApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //public static Properties.Settings settings;

        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            Application app = new Application();
            //Application.Run(new OverlayWindow());
            app.Run(new OverlayWindow());
        }
    }
}
