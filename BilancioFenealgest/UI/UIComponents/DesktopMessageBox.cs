using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.UI.PresentationLogicComponents;
using System.Windows.Forms;
using BilancioFenealgest.Middleware;
using DevExpress.XtraEditors;

namespace BilancioFenealgest.UI.UIComponents
{
    public class DesktopMessageBox : IMessageBox
    {
        #region IMessageBox Membri di

        public void Show(string message, string title, MessageType type)
        {
            MessageBoxIcon icon = MessageBoxIcon.Error;

            switch (type)
            {
                case MessageType.Warning:
                    icon = MessageBoxIcon.Warning;
                    break;
                case MessageType.Information:
                    icon = MessageBoxIcon.Information ;
                    break;
                case MessageType.Error:
                    icon = MessageBoxIcon.Error ;
                    break;
                case MessageType.Exclamation:
                    icon = MessageBoxIcon.Exclamation;
                    break;
                default:
                    break;
            }

            XtraMessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public bool ShowAndContibue(string message, string title)
        {
            MessageBoxIcon icon = MessageBoxIcon.Question;



            if (XtraMessageBox.Show(message, title, MessageBoxButtons.YesNo, icon) == DialogResult.Yes)
                return true;
            return false;
        }


        #endregion
    }
}
