using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using BilancioFenealgest.Middleware;
using System.Windows.Forms;

namespace BilancioFenealgest.UI.UIComponents
{
    public class DesktopLabel : ILabel
    {
        private Label _label;

        public DesktopLabel(Label label)
        {
            _label = label;
        }

        #region ILabel Membri di

        public void SetText(string text)
        {
            _label.Text = text;
        }

        public void SetForeColor(Color color)
        {
            _label.ForeColor = color;
        }

        #endregion
    }
}
