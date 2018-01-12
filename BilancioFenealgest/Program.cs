

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WIN.BASEREUSE;
using BilancioFenealgest.ServiceLayer.GeoElements;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Security;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System.Reflection;
using System.IO;
using BilancioFenealgest.UI;
using System.Threading;
using BilancioFenealgest.UI.PresentationLogicComponents;
using BilancioFenealgest.UI.UIComponents;
using BilancioFenealgest.ServiceLayer.DTO;
using BilancioFenealgest.ServiceLayer;
using WIN.BILANCIO;

//cmd:1 fto:"c://matera.xml"
//cmd:2 ret:1 yea:2013 fnt:aaa.xml pro:MILANO reg:LOMBARDIA ftc:c:// sal:@@A.I.1#0@@A.I.2#46@@A.I.3#23@@A.I.4#0@@A.C.1#0@@A.C.2#23@@A.D.1#0@@A.D.2.a#400@@A.D.2.b#-115,45@@A.D.2.c#-3423@@P.D.1#0@@P.D.2#0@@P.D.3#0@@P.D.4#46@@P.D.5#0@@P.D.6#0@@P.D.7#0@@P.L.1#0@@P.F.1#0@@P.F.2#0@@P.F.3#0@@P.P.1#400

namespace BilancioFenealgest
{
  
    static class Program
    {

        public static ApplicationContext _Context;
        public static SplashForm _Splash;


        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            



