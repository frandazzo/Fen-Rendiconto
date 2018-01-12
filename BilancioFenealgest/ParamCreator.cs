using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest
{
    internal class ParamCreator
    {



         string[] _args;

        public ParamCreator(string[] args)
        {
            _args = args;
        }


        public void Create()
        {
            if (_args == null)
                return;

            foreach (string item in _args)
            {
                if (item.StartsWith("cmd"))
                {
                    CreateCommand(item);
                }
		        else if (item.StartsWith("fto"))
                {
                    CreateFileToOpen(item);
                }
                else if (item.StartsWith("sal"))
                {
                    CreateSaldi(item);
                }
                else if (item.StartsWith("yea"))
                {
                    CreateYear(item);
                }
                else if (item.StartsWith("ftc"))
                {
                    CreateFileToCreate(item);
                }
                else if (item.StartsWith("pro"))
                {
                    CreateProvince(item);
                }
                else if (item.StartsWith("reg"))
                {
                    CreateRegion(item);
                }
                else if (item.StartsWith("ret"))
                {
                    CreateRendicontotype(item);
                }
                else if (item.StartsWith("fnt"))
                {
                    CreateFilenameToCreate(item);
                }
                

            }

            ProgramParameters.Instance.ValidateParams();
            

        }

        private void CreateFilenameToCreate(string item)
        {
            ProgramParameters.Instance.FilenameToCreate = ClearPrefix(item);
        }

      

        private void CreateRendicontotype(string item)
        {
            ProgramParameters.Instance.RendicontoType = ClearPrefix(item);
        }

        private void CreateRegion(string item)
        {
            ProgramParameters.Instance.Regione = ClearPrefix(item);
        }

        private void CreateProvince(string item)
        {
            ProgramParameters.Instance.Provincia = ClearPrefix(item);
        }

        private void CreateFileToCreate(string item)
        {
            ProgramParameters.Instance.PathToCreate = ClearPrefix(item);
        }

        private void CreateSaldi(string item)
        {
            ProgramParameters.Instance.Saldi = ClearPrefix(item);
        }

        private void CreateFileToOpen(string item)
        {
            ProgramParameters.Instance.FileToOpen = ClearPrefix(item);
        }

    
    
        private void CreateYear(string item)
        {
            try 
	        {
                ProgramParameters.Instance.Year = Convert.ToInt32(ClearPrefix(item)).ToString();
	        }
	        catch (Exception)
	        {

                ProgramParameters.Instance.Year = DateTime.Now.Year.ToString();
	        }
            
        }

     

        private string ClearPrefix(string item)
        {
            return item.Substring(4);
        }

        private void CreateCommand(string item)
        {
            ProgramParameters.Instance.Command = ClearPrefix(item);
        }

    

    
   



    














    }
}
