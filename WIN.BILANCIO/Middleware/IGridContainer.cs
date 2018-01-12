using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace BilancioFenealgest.Middleware
{
    public interface IGridContainer<T>
    {
        void SetSource(BindingList<T> source);
        T CurrentObject();
        int SelectedRows { get; }
        IList<T> CurrentObjects();

        void RefreshAll();
        void RefreshCurrent();

        IList BoundList { get; }

        bool AutoGenerateColumns { set; }
        void IsColumnVisible(int index, bool visible);

        object ConcreteWidget { get; }


    }
}
