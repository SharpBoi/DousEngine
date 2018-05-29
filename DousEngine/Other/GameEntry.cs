using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DousEngine.Common.Interfaces;
using DousEngine.Entities;
using DousEngine.Test;

namespace DousEngine
{
    class GameEntry : IGameEntry
    {
        float x = 0;
        PointF[] poly = new PointF[40];
        float[] startRadiuses;
        float[] radiuses;
        Random rnd = new Random();

        DEGrid grid;

        public void Init()
        {
            startRadiuses = new float[poly.Length];
            for (int i = 0; i < startRadiuses.Length; i++)
            {
                startRadiuses[i] = (float)rnd.NextDouble();
            }

            radiuses = new float[startRadiuses.Length];

            for(int i = 0; i < poly.Length; i++)
            {
                float angle = i * ((float)Math.PI * 2 / poly.Length);
                poly[i] = new PointF(
                    (float)Math.Cos(angle) * 50 + 100,
                    (float)Math.Sin(angle) * 50 + 100);
            }

            grid = new DEGrid();
            grid.SourceVerts = new DEVector2[]
            {
                new DEVector2(0,0),
                new DEVector2(50, 0),
                new DEVector2(50,50),
                new DEVector2(0, 50)
            };
            grid.Pos = new DEVector2(0, 100);

            TestSolidBody test = new TestSolidBody();
        }

        public void Update()
        {
            x += 0.1f;

            for (int i = 0; i < radiuses.Length; i++)
            {
                startRadiuses[i] += 1f / (100);
                radiuses[i] = (float)Math.Sin(startRadiuses[i]) * 8 + 40;
            }
            
            for (int i = 0; i < poly.Length; i++)
            {
                float angle = i * ((float)Math.PI * 2 / poly.Length);
                poly[i] = new PointF(
                    (float)Math.Cos(angle) * radiuses[i] + 100,
                    (float)Math.Sin(angle) * radiuses[i] + 100);
            }

            grid.Pos += new DEVector2(0.01f, 0);
            grid.AngleRad += 0.001f;
            grid.Scale = new DEVector2((float)Math.Sin(grid.Pos.x), (float)Math.Cos(grid.Pos.x));
        }

        Pen p = new Pen(Color.Red);
        SolidBrush b = new SolidBrush(Color.Red);
        public void Render(Graphics g)
        {
            g.DrawPolygon(p, poly);
            g.DrawPolygon(p, DEVector2.ToPoints(grid.ResultVerts));
            //for (int i = 1; i < 20; i++)
            //{
            //    g.FillRectangle(b, x / i, 3 * i, 3, 3);
            //    g.DrawLine(p, 0, 0, x / i, 3 * i);
            //}
        }
    }
}

