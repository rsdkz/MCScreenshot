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
        public static Bitmap CreateScreenshot(IntPtr hwnd)
        {
            if (Helpers.Helpers._GetForegroundWindow() == hwnd)
            {
                /* get window client rectangle and point */
                Rectangle rectangle = Helpers.Helpers.GetClientRectangle(hwnd);
                /* end of that */

                /* bitmap/graphics stuff */
                Bitmap bmp = new Bitmap(rectangle.Width, rectangle.Height);
                Graphics grp = Graphics.FromImage(bmp);
                /* end of that */

                /* quality and stuff */
                grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                grp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                grp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                /* end of that */

                /* copy screen pixel's and draw image and text */
                grp.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                grp.DrawImage(MCScreenshot.Properties.Resources.MCSCREENSHOT, new Rectangle(15, 15, 200, 25));
                /* end of that, and return bitmap */

                return bmp;
            }

            return (Bitmap)null;
        }

    }
}
