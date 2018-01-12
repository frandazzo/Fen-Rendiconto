using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BilancioFenealgest
{
    internal class ProgramParameters
    {
    
        //il comando da eseguire
        //Possibili valori "1", "2" (Openfile, Create)
        public string Command { get; set; }


        //************************************
        //CREAZIONE

        //Possibili valori "1" (provinciale) , "2" (regionale), "3" (rlst)
        public string RendicontoType { get; set; }

        //regione rendiconto
        public string Regione { get; set; }

        //provincia rendiconto
        public string Provincia { get; set; }

        //il nome del file da creare
        public string FilenameToCreate { get; set; }

        //il percorso  del file da create
        public string PathToCreate { get; set; }

        //Anno di riferimento per l'iscrizione
        public string Year { get; set; }

        //lista codificata dei saldi iniziali
        public string Saldi { get; set; }


        //************************************
        //APERTURA FILE 

        //il percorso e il nome del file da aprire
        public string FileToOpen { get; set; }



        public void ValidateParams()
        {
            //verifico i paramteri inseriti
            //verifico il command
            if (Command != "1" && Command != "2")
                throw new ArgumentException("Comando errato: " + Command);


            //se il comando  è correntto devo verificare la presenza dei paramteri corretti a seconda del tipo di comando
            if (Command == "1") //apertura
            {
                //devo verificate la presenza del FileToOpen
                bool exist = File.Exists(FileToOpen);
                if (!exist)
                    throw new ArgumentException("File non  esistente");
            }
            else
            {

                if (string.IsNullOrEmpty (FilenameToCreate))
                    throw new ArgumentException("Nome del file da creare vuoto");


                //se creo un nuovo rendiconto devo specificarne i seguenti paramteri
                //deve esistere un nome e non deve esistere il file
                if (!Directory.Exists(PathToCreate))
                    throw new ArgumentException("Percorso dove creare il rendiconto non  esistente: " + PathToCreate);

               
                //devo verificare il tipo di rendiconto da creare
                if (RendicontoType != "1" && RendicontoType != "2" && RendicontoType != "3")
                    throw new ArgumentException("Tipo rendiconto sconosciuto: ");



               //rimane da verificare provincia e regione
                if (RendicontoType == "1") //provinciale
                {
                    //devo verificare che non sia nulla la stringa della regione e della provicnia

                    if (string.IsNullOrEmpty(Provincia))
                        throw new ArgumentException("Provincia nulla");

                    if (string.IsNullOrEmpty(Regione))
                        throw new ArgumentException("Regione nulla");

                }
                else if (RendicontoType == "2") //regoinale
                {
                    if (string.IsNullOrEmpty(Regione))
                        throw new ArgumentException("Regione nulla");
                }
                else if (RendicontoType == "3") //rlst
                {
                    if (string.IsNullOrEmpty(Provincia))
                        throw new ArgumentException("Provincia nulla");

                    if (string.IsNullOrEmpty(Regione))
                        throw new ArgumentException("Regione nulla");
                }


            }

        }


        private ProgramParameters()
        {
            FileToOpen = "";
            Saldi = "";
            Year = DateTime.Now.Year.ToString();
           
            PathToCreate = "";
            Provincia= "";
            Regione= "";
            RendicontoType= "";
            Command = "";
        }

        private static ProgramParameters _instance;

        public static ProgramParameters Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProgramParameters();
                return _instance;
            }
        }


    }
}