            if (args.Length > 0)
            {

                PreInitializeComponents();

                //estraggo i parametri nel singleton ProgramParameters
                ParamCreator creator = new ParamCreator(args);
                creator.Create();


                //adesso in base al tipo di comando (apro un rendoconto esistente o ne creo uno nuovo)
                //eseguo

                if (ProgramParameters.Instance.Command == "1")
                {
                    //RendicontoService r = new RendicontoService();
                    //r.LoadRendiconto(ProgramParameters.Instance.FileToOpen);
                    //string saldi = r.RetrievePatternSaldiFinaliStatoPatrimoniale();


                    //apro il rendiconto saltando lo splash screen e il form per la scelta di quele operazione eseguire
                    //IBilancioFormView frm = new FrmBilancio(ProgramParameters.Instance.FileToOpen);
                    Application.Run(new FrmBilancio(ProgramParameters.Instance.FileToOpen));

                   

                }
                else
                {
                    // a questo punto si tratta di capire cosa si vuole creare:
                    //un rendiconto feneal (provinciale o regionale) o un rendiconto rlst

                    

                  





                    //devo pertanto verificare il rendiconto type:
                    if (ProgramParameters.Instance.RendicontoType == "1") //feneal provinciale
                    {
                        RendicontoHeaderDTO dto = new RendicontoHeaderDTO();
                        dto.Anno = Convert.ToInt32(ProgramParameters.Instance.Year);
                        dto.Proprietario = "Feneal provinciale";
                        dto.FileName = ProgramParameters.Instance.FilenameToCreate;
                        dto.Provincia = ProgramParameters.Instance.Provincia;
                        dto.Regione = ProgramParameters.Instance.Regione;
                        dto.IsRegionale = false;
                        dto.SenderTag = "FENEAL";
                        dto.FolderPath = ProgramParameters.Instance.PathToCreate;

                        //creo il rendiconto
                        RendicontoService r = new RendicontoService();
                        string rendicontoPath = r.CreateNewRendiconto(dto);
                        //carico il rendiconto
                        r.LoadRendiconto(rendicontoPath);

                        //imposto il saldo iniziale
                        r.SetSaldiInizialiStatoPatrimonialeFromPattern(ProgramParameters.Instance.Saldi);
                        r.Save();
                        //visualizzo il rendiconto
                        Application.Run(new FrmBilancio(rendicontoPath));

                    }
                    else if (ProgramParameters.Instance.RendicontoType == "2") //regionale
                    {
                        RendicontoHeaderDTO dto = new RendicontoHeaderDTO();
                        dto.Anno = Convert.ToInt32(ProgramParameters.Instance.Year);
                        dto.Proprietario = "Feneal regionale";
                        dto.FileName = ProgramParameters.Instance.FilenameToCreate ;
                        dto.Provincia = ProgramParameters.Instance.Provincia;
                        dto.Regione = ProgramParameters.Instance.Regione;
                        dto.IsRegionale = true;
                        dto.SenderTag = "FENEAL";
                        dto.FolderPath = ProgramParameters.Instance.PathToCreate;


                        //creo il rendiconto
                        RendicontoService r = new RendicontoService();
                        string rendicontoPath = r.CreateNewRendiconto(dto);
                        //carico il rendiconto
                        r.LoadRendiconto(rendicontoPath);
                        //imposto il saldo iniziale
                        r.SetSaldiInizialiStatoPatrimonialeFromPattern(ProgramParameters.Instance.Saldi);
                        r.Save();

                        //visualizzo il rendiconto
                        Application.Run(new FrmBilancio(rendicontoPath));
                    }
                    else //rlst
                    {
                        string template = CreteFreeTemplatePath(Properties.Settings.Default.FileFreeTemplate);
                        string pathRoSave = ProgramParameters.Instance.PathToCreate;

                        RendicontoService r = new RendicontoService();
                        string rendicontoPath = r.CreateNewRendiconto(template, pathRoSave, ProgramParameters.Instance.FilenameToCreate);
                        //carico il rendiconto
                        r.LoadRendiconto(rendicontoPath);


                        RendicontoHeaderDTO dto = new RendicontoHeaderDTO();
                        dto.Anno = Convert.ToInt32(ProgramParameters.Instance.Year);
                        dto.Proprietario = "Feneal RLST";
                        dto.Provincia = ProgramParameters.Instance.Provincia;
                        dto.Regione = ProgramParameters.Instance.Regione;
                        r.RendicontoSendableTag  = "RLST";

                        r.RendicontoHeader = dto;


                        //imposto il saldo iniziale
                        r.SetSaldiInizialiStatoPatrimonialeFromPattern(ProgramParameters.Instance.Saldi);

                        r.Save();

                        //visualizzo il rendiconto
                        Application.Run(new FrmBilancio(rendicontoPath));
                     
                    }

                     

                    //creazione di un rendiconto da un template


                    //string bilancioPath = _service.CreateNewRendiconto(template, p);
                    //(percorso template e percorso dove salvare il file)


                    //          //dopo aver caricato il bilancio
                    //          _service.LoadRendiconto(bilancioPath);

                    //RendicontoHeaderDTO dto = new RendicontoHeaderDTO();
                    //           dto.Anno = _view.SelectedYear;
                    //           dto.Proprietario= _view.SelectedProprietario;
                    //           dto.Provincia = _view.SelectedProvince;
                    //           dto.Regione = _view.SelectedRegion;
                    //           _service.RendicontoHeader = dto;
                    //  _service.Save();
                }

              

                return;
            }

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevexpressInitializzation();
           

            if (Properties.Settings.Default.IsFeneal && Properties.Settings.Default.IsRlst)
            {
                XtraMessageBox.Show("Proprietà RLST e Feneal non ammissibili");
                return;
            }


            // Initialize custom applicantion context because first the Splash form
            // will start on the main UI thread and then the form will be replaced 
            // by the main form. 
            _Context = new ApplicationContext();
            Application.Idle += new EventHandler(Application_Idle);
            

            // Show the splash screen
            _Splash = new SplashForm();
            _Splash.Show();
            Application.DoEvents();

            // Start main UI thread with the splash screen
            Application.Run(_Context);	



            



       



            //Application.Run(new BilancioFenealgest.UI.UIComponents .Form1());

