using ListImplement.Implements;
using System;
using System.Windows.Forms;
using UiDriver;

namespace WinForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UiContext context = new UiContext(new OrderLogic(), new ProductLogic());

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormOrders(context));
        }
    }
}
