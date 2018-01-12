using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;
using System.IO;

namespace BilancioFenealgest.UI.UIComponents
{
    public class DesktopOpenFileDialog : IOpenFileClass
    {

        System.Windows.Forms.OpenFileDialog  _dialog;

        public DesktopOpenFileDialog(System.Windows.Forms.OpenFileDialog dialog)
        {
            _dialog = dialog;
        }


        #region IOpenFileClass Membri di

        public bool ShowAndContinue()
        {
            if (_dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return true;
            return false;
        }

        public string GetFileName()
        {
            if (!File.Exists(_dialog.FileName))
                throw new FileNotFoundException();
            return _dialog.FileName;
        }

        public void SetFilter(string filter)
        {
            _dialog.Filter = filter;
        }

        #endregion

    }
}
