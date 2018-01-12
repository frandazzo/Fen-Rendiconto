using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;

namespace BilancioFenealgest.Middleware
{
    public interface IIerarchicalContainer
    {
        void BeginUpdate();
        void EndUpdate();
        INode CreateNewNode();
        void AddNodeToContainer(INode node);
        void Clear();
        void ExpandAll();
        void CollapseAll();
        INode SelectedNode { get; }

    }
}
