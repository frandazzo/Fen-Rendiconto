using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.BILANCIO.ServiceLayer.DTO
{
    public class ScritturaPrimaNotaDTO
    {
       
        public string Conto { get; set; }
        public DateTime Data { get; set; }
        public string Causale { get; set; }
        public string Pezza { get; set; }
        public double Dare { get; set; }
        public double Avere { get; set; }
        public string Contropartita { get; set; }

        public string ContoContropartita { get; set; }


        public static int CompareByDate(ScritturaPrimaNotaDTO x, ScritturaPrimaNotaDTO y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.Data.CompareTo(y.Data);

                    if (retval != 0)
                    {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return retval;
                    }
                    else
                    {
                        // If the strings are of equal length,
                        // sort them with ordinary string comparison.
                        //
                        return x.Data.CompareTo(y.Data);
                    }
                }
            }







        }
    }
}
