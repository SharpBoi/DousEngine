using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DousEngine.Common.Interfaces
{
    public interface IGameEntry
    {
        void Init();
        void Update();
        void Render(Graphics g);
    }
}
