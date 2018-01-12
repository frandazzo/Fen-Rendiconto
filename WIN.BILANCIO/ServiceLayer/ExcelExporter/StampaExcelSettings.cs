using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.BILANCIO.ServiceLayer.ExcelExporter
{
    public class StampaExcelSettings
    {
        private int _InventarioColonnaIniziale = 0;
        private bool _InventarioDisegnaOrizzontalmente = false;
        private int _InventarioRigaIniziale = 0;
        private int _InventarioRigheFraTipiInventario = 3;
        private bool _InventarioScriviIntestazioniTipoInventario = true;
        private bool _InventarioScriviTipoInventario = true;
        private bool _InventarioFeneal = true;
        private bool _stampaPreventivo = true;
        private DateTime _dateToExport;

         private bool _stampaStatoPatrimoniale = true;

        public bool StampaPreventivo
        {
            get
            {
                return _stampaPreventivo;
            }
           
        }

        public StampaExcelSettings()
        {

        }
        public StampaExcelSettings(bool inventarioScriviTipoInventario, bool inventarioScriviIntestazioniTipoInventario, int inventarioRigheFraTipiInventario, int inventarioRigaIniziale, bool inventarioDisegnaOrizzontalmente, int inventarioColonnaIniziale, bool inventarioFeneal, bool stampaPreventivo, bool stampaStatoPatrimoniale, DateTime dateToExport)
        {
            _stampaStatoPatrimoniale = stampaStatoPatrimoniale;
            _stampaPreventivo = stampaPreventivo;
            if (inventarioColonnaIniziale < 0)
                throw new ArgumentOutOfRangeException("Colonna iniziale setting stampa su excel su ExcelExporter");
            if (inventarioRigaIniziale < 0)
                throw new ArgumentOutOfRangeException("Rige iniziale setting stampa su excel su ExcelExporter");
            _InventarioColonnaIniziale = inventarioColonnaIniziale;
            _InventarioDisegnaOrizzontalmente = inventarioDisegnaOrizzontalmente;
            _InventarioRigaIniziale = inventarioRigaIniziale;
            _InventarioRigheFraTipiInventario = inventarioRigheFraTipiInventario;
            _InventarioScriviIntestazioniTipoInventario = inventarioScriviIntestazioniTipoInventario;
            _InventarioScriviTipoInventario = inventarioScriviTipoInventario;
            _InventarioFeneal = inventarioFeneal;
            _dateToExport = dateToExport;
        }

        public bool InventarioScriviTipoInventario
        {
            get { return _InventarioScriviTipoInventario; }
        }

        public bool InventarioFeneal
        {
            get { return _InventarioFeneal; }
        }

        public DateTime  DateToExport
        {
            get { return _dateToExport ; }
        }



        public bool InventarioScriviIntestazioniTipoInventario
        {
            get { return _InventarioScriviIntestazioniTipoInventario; }
        }

        public bool InventarioDisegnaOrizzontalmente
        {
            get { return _InventarioDisegnaOrizzontalmente; }
        }

        public int InventarioColonnaIniziale
        {
            get { return _InventarioColonnaIniziale; }
        }

        public int InventarioRigaIniziale
        {
            get { return _InventarioRigaIniziale; }
        }

        public int InventarioRigheFraTipiInventario
        {
            get { return _InventarioRigheFraTipiInventario; }
        }
        public bool StampaStatoPatrimoniale
        {
            get
            {
                return _stampaStatoPatrimoniale;
            }
        }
    }
}
