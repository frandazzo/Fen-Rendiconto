using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BilancioFenealgest.Middleware
{
    public class StringListBinder : ILookupCollection 
    {
         private IList items;

         public StringListBinder(ICollection items)
        {
            this.items = new ArrayList(items);// List(items);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public void BindTo(ILookupList list)
        {
            list.Clear();
            foreach (object dto in items)
            {
                list.Add(dto.ToString());
            }

        }
    }
}
