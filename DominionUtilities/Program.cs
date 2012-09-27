using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Windows.Forms;

namespace DominionUtilities
{
    class Program
    {
        static GraphicsDevice GraphicsDevice;
        static Form form;
        static void InitGraphics()
        {
            PresentationParameters parameters = new PresentationParameters();
            parameters.BackBufferWidth = 1024;
            parameters.BackBufferHeight = 1024;
            parameters.BackBufferFormat = SurfaceFormat.Color;
            parameters.DepthStencilFormat = DepthFormat.None;
            parameters.IsFullScreen = false;
            parameters.MultiSampleCount = 0;
            parameters.PresentationInterval = PresentInterval.Default;
            form = new Form();
            parameters.DeviceWindowHandle = form.Handle;
            GraphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, parameters);
        }

        static void Main(string[] args)
        {
            InitGraphics();

            for (int i = 0; i < args.Length; ++i)
            {
                string arg = args[i];
                arg = arg.Substring(arg.LastIndexOf('\\') + 1, arg.Length - arg.LastIndexOf('\\') - 1);
                if (File.Exists(arg))
                {
                    try
                    {
                        Texture2D src = Texture2D.FromStream(GraphicsDevice, File.OpenRead(arg));
                        Texture2D dest = new Texture2D(GraphicsDevice, src.Width >> 1, src.Height >> 1);
                        Color[] src_pix = new Color[src.Width * src.Height];
                        Color[] dest_pix = new Color[dest.Width * dest.Height];
                        src.GetData<Color>(src_pix);
                        for (int j = 0; j < dest.Width; ++j)
                        {
                            for (int k = 0; k < dest.Height; ++k)
                            {
                                dest_pix[(k * dest.Width) + j] = src_pix[((k<<1) * src.Width) + (j<<1)];
                            }
                        }
                        dest.SetData<Color>(dest_pix);
                        dest.SaveAsJpeg(File.OpenWrite("h_" + arg), dest.Width, dest.Height);
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
        }
    }
}
