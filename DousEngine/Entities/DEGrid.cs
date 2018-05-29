using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DousEngine.Entities
{
    public class DEGrid
    {
        #region Fields
        private DEVector2[] srcVerts;
        private DEVector2[] rsltVerts;

        private DEVector2 pos;
        private float angleRad;
        private DEVector2 scale;
        private DEVector2 right;
        #endregion

        #region Funcs
        public DEGrid()
        {
            right = new DEVector2(1, 0);

            scale = new DEVector2(1, 1);
        }

        private void updateVertsPosRotScale()
        {
            for (int i = 0; i < rsltVerts.Length; i++)
            {
                // scale
                rsltVerts[i].x = srcVerts[i].x * scale.x;
                rsltVerts[i].y = srcVerts[i].y * scale.y;

                // rot
                //rsltVerts[i] = srcVerts[i].x * Right + srcVerts[i].y * Up;
                rsltVerts[i] = rsltVerts[i].x * right + rsltVerts[i].y * right.Normal;

                // pos
                rsltVerts[i] += pos;
            }
        }
        #endregion

        #region Props
        public DEVector2 Pos
        {
            get { return pos; }
            set
            {
                pos = value;
                updateVertsPosRotScale();
            }
        }
        public float AngleRad
        {
            get { return angleRad; }
            set
            {
                angleRad = value;

                right.SetAngle(angleRad);
                right.Normalize();

                updateVertsPosRotScale();
            }
        }
        public DEVector2 Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                updateVertsPosRotScale();
            }
        }

        public DEVector2 Right { get { return right; } }
        public DEVector2 Up { get { return right.Normal; } }

        public DEVector2[] SourceVerts { get { return srcVerts; } set { srcVerts = value; rsltVerts = new DEVector2[value.Length]; updateVertsPosRotScale(); } }
        public DEVector2[] ResultVerts { get { return rsltVerts; } }
        #endregion
    }
}
