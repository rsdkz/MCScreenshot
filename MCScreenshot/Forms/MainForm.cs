using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MCScreenshot.Helpers;

namespace MCScreenshot.Forms
{
    public partial class MainForm : Form
    {
        private Helpers.LLKeyboardHook llk = new Helpers.LLKeyboardHook(); // low-level keyboard hook for registering keys outside app

        public MainForm()
        {
            InitializeComponent();

            llk.OnKeyPressed += llk_OnKeyPressed;
        }

        private void llk_OnKeyPressed(object sender, Helpers.LLKeyboardHook.KeyPressedArgs e)
        {
            if (e.KeyPressed == System.Windows.Input.Key.F12)
            {

                /* currently supports Minecraft 1.11.2 only, I'll be implementing more methods to find Minecraft */
                if (Helpers.Helpers.FindWindowByTitle("Minecraft 1.11.2") != new IntPtr(-1))
                {
                    if (Screenshot.Screenshot.CreateScreenshot(Helpers.Helpers.FindWindowByTitle("Minecraft 1.11.2")) != null)
                        Screenshot.Screenshot.CreateScreenshot(Helpers.Helpers.FindWindowByTitle("Minecraft 1.11.2")).Save(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\\MCScreenshot\\MCScreenshot_" + DateTime.Now.ToFileTime() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\\MCScreenshot\\"))
            {
                System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\\MCScreenshot\\");
            }
        }
    }
}
