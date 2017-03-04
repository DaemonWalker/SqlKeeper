using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlKeeper
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var frmLock = false;
            var mutex = new Mutex(true, "SqlKeeper", out frmLock);
            if (frmLock)
            {
                foreach (var font in new InstalledFontCollection().Families)
                {
                    if (font.Name == "Inziu Iosevka SC")
                    {
                        GlobalFont = new Font("Inziu Iosevka SC", 12, FontStyle.Regular);
                    }
                }
                if (GlobalFont == null)
                {
                    GlobalFont = new Font("仿宋", 12, FontStyle.Regular);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());
            }
        }
        public static Font GlobalFont;
    }
}
