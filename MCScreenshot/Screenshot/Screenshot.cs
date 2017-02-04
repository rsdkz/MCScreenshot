using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MCScreenshot.Screenshot
{
    public class Screenshot
    {

        /* Pinvoke 'n Stuff */
        [DllImport("user32.dll")]
        static extern unsafe bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        /* End of Pinvoke 'n Stuff */

        public static Bitmap CreateScreenshot(IntPtr hwnd)
        {
            if (GetForegroundWindow() == hwnd)
            {
                /* get window client rectangle and point */
                RECT rect; Point point = new Point();
                GetClientRect(hwnd, out rect); ClientToScreen(hwnd, ref point);

                int rectWidth = rect.Right - rect.Left; int rectHeight = rect.Bottom - rect.Top;
                /* end of that */

                /* bitmap/graphics stuff */
                Bitmap bmp = new Bitmap(rectWidth, rectHeight);
                Graphics grp = Graphics.FromImage(bmp);
                /* end of that */

                /* quality and stuff */
                grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                grp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                grp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                /* end of that */

                /* copy screen pixel's and draw image and text */
                grp.CopyFromScreen(point.X, point.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                grp.DrawImage(MCScreenshot.Properties.Resources.MCSCREENSHOT, new Rectangle(15, 15, 200, 25));
                /* end of that, and return bitmap */

                return bmp;
            }

            return (Bitmap)null;
        }

    }
}
