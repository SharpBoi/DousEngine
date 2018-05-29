using DousEngine.Common.Interfaces;
using DousEngine.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DousEngine.Common
{
    public static class DousMain
    {
        #region Fields
        // graphon
        static Graphics gViewPort;
        static Graphics gRender;
        static Bitmap renderTexture;
        static Thread renderThread;

        static Stopwatch fpser;

        // phys
        static Thread updateThread;

        // common
        static IGameEntry game;

        internal static List<DEGameObject> updates = new List<DEGameObject>();
        internal static List<DEGameObject> renders = new List<DEGameObject>();
        internal static List<DEGameObject> owns = new List<DEGameObject>();

        #endregion

        #region Funcs
        public static void Init(Control Viewport, IGameEntry gameEntry)
        {
            game = gameEntry;

            // Graphics inits
            fpser = new Stopwatch();
            ClearColor = Color.Wheat;

            gViewPort = Viewport.CreateGraphics();
            renderTexture = new Bitmap(Viewport.Width, Viewport.Height);
            gRender = Graphics.FromImage(renderTexture);

            IsRender = true;
            RenderInterval = 1;

            renderThread = new Thread(render);
            renderThread.Start();

            // physics inits
            UdpateInterval = 1;
            IsUpdating = true;

            updateThread = new Thread(update);
            updateThread.Start();
        }

        private static void update()
        {
            while (IsUpdating)
            {
                game.Update();

                for (int i = 0; i < updates.Count; i++)
                    updates[i].Update();

                try { Thread.Sleep(UdpateInterval); } catch { }
            }
        }

        private static void render()
        {
            while (IsRender)
            {
                fpser.Start();
                //~~~~~~~~~~~~
                gRender.Clear(ClearColor);

                // TODO : your render
                game.Render(gRender);

                for (int i = 0; i < renders.Count; i++)
                    renders[i].Render(gRender);

                gViewPort.DrawImage(renderTexture, Point.Empty);
                try { Thread.Sleep(RenderInterval); } catch { }

                // fps measure;
                fpser.Stop();
                FPS = (1000 / fpser.ElapsedMilliseconds) * 0.6f;
                fpser.Reset();
            }
        }

        public static void Stop()
        {
            IsRender = false;
            IsUpdating = false;
        }
        #endregion

        #region Props
        // graph
        public static int RenderInterval { get; set; }
        public static Color ClearColor { get; set; }
        public static bool IsRender { get; set; }
        public static float FPS { get; private set; }

        // phys
        public static int UdpateInterval { get; set; }
        public static bool IsUpdating { get; set; }
        #endregion
    }
}
