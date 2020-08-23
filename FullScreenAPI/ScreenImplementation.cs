using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_TeamPointMainScreenInteractor;
using System.Windows.Forms;
using Utils;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace FullScreenAPI
{

    public class ScreenImplementation : ScreenBoundary
    {
        public string GetFullScreenInstruction(int screenId)
        {
            Screen screen;
            string instruction;

            if (Screen.AllScreens.Length <= screenId)
            {
                //throw new Exception("Unhandle");
                screen = Screen.PrimaryScreen;

                instruction = "{";
                instruction += "\"";
                instruction += "Top";
                instruction += "\"";
                instruction += ":";
                instruction += screen.Bounds.Y;
                instruction += ",";

                instruction += "\"";
                instruction += "Left";
                instruction += "\"";
                instruction += ":";
                instruction += screen.Bounds.X;
                instruction += ",";

                instruction += "\"";
                instruction += "IsMaximized";
                instruction += "\"";
                instruction += ":";
                instruction += "true";
                instruction += ",";

                instruction += "\"";
                instruction += "IsShown";
                instruction += "\"";
                instruction += ":";
                instruction += "true";
                instruction += "";

                instruction += "}";

                return instruction;
            }

            screen = Screen.AllScreens[screenId];

            instruction = "{";
            instruction += "\"";
            instruction += "Top";
            instruction += "\"";
            instruction += ":";
            instruction += screen.Bounds.Y;
            instruction += ",";

            instruction += "\"";
            instruction += "Left";
            instruction += "\"";
            instruction += ":";
            instruction += screen.Bounds.X;
            instruction += ",";

            instruction += "\"";
            instruction += "IsMaximized";
            instruction += "\"";
            instruction += ":";
            instruction += "true";
            instruction += ",";

            instruction += "\"";
            instruction += "IsShown";
            instruction += "\"";
            instruction += ":";
            instruction += "true";
            instruction += "";

            instruction += "}";

            return instruction;
        }



        public string GetScreenInfo()
        {
            return GetScreensInfo();
            //throw new NotImplementedException();
        }

        private string GetScreensInfo()
        {
            string screensInfo = "[";
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                Screen screen = Screen.AllScreens[i];

                string device = screen.DeviceName;

                string theSreenInfo = "";
                theSreenInfo += "{";
                theSreenInfo += "\"";
                theSreenInfo += "Id";
                theSreenInfo += "\"";
                theSreenInfo += ":";
                theSreenInfo += i;
                theSreenInfo += ",";

                theSreenInfo += "\"";
                theSreenInfo += "ScreenShot";
                theSreenInfo += "\"";
                theSreenInfo += ":";
                theSreenInfo += "\"";
                theSreenInfo += Utils.Converter.FromBytesToBase64(
                    Converter.FromBitmapToBytes(
                        getScreenScreenShotToBitmap(screen)));
                theSreenInfo += "\"";

                theSreenInfo += "}";

                if (i != Screen.AllScreens.Length - 1)
                {
                    theSreenInfo += ",";
                }

                screensInfo += theSreenInfo;

            }

            screensInfo += "]";
            return screensInfo;
        }

        private Bitmap getScreenScreenShotToBitmap(Screen screen)
        {
            float scale = 0;

            DEVMODE dm = new DEVMODE();
            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            EnumDisplaySettings(screen.DeviceName, ENUM_CURRENT_SETTINGS, ref dm);


            int scaledWidth = Screen.PrimaryScreen.Bounds.Width;
            int scaledHeight = Screen.PrimaryScreen.Bounds.Height;

            Bitmap screenShot = new Bitmap(dm.dmPelsWidth,
                dm.dmPelsHeight,
                PixelFormat.Format32bppArgb);

            System.Drawing.Size size = new System.Drawing.Size(dm.dmPelsWidth, dm.dmPelsHeight);

            int xPreScale = (int)(screen.Bounds.X * 1.0 * dm.dmPelsWidth / scaledWidth);
            int yPreScale = (int)(screen.Bounds.Y * 1.0 * dm.dmPelsHeight / scaledHeight);

            Graphics memGraphics = Graphics.FromImage(screenShot);
            memGraphics.CopyFromScreen(xPreScale,
                yPreScale,
                0,
                0,
                size,
                CopyPixelOperation.SourceCopy);
            //
            return screenShot;

        }

        const int ENUM_CURRENT_SETTINGS = -1;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpszDeviceName"></param>
        /// <param name="iModeNum"></param>
        /// <param name="lpDevMode"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

        public string GetNormalScreenInstruction()
        {
            Screen screen = Screen.PrimaryScreen;

            string instruction = "{";
            instruction += "\"";
            instruction += "Top";
            instruction += "\"";
            instruction += ":";
            instruction += screen.Bounds.Y;
            instruction += ",";

            instruction += "\"";
            instruction += "Left";
            instruction += "\"";
            instruction += ":";
            instruction += screen.Bounds.X;
            instruction += ",";

            instruction += "\"";
            instruction += "IsMaximized";
            instruction += "\"";
            instruction += ":";
            instruction += "false";
            instruction += ",";

            instruction += "\"";
            instruction += "IsShown";
            instruction += "\"";
            instruction += ":";
            instruction += "true";
            instruction += "";

            instruction += "}";

            return instruction;
        }

        public string GetScreenPreview()
        {
            string theSreenInfo = "";
            theSreenInfo += "{";
            theSreenInfo += "\"";
            theSreenInfo += "Id";
            theSreenInfo += "\"";
            theSreenInfo += ":";
            theSreenInfo += 0;
            theSreenInfo += ",";

            theSreenInfo += "\"";
            theSreenInfo += "ScreenShot";
            theSreenInfo += "\"";
            theSreenInfo += ":";
            theSreenInfo += "\"";
            theSreenInfo += Utils.Converter.FromBytesToBase64(
                                  Converter.FromBitmapToBytes(
                                      GetFullScreenShot()
                    ));
            theSreenInfo += "\"";

            theSreenInfo += "}";
            return theSreenInfo;
            //throw new NotImplementedException();
        }

        private Bitmap GetFullScreenShot()
        {
            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenTop = SystemInformation.VirtualScreen.Top;
            int screenWidth = SystemInformation.VirtualScreen.Width;
            int screenHeight = SystemInformation.VirtualScreen.Height;

            // Create a bitmap of the appropriate size to receive the screenshot.
            Bitmap screenShot = new Bitmap(screenWidth,
            screenHeight,
            PixelFormat.Format32bppArgb);

            Graphics memGraphics = Graphics.FromImage(screenShot);
            memGraphics.CopyFromScreen(screenLeft,
                screenTop,
                0,
                0,
                screenShot.Size,
                CopyPixelOperation.SourceCopy);
            //
            return screenShot;


        }





        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }



    }
}
