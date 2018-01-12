using System;
using System.Collections.Generic;
using System.Text;
using WIN.BASEREUSE;

namespace BilancioFenealgest.ServiceLayer.ExcelExporter
{
    public class ExcelSearchCriteria
    {
        public int MaxRowPrimaColonna { get; private set; }
        public int MaxRowSecondaColonna { get; private set; }
        public int MaxColPrimaColonna { get; private set; }
        public int MaxColSecondaColonna { get; private set; }


        public OfficeExcelHandler.FindMode  FindMode { get; set; }


        public ExcelSearchCriteria(int searchType, 
                int maxRowPrimaColonna, 
                int maxRowSecondaColonna,
                int maxColPrimaColonna, 
                int maxColSecondaColonna)
        {
            MaxRowPrimaColonna = maxRowPrimaColonna;
            MaxRowSecondaColonna = maxRowSecondaColonna;
            MaxColPrimaColonna = maxColPrimaColonna;
            MaxColSecondaColonna = maxColSecondaColonna;

            switch (searchType)
            {

                case 1:
                    FindMode = OfficeExcelHandler.FindMode.LockColumn;
                    break;

                case 2:
                    FindMode = OfficeExcelHandler.FindMode.LockRow ;
                    break;

                case 3:
                    FindMode = OfficeExcelHandler.FindMode.Table ;
                    break;


                default:
                    FindMode = OfficeExcelHandler.FindMode.Table;
                    break;
            }

        }
    }
}
