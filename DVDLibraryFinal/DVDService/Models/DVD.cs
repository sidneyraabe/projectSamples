﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDService.Models
{
    public class DVD
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public string Notes { get; set; }
    }
}