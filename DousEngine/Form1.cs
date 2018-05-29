using DousEngine.Common;
using DousEngine.Entities;
using DousEngine.Physics;
using DousEngine.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DousEngine
{
    public partial class Form1 : Form
    {
        GameEntry game;

        Timer guiUpdate = new Timer();

        public Form1()
        {
            InitializeComponent();

            guiUpdate.Interval = 1;
            guiUpdate.Tick += GuiUpdate_Tick;
            guiUpdate.Start();

            #region Game setup
            game = new GameEntry();
            game.Init();

            DousMain.Init(myViewport1, game);
            DousMain.ClearColor = Color.White;
            DousMain.UdpateInterval = 1;
            DousMain.RenderInterval = 1;
            #endregion
        }

        private void GuiUpdate_Tick(object sender, EventArgs e)
        {
            lFPS.Text = "FPS: " + DousMain.FPS;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DousMain.Stop();
        }
    }
}
