using System;
using System.Windows.Forms;

namespace ChuKyDienTu
{
    internal static class Program
    {
        public static string bienD = "";
        public static string bienE = "";
        public static string bienN = "";
        public static string bienp = "";
        public static string bienq = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}