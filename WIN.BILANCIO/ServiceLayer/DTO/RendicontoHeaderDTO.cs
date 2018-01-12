using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.ServiceLayer.DTO
{
    public class RendicontoHeaderDTO
    {
        public string Provincia { get; set; }
        public string Regione { get; set; }
        public bool IsRegionale { get; set; }
        public int Anno { get; set; }
        public string FolderPath { get; set; }
        public string  FileName { get; set; }
        public string Proprietario { get; set; }
        public string SenderTag { get; set; }


    }
}
