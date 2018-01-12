using System;
using System.Collections.Generic;
using System.Text;
using WinControls.ListView;
using BilancioFenealgest.Middleware;
using BilancioFenealgest.DomainLayer;

namespace BilancioFenealgest.UI.UIComponents
{
    public class DesktopTreeListNode : INode
    {

        TreeListNode _node;
        string _banca1;
        string _banca2;
        string _banca3;
        string _banca4;
        string _banca5;
        string _banca6;

        public DesktopTreeListNode(TreeListNode node, string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {
            _node = node;
            _banca1 = banca1;
            _banca2 = banca2;
            _banca3 = banca3;
            _banca4 = banca4;
            _banca5 = banca5;
            _banca6 = banca6;

        }

        public INode AddNode(string text, object tag, bool isLeaf, System.Collections.IList atributes)
        {
            string newName = "";
            if (text == "Banca1")
                newName = _banca1;//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale; 
            else if (text == "Banca2")
                newName = _banca2;//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale; 
            else if (text == "Banca3")
                newName = _banca3;// TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale; 


            else if (text == "Banca4")
                newName = _banca4;// TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale; 
            else if (text == "Banca5")
                newName = _banca5;// TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale; 
            else if (text == "Banca6")
                newName = _banca6;// TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale; 



            else
                newName = text;

            TreeListNode n;
            if (isLeaf)
            {
                n = _node.Nodes.Add(newName, 4, 4);

                if (tag.ToString().StartsWith("A") || tag.ToString().StartsWith("P"))
                    n.ForeColor = System.Drawing.Color.Blue;

                else if(tag.ToString().StartsWith("S.OD") || tag.ToString().StartsWith("E.OD"))
                    n.ForeColor = System.Drawing.Color.DarkGreen;
                else
                    n.ForeColor = System.Drawing.Color.Black;

                
                n.Tag = tag;
            }
            else
            {
                n = _node.Nodes.Add(newName, 0, 1);

                if (tag.ToString().StartsWith("A") || tag.ToString().StartsWith("P"))
                    n.ForeColor = System.Drawing.Color.Blue;
                else if (tag.ToString().StartsWith("S.OD") || tag.ToString().StartsWith("E.OD"))
                    n.ForeColor = System.Drawing.Color.DarkGreen;
                else
                    n.ForeColor = System.Drawing.Color.Black;

                n.Font = new System.Drawing.Font(n.Font, System.Drawing.FontStyle.Bold);
               
                n.Tag = tag;
            }


            foreach (object item in atributes)
            {
                n.SubItems.Add(item.ToString());
            }



            return new DesktopTreeListNode(n, _banca1, _banca2, _banca3, _banca4, _banca5, _banca6);

        }

        public void SetNodeAttributes(System.Collections.IList atributes)
        {
            foreach (object item in atributes)
            {
                _node.SubItems.Add(item.ToString());
            }
        }

        public TreeListNode InnerObject
        {
            get { return _node; }
        }


        #region INode Membri di


        public string Text
        {
            get
            {
                return _node.Text;
            }
            set
            {
                _node.Text = value;
            }
        }

        public object Tag
        {
            get
            {
                return _node.Tag;
            }
            set
            {
                _node.Tag = value;
            }
        }

        #endregion


        public System.Drawing.Font Font
        {
            get
            {
                return _node.Font;
            }
            set
            {
                _node.Font = value;
            }
        }

        public System.Drawing.Color ForeColor
        {
            get
            {
                return _node.ForeColor;
            }
            set
            {
                _node.ForeColor = value;
            }
        }
    }
}
