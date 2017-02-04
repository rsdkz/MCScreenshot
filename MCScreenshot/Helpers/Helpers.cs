using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MCScreenshot.Helpers
{
    /* currently unused */
    public class Helpers
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern unsafe IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static IntPtr FindWindowByTitle(string windowTitle)
        {
            IntPtr hWnd = FindWindow((string)null, windowTitle);

            if (hWnd != IntPtr.Zero)
            {
                return hWnd;
            }
            else { return new IntPtr(-1); }
        }
    }
}
