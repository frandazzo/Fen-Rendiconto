using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WIN.BILANCIO
{
    public class AsyncNotifier
    {
        FenealgestServices.FenealgestwebServices svc;
        string result;
        public AsyncNotifier()
        {
            svc = new FenealgestServices.FenealgestwebServices();
            svc.TraceUsageCompleted += new FenealgestServices.TraceUsageCompletedEventHandler(svc_TraceUsageCompleted);
        }

        void svc_TraceUsageCompleted(object sender, FenealgestServices.TraceUsageCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                //non c'è stata eccezione
                result = e.Error.Message;
            }
            else
            {
                //recuperro il risultato
                result = e.Result;
            }

            File.AppendAllText("c://aaaa.txt", result);
        }

        public  void NotifyUsage()
        {
            svc.TraceUsageAsync("MATERA", "RENDICONTO", "BASILICATA");
        }


    }
}
