using System;
using System.Collections.Generic;
using System.Text;
using WinControls.ListView;
using BilancioFenealgest.UI.PresentationLogicComponents;
using BilancioFenealgest.Middleware;
using System.Drawing;

namespace BilancioFenealgest.UI.UIComponents
{
    public class DesktopTreelist : IIerarchicalContainer
    {
        TreeListView _internalList;


        string _banca1;
        string _banca2;
        string _banca3;

        string _banca4;
        string _banca5;
        string _banca6;

        public DesktopTreelist(TreeListView treeList, string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {
            _internalList = treeList;
            _banca1 = banca1;
            _banca2 = banca2;
            _banca3 = banca3;

            _banca4 = banca4;
            _banca5 = banca5;
            _banca6 = banca6;
            
        }


        public INode SelectedNode
        {
            get
            {
                TreeListNode n = _internalList.SelectedItems[0] as TreeListNode;
                if (n== null)
                    return null;

                return new DesktopTreeListNode(n, _banca1, _banca2, _banca3, _banca4, _banca5, _banca6);
            }
        }



        #region IIerarchicalContainer Membri di

        public void BeginUpdate()
        {
            _internalList.BeginUpdate();
        }

        public void EndUpdate()
        {
            _internalList.EndUpdate();
        }

        public BilancioFenealgest.Middleware.INode CreateNewNode()
        {
            TreeListNode tr = new TreeListNode("Ficticious");


            tr.Font = new Font(tr.Font, FontStyle.Bold);


            DesktopTreeListNode t = new DesktopTreeListNode(tr, _banca1, _banca2, _banca3, _banca4, _banca5, _banca6);

            return t;
        }

        public void AddNodeToContainer(BilancioFenealgest.Middleware.INode node)
        {
            DesktopTreeListNode  n = node as DesktopTreeListNode  ;
            _internalList.Nodes.Add(n.InnerObject);
        }

        #endregion

        #region IIerarchicalContainer Membri di


        public void Clear()
        {
            _internalList.Nodes.Clear();
        }

        #endregion

        #region IIerarchicalContainer Membri di


        public void ExpandAll()
        {
            _internalList.ExpandAll();
        }

        public void CollapseAll()
        {
            _internalList.CollapseAll();
        }

        #endregion

      
    }
}
