using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;
using System.IO;

namespace BilancioFenealgest.UI.UIComponents
{
    public class DesktopFolderBrowserNavigator : IOpenFileClass
    {

        System.Windows.Forms.FolderBrowserDialog  _dialog;

        public DesktopFolderBrowserNavigator(System.Windows.Forms.FolderBrowserDialog dialog)
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
            if (!Directory.Exists(_dialog.SelectedPath ))
                throw new FileNotFoundException();
            return _dialog.SelectedPath;
        }

        public void SetFilter(string filter)
        {
            //
        }

        #endregion

    }
}

