using DousEngine.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DousEngine.Entities
{
    public abstract class DEGameObject
    {
        #region Funcs
        public DEGameObject()
        {

        }

        protected void InitUpdate()
        {
            if (UpdateInited == false)
            {
                UpdateInited = true;
                DousMain.updates.Add(this);
            }
        }
        protected void InitOwnUdpate()
        {
            if (OwnUpdateInited == false)
            {
                OwnUpdateInited = true;
                DousMain.owns.Add(this);
            }
        }
        protected void InitRender()
        {
            if (RenderInited == false)
            {
                RenderInited = true;
                DousMain.renders.Add(this);
            }
        }

        protected internal virtual void Update() { }
        protected internal virtual void OwnUpdate() { }
        protected internal virtual void Render(Graphics g) { }
        #endregion

        #region Props
        internal bool Inited { get; private set; }
        internal bool UpdateInited { get; private set; }
        internal bool OwnUpdateInited { get; private set; }
        internal bool RenderInited { get; private set; }
        #endregion
    }
}
