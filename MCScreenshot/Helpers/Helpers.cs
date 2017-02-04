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
        private static extern unsafe bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        private static extern unsafe IntPtr GetForegroundWindow();

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
            RECT rect; Rectangle rectangle = new Rectangle(); Point point = new Point();
            GetClientRect(hWnd, out rect); ClientToScreen(hWnd, ref point);

            int rectWidth = rect.Right - rect.Left; int rectHeight = rect.Bottom - rect.Top;

            rectangle.X = point.X; rectangle.Y = point.Y;
            rectangle.Width = rectWidth; rectangle.Height = rectHeight;

            return rectangle;
        }

        public static IntPtr _GetForegroundWindow()
        {
            return GetForegroundWindow();
        }
    }
}
