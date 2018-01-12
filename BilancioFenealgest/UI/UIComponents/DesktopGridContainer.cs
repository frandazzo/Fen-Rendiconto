using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;
using System.Windows.Forms;

namespace BilancioFenealgest.UI.UIComponents
{
    public class DesktopGridContainer<T> : IGridContainer<T>
    {
        #region IGridContainer<T> Membri di


        DataGridView _grid;
        BindingSource _source;

        public DesktopGridContainer(DataGridView grid, BindingSource source)
        {
            _grid = grid;

            

            _source = source;

            _grid.DataSource = _source;
        }



        public void SetSource(System.ComponentModel.BindingList<T> source)
        {
            _source.DataSource = source;
        }

        public T CurrentObject()
        {
            try
            {
                return (T)_source.Current;
            }
            catch (Exception)
            {
                return default(T);
            }
            
        }



        public void RefreshAll()
        {
            _source.ResetBindings(false);
        }

        public void RefreshCurrent()
        {
            _source.ResetCurrentItem();
        }


        public bool AutoGenerateColumns
        {
            set { _grid.AutoGenerateColumns = value; }
        }


        public System.Collections.IList BoundList
        {
            get { return _source.List; }
        }

 
        public void IsColumnVisible(int index, bool visible)
        {
            try
            {
                _grid.Columns[index].Visible = visible;
            }
            catch (Exception)
            {

            }
        }

 
        public object ConcreteWidget
        {
            get { return _grid ; }
        }

 

        public int SelectedRows
        {
            get { return _grid.SelectedRows.Count ; }
        }

        public IList<T> CurrentObjects()
        {
            IList<T> l = new List<T>();
            foreach (DataGridViewRow  item in _grid.SelectedRows )
            {
                T elem = (T)item.DataBoundItem;
                l.Add(elem);
            }

            return l;
        }

        #endregion
    }
}
