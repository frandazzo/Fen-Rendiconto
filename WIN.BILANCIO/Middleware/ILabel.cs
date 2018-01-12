using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace BilancioFenealgest.Middleware
{
    public interface ILabel
    {
        void SetText(string text);
        void SetForeColor(Color color);
    }
}
