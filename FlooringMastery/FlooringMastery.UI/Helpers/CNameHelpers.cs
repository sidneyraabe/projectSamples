using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Helpers
{
    public class CNameHelpers
    {
        public bool CheckIfValidName(string cName)
        {
            if (cName.All(c => char.IsLetterOrDigit(c) || c == '.' || c == ',' || c == ' '))
                return true;
            return false;
        }
    }
}
