using NounManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NounManager.Data
{
    public class NounRepository
    {
        public static List<Noun> data;
        public NounRepository()
        {
            if (data == null)
            {
                data = new List<Noun>();
            }
        }
        public Noun Create(Noun noun)
        {
            noun.Id = GenerateId();
            data.Add(noun);
            return noun;
        }

        public List<Noun> ReadAll()
        {
            return data;
        }

        public Noun ReadById(int Id)
        {
            foreach (Noun noun in data)
            {
                if (noun.Id == Id)
                    return noun;
            }
            return null;
        }

        public void Update(Noun noun, string title, string author, int date, bool award)
        {
            noun.Title = title;
            noun.Author = author;
            noun.DatePublished = date;
            noun.IsAwardWinner = award;
        }


        public void Delete(int id)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].Id == id)
                {
                    data.RemoveAt(i);
                    break;
                }
            }
        }

        private int GenerateId()
        {
            if (data.Count == 0)
                return 1;
            return data.Max(x => x.Id) + 1;
        }
    }
}
