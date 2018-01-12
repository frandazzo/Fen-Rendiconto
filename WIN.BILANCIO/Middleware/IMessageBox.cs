using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.Middleware
{
    public interface IMessageBox
    {
        void Show(string message, string title, MessageType type);
        bool ShowAndContibue(string message, string title);
    }

    public enum MessageType
    {
        Warning,
        Information,
        Error,
        Exclamation
    }
}
