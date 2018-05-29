using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DousEngine.Entities.Interfaces
{
    public interface IDEColor
    {
        float r { get; set; }
        float g { get; set; }
        float b { get; set; }
        float a { get; set; }

        Color SysColor { get; set; }
    }
}
