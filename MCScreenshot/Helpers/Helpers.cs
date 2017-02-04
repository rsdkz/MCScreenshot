using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace MCScreenshot.Helpers
{
    /* currently unused */
    public class Helpers
    {

        /* Begin of Pinvoke and Stuff */
        [DllImport("user32.dll", SetLastError = true)]
        private static extern unsafe IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern unsafe bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        /* End of Pinvoke and Stuff */

        public static IntPtr FindWindowByTitle(string windowTitle)
        {
            IntPtr hWnd = FindWindow((string)null, windowTitle);

            if (hWnd != IntPtr.Zero)
            {
                return hWnd;
            }
            else { return new IntPtr(-1); }
        }

        public static Rectangle GetClientRectangle(IntPtr hWnd)
        {
            // wip
            return new Rectangle();
        }
    }
}
