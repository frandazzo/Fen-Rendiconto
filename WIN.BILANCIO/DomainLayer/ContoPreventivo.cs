using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.DomainLayer
{
    public class ContoPreventivo : Conto
    {
        protected override double CalculatePartials(ref double total)
        {
            total += _importo;
            return Importo;
        }

        protected override void CalculatePartials(ref double total, DateTime date)
        {
            total += _importo;
            
        }
        public ContoPreventivo( )
        {
          
        }


        public ContoPreventivo(string description, string id, string parentId)
        {
            _description = description;
            _id = id;
            _parentId = parentId;
        }

        public override void Add(AbstractBilancio part)
        {
            throw new InvalidOperationException("Tentativo di aggiungere sottoelementi ad un conto preventivo");
        }
        public override void Add(Scrittura part, Conto cassa, bool partitaDoppia)
        {
            throw new InvalidOperationException("Tentativo di aggiungere sottoelementi ad un conto gestito a saldo");
        }
    }
}
