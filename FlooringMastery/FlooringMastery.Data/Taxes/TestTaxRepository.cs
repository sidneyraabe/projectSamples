using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.Taxes
{
    public class TestTaxRepository : ITax
    {
        private static Tax _tax = new Tax
        {
            StateAbbreviation = "OH",
            StateName = "Ohio",
            TaxRate = 6.25M
        };
        
        public Tax LoadTaxRate(string StateAbbreviation)
        {
            if (StateAbbreviation != "OH")
                return null;
            return _tax;
        }
    }
}
