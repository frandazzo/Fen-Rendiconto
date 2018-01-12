using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.DomainLayer;
using TestBinding;
using WIN.BILANCIO.DomainLayer;

namespace BilancioFenealgest.ServiceLayer
{
    public class StatoPatrimonialeService
    {

        StatoPatrimoniale _statoPatrimoniale;

        public StatoPatrimonialeService(StatoPatrimoniale statoPatrimoniale)
        {
            _statoPatrimoniale = statoPatrimoniale;

        }


        public event EventHandler Change;



        protected virtual void RaiseChangeEvent()
        {
            // Raise the event by using the () operator.
            if (Change != null)
                Change(this, new EventArgs());
        }


        public Auto AddAuto()
        {
            Auto a = new Auto();
            _statoPatrimoniale.Autos.Add(a);
            RaiseChangeEvent();
            return a;
        }

        public void RemoveAuto(Auto auto)
        {
            _statoPatrimoniale.Autos.Remove(auto);
            RaiseChangeEvent();
        }


        public SortableBindingList<Auto> SortableAutoList
        {
            get
            {
                SortableBindingList<Auto> f = new SortableBindingList<Auto>();

                foreach (Auto item in _statoPatrimoniale.Autos)
                {
                    f.Add(item);
                }


                return f;
            }
        }



        public Polizza AddPolizza()
        {
            Polizza a = new Polizza();
            _statoPatrimoniale.Polizze.Add(a);
            RaiseChangeEvent();
            return a;
        }

        public void RemovePolizza(Polizza polizza)
        {
            _statoPatrimoniale.Polizze.Remove(polizza);
            RaiseChangeEvent();
        }


        public SortableBindingList<Polizza> SortablePolizzeList
        {
            get
            {
                SortableBindingList<Polizza> f = new SortableBindingList<Polizza>();

                foreach (Polizza item in _statoPatrimoniale.Polizze)
                {
                    f.Add(item);
                }


                return f;
            }
        }



        public Deposito AddDeposito()
        {
            Deposito a = new Deposito();
            _statoPatrimoniale.Depositi.Add(a);
            RaiseChangeEvent();
            return a;
        }

        public void RemoveDeposito(Deposito deposito)
        {
            _statoPatrimoniale.Depositi.Remove(deposito);
            RaiseChangeEvent();
        }


        public SortableBindingList<Deposito> SortableDepositiList
        {
            get
            {
                SortableBindingList<Deposito> f = new SortableBindingList<Deposito>();

                foreach (Deposito item in _statoPatrimoniale.Depositi)
                {
                    f.Add(item);
                }


                return f;
            }
        }


        public Immobile AddImmobile()
        {
            Immobile a = new Immobile();
            _statoPatrimoniale.Immobili.Add(a);
            RaiseChangeEvent();
            return a;
        }

        public void RemoveImmobile(Immobile immobile)
        {
            _statoPatrimoniale.Immobili.Remove(immobile);
            RaiseChangeEvent();
        }


        public SortableBindingList<Immobile> SortableImmobiliList
        {
            get
            {
                SortableBindingList<Immobile> f = new SortableBindingList<Immobile>();

                foreach (Immobile item in _statoPatrimoniale.Immobili)
                {
                    f.Add(item);
                }


                return f;
            }
        }




        public Mobile AddMobile()
        {
            Mobile a = new Mobile();
            _statoPatrimoniale.Mobili.Add(a);
            RaiseChangeEvent();
            return a;
        }

        public void RemoveMobile(Mobile mobile)
        {
            _statoPatrimoniale.Mobili.Remove(mobile);
            RaiseChangeEvent();
        }


        public SortableBindingList<Mobile> SortableMobiliList
        {
            get
            {
                SortableBindingList<Mobile> f = new SortableBindingList<Mobile>();

                foreach (Mobile item in _statoPatrimoniale.Mobili)
                {
                    f.Add(item);
                }


                return f;
            }
        }



        public AccantonamentoTFR AddAccantonamentoTFR()
        {
            AccantonamentoTFR a = new AccantonamentoTFR();
            _statoPatrimoniale.AccantonamentiTFR.Add(a);
            RaiseChangeEvent();
            return a;
        }

        public void RemoveAccantonamentoTFR(AccantonamentoTFR accantonamentoTFR)
        {
            _statoPatrimoniale.AccantonamentiTFR.Remove(accantonamentoTFR);
            RaiseChangeEvent();
        }


        public SortableBindingList<AccantonamentoTFR> SortableAccantonamentiTFRList
        {
            get
            {
                SortableBindingList<AccantonamentoTFR> f = new SortableBindingList<AccantonamentoTFR>();

                foreach (AccantonamentoTFR item in _statoPatrimoniale.AccantonamentiTFR)
                {
                    f.Add(item);
                }


                return f;
            }
        }





        public Chiusura AddChiusura()
        {
            Chiusura a = new Chiusura();
            _statoPatrimoniale.Chiusure.Add(a);
            RaiseChangeEvent();
            return a;
        }

        public void RemoveChiusura(Chiusura chiusura)
        {
            _statoPatrimoniale.Chiusure.Remove(chiusura);
            RaiseChangeEvent();
        }


        public SortableBindingList<Chiusura> SortableChiusureList
        {
            get
            {
                SortableBindingList<Chiusura> f = new SortableBindingList<Chiusura>();

                foreach (Chiusura item in _statoPatrimoniale.Chiusure)
                {
                    f.Add(item);
                }


                return f;
            }
        }




    }
}
