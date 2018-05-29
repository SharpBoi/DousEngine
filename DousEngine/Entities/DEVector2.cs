using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DousEngine.Entities
{
    public struct DEVector2
    {
        #region Statics
        public static PointF[] ToPoints(DEVector2[] vectors)
        {
            PointF[] pnts = new PointF[vectors.Length];
            for (int i = 0; i < pnts.Length; i++)
                pnts[i] = vectors[i].PointF;

            return pnts;
        }
        #endregion

        #region Fields
        public float x;
        public float y;
        #endregion

        #region Funcs
        public DEVector2(float X, float Y)
        {
            x = X;
            y = Y;
        }
        public DEVector2(float Radian)
        {
            x = y = 0;
            SetAngle(Radian);
        }

        /// <summary>
        /// Нормализует этот вектор
        /// </summary>
        public DEVector2 Normalize()
        {
            float mag = Magnitude;
            x /= mag;
            y /= mag;

            return this;
        }
        public void SetAngle(float radian)
        {
            float srcMag = Magnitude;
            x = (float)Math.Cos(radian) * srcMag;
            y = (float)Math.Sin(radian) * srcMag;
        }
        public void SetMagnitude(float value)
        {
            DEVector2 dir = Normalized;
            dir *= value;
            x = dir.x;
            y = dir.y;
        }

        public override string ToString()
        {
            return x + "; " + y;
        }
        #endregion

        #region Props
        /// <summary>
        /// Возвращает или задает магнитуду этого вектора
        /// </summary>
        public float Magnitude { get { return (float)Math.Sqrt(x * x + y * y); } }
        
        /// <summary>
        /// Возвращает нормализованную копию этого вектора
        /// </summary>
        public DEVector2 Normalized
        {
            get
            {
                float mag = Magnitude;
                return new DEVector2(x / mag, y / mag);
            }
        }

        /// <summary>
        /// Возвращает нормаль к этому вектору
        /// </summary>
        public DEVector2 Normal { get { return new DEVector2(-y, x).Normalize(); } }

        /// <summary>
        /// Возвращает или задает угол этого вектора. Задача сохраняет магнитуду
        /// </summary>
        public float AngleRad { get { return (float)Math.Atan2(y, x); } }

        public Point Point { get { return new Point((int)x, (int)y); } }
        public PointF PointF { get { return new PointF(x, y); } }
        #endregion

        #region Operators
        public static DEVector2 operator +(DEVector2 a, DEVector2 b)
        {
            return new DEVector2(a.x + b.x, a.y + b.y);
        }
        public static DEVector2 operator -(DEVector2 a, DEVector2 b)
        {
            return new DEVector2(a.x - b.x, a.y - b.y);
        }
        public static DEVector2 operator *(DEVector2 a, float b)
        {
            return new DEVector2(a.x * b, a.y * b);
        }
        public static DEVector2 operator *(float b, DEVector2 a)
        {
            return new DEVector2(a.x * b, a.y * b);
        }
        public static DEVector2 operator /(DEVector2 a, float b)
        {
            return new DEVector2(a.x / b, a.y / b);
        }
        #endregion
    }
}
