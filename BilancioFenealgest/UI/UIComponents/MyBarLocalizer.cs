using System;
using System.Collections.Generic;
using System.Text;

namespace BilancioFenealgest.UI.UIComponents
{
    public class MyBarLocalizer : DevExpress.XtraBars.Localization.BarResLocalizer
    {
        public override string GetLocalizedString(DevExpress.XtraBars.Localization.BarString id)
        {
            if (id == DevExpress.XtraBars.Localization.BarString.SkinCaptions)
                return "|Diva|Caramello|Moneta|Asphalt|Noesis|Lilian|Nero|Blue|Office 2010 Blue|Office 2010 Black|Office 2010 Silver|Office 2007 Blue|Office 2007 Black|Office 2007 Silver|Office 2007 Green|Office 2007 Pink|Seven|Seven Classic|Darkroom|McSkin|Sharp|Sharp Plus|Nebbia|Dark Side|Natale (Blue)|Primavera|Estate|Pumpkin|Valentina|Polvere di stelle|Coffee|Glass Oceans|Alto contrasto|Liquid Sky|London Liquid Sky|";
            return base.GetLocalizedString(id);
        }
    }
}
