﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.DomainLayer
{
    public class ScrittureSearchCriteria
    {
        public bool  FilterByDate { get; set; }
        public DateTime  DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool  NotFilterAutogenerated { get; set; }
        public string FilterCausale { get; set; }
        public string FilterPezza { get; set; }
        public string FilterRiferimento1 { get; set; }
        public string FilterRiferimento2 { get; set; }
        public string FilterRiferimento3 { get; set; }



        public bool Matches(Scrittura scrittura)
        {
            bool result = true;


            if (FilterByDate)
            {
                if (scrittura.Date.Date < DateFrom.Date)
                    return false;
                if (scrittura.Date.Date > DateTo.Date)
                    return false;
            }


            if (!NotFilterAutogenerated)
            {
                if (scrittura.AutoGenerated)
                    return false;
            }

            if (!string.IsNullOrEmpty(FilterCausale))
            {
                if (!scrittura.Causale.ToLower().Contains(FilterCausale.ToLower()))
                    return false;
            }

            if (!string.IsNullOrEmpty(FilterPezza))
            {
                if (!scrittura.NumeroPezza.ToLower().Contains(FilterPezza.ToLower()))
                    return false;
            }

            if (!string.IsNullOrEmpty(FilterRiferimento1))
            {
                if (!scrittura.Riferimento1.ToLower().Contains(FilterRiferimento1.ToLower()))
                    return false;
            }
            if (!string.IsNullOrEmpty(FilterRiferimento2))
            {
                if (!scrittura.Riferimento2.ToLower().Contains(FilterRiferimento2.ToLower()))
                    return false;
            }
            if (!string.IsNullOrEmpty(FilterRiferimento3))
            {
                if (!scrittura.Riferimento3.ToLower().Contains(FilterRiferimento3.ToLower()))
                    return false;
            }


            return result;
        }
    }
}