            //inizializzo il servizio geografico
            //GeoLocationFacade.InitializeInstance(new GeoHandlerClass());
            //GeoHandlerProvider.Instance.Geo = GeoLocationFacade.Instance();
        }

        private static string CreteFreeTemplatePath(string template )
        {
            string model = template ;

            model = "\\Modelli\\" + model;

            string path = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(path);

            string dir = f.DirectoryName;

            return dir + model;
        }


        private static void Application_Idle(object sender, EventArgs e)
        {
            // The application is now ready to load the main form

            if (_Context.MainForm == null)
            {
                // Prevent duplicate event firing
                Application.Idle -= new EventHandler(Application_Idle);

                //// pre initialize components 
                PreInitializeComponents();

                

                // Load the main form 
                _Context.MainForm = new BilancioFenealgest.UI.UIComponents.Form1();

                // Show the form
                _Context.MainForm.Show();

                //	Hide the splash screen
                _Splash.Close();
                _Splash = null;
            }

        }

        private static void PreInitializeComponents()
        {
            InitializeX509CertificateValidation();

            //AsyncNotifier n = new AsyncNotifier();
            //n.NotifyUsage();

            //inizializzo il servizio geografico
            GeoLocationFacade.InitializeInstance(new GeoHandlerClass());
            GeoHandlerProvider.Instance.Geo = GeoLocationFacade.Instance();


            Thread.Sleep(2000);
        }


        private static void DevexpressInitializzation()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.AppStyleName);
            UserLookAndFeel.Default.StyleChanged += new EventHandler(Default_StyleChanged);
        }

        static void Default_StyleChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AppStyleName = UserLookAndFeel.Default.ActiveSkinName;
            Properties.Settings.Default.Save();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {


            // rimuovo il file del layout persicurezza
            RemoveLayoutFile();


            Exception ex = e.ExceptionObject as Exception ;
            if (ex == null)
            {
                XtraMessageBox.Show(e.ExceptionObject.ToString());
                return;
            }



            Exception ex1 = ex.InnerException;

            string message = "(1) " + ex.Message + Environment.NewLine;

            if (ex1 != null)
            {
                message += "(2) " + ex1.Message + Environment.NewLine;
                if (ex1.InnerException != null)
                    message += "(3) " + ex1.InnerException.Message + Environment.NewLine;
            }

            message += "(StackTrace) " + ex.StackTrace + Environment.NewLine;

            message += "(Source) " + ex.Source;


            XtraMessageBox.Show(message);

        }

        private static void RemoveLayoutFile()
        {
            string fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
            FileInfo f = new FileInfo(fileLayout);
            fileLayout = f.DirectoryName;
            fileLayout += "\\LayoutSavings\\layout.xml";
            File.Delete(fileLayout);
        }
        private static void InitializeX509CertificateValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;
        }


        private static bool CertificateValidationCallBack(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            //// If the certificate is a valid, signed certificate, return true.
            //if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
            //{
            //    return true;
            //}

            //// If thre are errors in the certificate chain, look at each error to determine the cause.
            //if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            //{
            //    if (chain != null && chain.ChainStatus != null)
            //    {
            //        foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
            //        {
            //            if ((certificate.Subject == certificate.Issuer) &&
            //               (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
            //            {
            //                // Self-signed certificates with an untrusted root are valid. 
            //                continue;
            //            }
            //            else
            //            {
            //                if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
            //                {
            //                    // If there are any other errors in the certificate chain, the certificate is invalid,
            //                    // so the method returns false.
            //                    return false;
            //                }
            //            }
            //        }
            //    }

            //    // When processing reaches this line, the only errors in the certificate chain are 
            //    // untrusted root errors for self-signed certifcates. These certificates are valid
            //    // for default Exchange server installations, so return true.
            //    return true;
            //}
            //else
            //{
            //    // In all other cases, return false.
            //    return false;
            //}
            return true;
        }

    }
}
