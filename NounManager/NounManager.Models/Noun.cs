using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NounManager.Models
{
    public class Noun
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int DatePublished { get; set; }
        public bool IsAwardWinner { get; set; }

    }
}
