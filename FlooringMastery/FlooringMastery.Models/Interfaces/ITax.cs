﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface ITax
    {
        Tax LoadTaxRate(string StateAbbreviation);
    }
}
