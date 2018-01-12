using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;
using System.IO;
using BilancioFenealgest.ServiceLayer;
using System.Reflection;

namespace BilancioFenealgest.UI.PresentationLogicComponents
{
    public class StartupFormPresenter
    {
        IStartupFormView _view;
        


        public StartupFormPresenter(IStartupFormView view)
        {
            _view = view;
           
        }


        public void InitializeForm()
        {
            _view.SetHeader();
        }


        public void CreateNewBilancio()
        {
            try
            {


                if (_view.IsFreeTemplate)
                {
                    //recupero il nome del file template
                    string templateFile = CreteFreeTemplatePath();

                    if (File.Exists(templateFile))
                    {
                        CreateFromFreeTemplate(templateFile);
                    }
                    else
                    {
                        //chiedo all'utente quale template usare
                        AskForNewFreeTemplate();
                    }
                }
                else
                {
                    CreateFromFactory();
                }
            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
            
        }

        private void CreateFromFreeTemplate(string template)
        {
          
            RendicontoService _service = new RendicontoService();


            //IRendicontoHeaderView v = _view.RendicontoHeaderView;
            //RendicontoHeaderFormPresenter presenter = new RendicontoHeaderFormPresenter(v, _service, ActionType.New);
            //v.SetPresenter(presenter);


            //presenter.InitializeView();
            ////a questo punto posso utilizzare il presenter per visualizzare il form
            //if (presenter.StartDialog())
            //{
            IOpenFileClass c = _view.GetFolderBrowserDialog();

            string p = "";
            if (c.ShowAndContinue())
                p = c.GetFileName();


            string bilancioPath = _service.CreateNewRendiconto(template, p);

            //_view.GetSimpleMessageNotificator().Show("Rendiconto salvato in: " + bilancioPath, "Info", MessageType.Information);


            //dopo aver caricato il bilancio
            _service.LoadRendiconto(bilancioPath);

            //ne imposto i parametri per la testata
            IRendicontoHeaderView v = _view.RendicontoHeaderView;
            RendicontoHeaderFormPresenter presenter = new RendicontoHeaderFormPresenter(v, _service, ActionType.Update);
            v.SetPresenter(presenter);


            presenter.InitializeView();
            //a questo punto posso utilizzare il presenter per visualizzare il form
            presenter.StartDialog();
            //salvo i dati di testata
            _service.Save();

            //avvio il form principale
            IBilancioFormView bilView = _view.BilancioView(bilancioPath);
            bilView.ShowNoDialog();
          

        }

        private string CreteFreeTemplatePath()
        {
            string model = _view.FileFreeTemplate;

            model = "\\Modelli\\" + model;

            string path = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(path);

            string dir = f.DirectoryName;

            return dir + model;
        }

        private void AskForNewFreeTemplate()
        {
            string template ="";

            IOpenFileClass o = _view.GetOpenFileDialog();

            o.SetFilter("File xml|*.xml;*.XML");

            if (o.ShowAndContinue())
            {
                template = o.GetFileName();
                RendicontoService _service = new RendicontoService();

                IOpenFileClass c = _view.GetFolderBrowserDialog();

                string p = "";
                if (c.ShowAndContinue())
                    p = c.GetFileName();

                string bilancioPath =_service.CreateNewRendiconto(template,p);

                _view.GetSimpleMessageNotificator().Show("Rendiconto salvato in: " + bilancioPath, "Info", MessageType.Information);

                IBilancioFormView bilView = _view.BilancioView(bilancioPath);
                bilView.ShowNoDialog();
            }




        }

        private void CreateFromFactory()
        {
            RendicontoService _service = new RendicontoService();

            IRendicontoHeaderView v = _view.RendicontoHeaderView;
            RendicontoHeaderFormPresenter presenter = new RendicontoHeaderFormPresenter(v, _service, ActionType.New);
            v.SetPresenter(presenter);


            presenter.InitializeView();
            //a questo punto posso utilizzare il presenter per visualizzare il form
            if (presenter.StartDialog())
            {
                IBilancioFormView bilView = _view.BilancioView(presenter.CreatedBilancioPath);
                bilView.ShowNoDialog();

            }
        }


        public void OpenExistingBilancio()
        {


            try
            {
                //prendo il file da aprire
                string fileName= GetFileName();

                //se ho annullato la selezione
                if (string.IsNullOrEmpty(fileName))
                    return;
                //a questo punto chiedo 
                //alla view di mostrare il form per il bilancio
                //con il file da visualizzare

                IBilancioFormView v = _view.BilancioView(fileName);

                v.ShowNoDialog();



            }
            catch (Exception ex)
            {
                _view.GetSimpleMessageNotificator().Show(ex.Message, "Errore", MessageType.Error);
            }
        }

        private string GetFileName()
        {
            string fileName;


            fileName = "";
            string filter = "File xml|*.xml;*.XML";
            IOpenFileClass open = _view.GetOpenFileDialog();

            open.SetFilter(filter);
            //chiedo all'utente il nome del file
            if (open.ShowAndContinue())
            {
                fileName = open.GetFileName();
            }


            return fileName;
        }


      


    }
}


