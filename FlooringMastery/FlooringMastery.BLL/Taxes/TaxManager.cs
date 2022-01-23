using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class TaxManager
    {
        private ITax _tax;

        public TaxManager(ITax tax)
        {
            _tax = tax;
        }

        public TaxLookupResponse LookupTax(string state)
        {
            TaxLookupResponse response = new TaxLookupResponse();

            response.Tax = _tax.LoadTaxRate(state);

                if (response.Tax == null)
            {
                response.Success = false;

                response.Message = $"{state} is not currently in the tax directory.";
            }
            else
                response.Success = true;
            return response;
        }
    }
}
