using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BilancioFenealgest.Middleware
{
    public class IerarchicalListBinder
    {
        IIerarchicalObject _object;
        IIerarchicalContainer _container;


       

        public IerarchicalListBinder() { }

        public void Bind(IIerarchicalContainer container, IIerarchicalObject objectToBind,bool clearAll)
        {
            _container = container;
            _object = objectToBind;

            Bind(clearAll, true);
        }

        public void Bind(IIerarchicalContainer container, IIerarchicalObject objectToBind, bool clearAll, bool viewOtherColumns)
        {
            _container = container;
            _object = objectToBind;

            Bind(clearAll, viewOtherColumns );
        }

        private void Bind(bool clearAll, bool viewOtherColumns)
        {
          
            _container.BeginUpdate();

            if (clearAll)
                _container.Clear();


            INode parent = null;

            ContructContainerLayout(ref parent, _object, viewOtherColumns);

            _container.AddNodeToContainer(parent);

            _container.EndUpdate();

        }


        private void ContructContainerLayout(ref INode parent, IIerarchicalObject objectToBind, bool viewOtherColumns)
        {
          

            INode n;


            if (parent != null)
                if (viewOtherColumns )
                    n = parent.AddNode(objectToBind.Description, objectToBind.Id, objectToBind.IsLeaf, objectToBind.Properties());
                else
                    n = parent.AddNode(objectToBind.Description, objectToBind.Id, objectToBind.IsLeaf,new ArrayList());
            else
            {
                n = _container.CreateNewNode();
                n.Text = objectToBind.Description;
                n.Tag = objectToBind.Id;

                if (n.Tag.ToString() == "A" || n.Tag.ToString() == "P")
                {
                    n.ForeColor = System.Drawing.Color.Blue;
                    n.Font = new System.Drawing.Font(n.Font, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    n.ForeColor = System.Drawing.Color.Black;
                    n.Font = new System.Drawing.Font(n.Font, System.Drawing.FontStyle.Bold);
                }


                if (viewOtherColumns)
                    n.SetNodeAttributes(objectToBind.Properties());
                parent = n;
            }


            if (!objectToBind.IsLeaf)
            {
                foreach (IIerarchicalObject item in objectToBind.IerarchicalSubList())
                {
                    ContructContainerLayout(ref n, item, viewOtherColumns );
                }
            }

        }


    }
}
