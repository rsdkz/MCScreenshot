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

        public static Bitmap CreateScreenshot(IntPtr hwnd, UpscaleMode mode)
        {
            if (Helpers.Helpers._GetForegroundWindow() == hwnd)
            {
                /* get window client rectangle and point */
                Rectangle rectangle = Helpers.Helpers.GetClientRectangle(hwnd);
                /* end of that */

                /* bitmap/graphics and upscale mode stuff */
                Bitmap bmp = new Bitmap(rectangle.Width, rectangle.Height); // original bitmap
                Bitmap usbmp = null; // upscaled bitmap

                switch (mode)
                {
                    case UpscaleMode.LowHD: // 720p HD
                        usbmp = new Bitmap(1280, 720);
                        break;
                    case UpscaleMode.MidHD: // 1080p HD
                        usbmp = new Bitmap(1920, 1080);
                        break;
                    case UpscaleMode.HighHD: // 1440p HD
                        usbmp = new Bitmap(2560, 1440);
                        break;
                }

                Graphics grp = Graphics.FromImage(bmp); // graphics for original bitmap
                Graphics usgrp = Graphics.FromImage(usbmp); // graphics for upscaled bitmap
                /* end of that */

                /* quality and stuff */
                grp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                grp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                grp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                /* quality for upscaled image, and stuff */

                usgrp.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                usgrp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                usgrp.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                usgrp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                usgrp.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                /* end of that */

                /* copy screen pixel's and draw image and text */
                grp.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                grp.DrawImage(MCScreenshot.Properties.Resources.MCSCREENSHOT, new Rectangle(15, 15, 200, 25));
                /* end of that, and upscale to set resolution */

                usgrp.DrawImage(bmp, new Rectangle(0, 0, usbmp.Width, usbmp.Height)); // draw image in upscaled format on the for the upscaled image bitmap

                return usbmp;
            }

            return (Bitmap)null;
        }

        public enum UpscaleMode
        {
            LowHD,
            MidHD,
            HighHD
        }
    }
}
