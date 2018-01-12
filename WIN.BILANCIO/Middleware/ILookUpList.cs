using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.Middleware
{
   
        public interface ILookupList
        {
            void Add(string dto);
            void Clear();
            string SelectedItem { get; set; }
            void SelectAt(int index);
            bool Enabled { set; }
            string Text { get; }
        }
   
}
