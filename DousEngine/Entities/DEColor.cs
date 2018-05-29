using DousEngine.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DousEngine.Entities
{
    public struct DEColor : IDEColor
    {
        public DEColor(float R, float G, float B, float A)
        {
            r = R;
            g = G;
            b = B;
            a = A;
        }
        public DEColor(Color syscolor)
        {
            r = g = b = a = 0;
            SysColor = syscolor;
        }

        public float r { get; set; }
        public float g { get; set; }
        public float b { get; set; }
        public float a { get; set; }

        public Color SysColor
        {
            get => Color.FromArgb((int)(a * 255), (int)(r * 255), (int)(g * 255), (int)(b * 255));
            set
            {
                r = value.R / 255;
                g = value.G / 255;
                b = value.B / 255;
                a = value.A / 255;
            }
        }

        public static implicit operator DEColor(Color sc)
        {
            return new DEColor(sc);
        }
    }
}
