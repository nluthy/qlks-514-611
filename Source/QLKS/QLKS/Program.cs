using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QLKS.DTO;

namespace QLKS
{
    static class Program
    {
        private static String nguoiDung;

        public static String NguoiDung
        {
            get { return Program.nguoiDung; }
            set { Program.nguoiDung = value; }
        }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DangNhapForm form = new DangNhapForm();
            
            if (form.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
        }
    }
}
