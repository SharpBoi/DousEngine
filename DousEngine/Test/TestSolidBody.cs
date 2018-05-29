using DousEngine.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DousEngine.Test
{
    class TestSolidBody : DEGameObject
    {
        public TestSolidBody() : base()
        {
            base.InitUpdate();
            base.InitRender();
        }

        protected internal override void Update()
        {
        }

        protected internal override void Render(Graphics g)
        {
        }
    }
}
