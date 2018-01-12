using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TestBinding
{


    public class SortableBindingList<T> : BindingList<T>
    {
        //---- prendo le proprieta' che mi serviranno poi per fare il mio ordinamento
        private ListSortDirection m_Direction = ListSortDirection.Ascending;
        private PropertyDescriptor m_SortProperty;

        protected override ListSortDirection SortDirectionCore
        { get { return m_Direction; } }

        protected override PropertyDescriptor SortPropertyCore
        { get { return m_SortProperty; } }

        //-- come vedi torna sempre true cosi' fai capire alla griglia che puo' ordinare la collezione
        protected override bool SupportsSortingCore
        { get { return true; } }



        //-- questo è il posto dove farai tu l'ordinamento, in base alle proprieta'
        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> items = this.Items as List<T>;
            if (items != null)
            {
                m_Direction = direction;
                m_SortProperty = property;
                items.Sort(new Comparison<T>(confronto));
            }
        }

        //---- questo effettivcamente fa il confronto
        private int confronto(T obj1, T obj2)
        {

            if ((obj1 == null) && (obj2 != null))
                return 1;

            if ((obj1 != null) && (obj2 == null))
                return -1;

            if ((obj1 == null) && (obj2 == null))
                return 0;


            int Ris = 0;
            Ris = ((IComparable)m_SortProperty.GetValue(obj1)).CompareTo(m_SortProperty.GetValue(obj2));
            if (m_Direction == ListSortDirection.Descending)
                Ris = -Ris;

            return Ris;
        }
    }
}