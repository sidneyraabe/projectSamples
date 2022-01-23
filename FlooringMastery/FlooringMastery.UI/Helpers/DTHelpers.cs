using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Helpers
{
    public class DTHelpers
    {
        public string DTObjectToString(DateTime dt)
        {
            string sdt = dt.ToString("MMddyyyy");
            return sdt;
        }

        public string MakeStringLookNice(string dt)
        {
            DateTime dtobject = DateTime.ParseExact(dt, "MMddyyyy", null);
            string newdtstring = dtobject.ToString("MMM dd, yyyy");
            return newdtstring;
        }
    }
}
