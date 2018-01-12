using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.ServiceLayer.DTO;
using TestBinding;

namespace WIN.BILANCIO.PresentationLogicComponents
{
     class TipoOperazioneDecoder
    {
         internal static SortableBindingList<ScrittureDTO> TranslateDomainValuesToListGUIValues(SortableBindingList<ScrittureDTO> list, string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
         {


             foreach (ScrittureDTO dto in list)
             {
                 //Convert(banca1, banca2, banca3, item);
                 dto.Contropartita = Translate(dto.Contropartita, banca1, banca2, banca3, banca4, banca5, banca6);
             }
             return list;

         }

        internal static ScrittureDTO TranslateDomainValuesToGUIValues(ScrittureDTO dto, string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {

            dto.Contropartita = Translate(dto.Contropartita, banca1, banca2, banca3, banca4, banca5, banca6);
            return dto;
          
       }


        private static string Translate(string val, string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {
            string result = "";

            if (val == "Banca1")
            {
                result = banca1;
                
            }
            else if (val == "Banca2")
            {
                result = banca2;
                
            }
            else if (val == "Banca3")
            {
                result = banca3;
               
            }
              else if (val == "Banca4")
            {
                result = banca4;
               
            }
             else if (val == "Banca5")
            {
                result = banca5;
               
            }
             else if (val == "Banca6")
            {
                result = banca6;
               
            }

            if (!string.IsNullOrEmpty(result))
                return result;
            return val;
        }


         //***********************************************************************************+
         //***********************************************************************************

        private static string ConvertTranslatedValueToNormalValue(string val, string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {
            string result = "";
            if (val == banca1)
            {
                result = "Banca1";
        
            } 
            else if (val == banca2)
            {
                result = "Banca2";
               
            }
            else if (val == banca3)
            {
                result = "Banca3";
               
            }
             else if (val == banca4)
            {
                result = "Banca4";
               
            }
             else if (val == banca5)
            {
                result = "Banca5";
               
            }
             else if (val == banca6)
            {
                result = "Banca6";
               
            }

            if (!string.IsNullOrEmpty(result))
                return result;
            return val;
        }

        internal static IList<ScrittureDTO> ConvertGUIValuesToDomainValues(IList<ScrittureDTO> list, string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {
            foreach (ScrittureDTO item in list)
	        {

                Convert(banca1, banca2, banca3,banca4, banca5, banca6, item);
                
	        }

            return list;
           
        }

        private static void Convert(string banca1, string banca2, string banca3, string banca4, string banca5, string banca6, ScrittureDTO item)
        {
            item.Contropartita = ConvertTranslatedValueToNormalValue(item.Contropartita, banca1, banca2, banca3, banca4, banca5, banca6);
        }


    

      
    }
}
