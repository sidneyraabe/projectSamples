﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Tables
{
    public class Model
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int MakeId { get; set; }
        public string UserId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
