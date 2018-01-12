using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BilancioFenealgest.Middleware
{
    public interface IIerarchicalObject
    {
        string Id{get;set;}
        string Description { get; set; }
        IList<IIerarchicalObject> IerarchicalSubList();
        IList Properties();
        bool IsLeaf { get; }

    }
}
