using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;

namespace BilancioFenealgest.Middleware
{
    public interface INode
    {


        INode AddNode(string text, object tag, bool isLeaf, IList atributes);
        string Text { get; set; }
        object Tag { get; set; }
        void SetNodeAttributes(IList atributes);
        Font Font { get; set; }
        Color ForeColor { get; set; }
    }
}
