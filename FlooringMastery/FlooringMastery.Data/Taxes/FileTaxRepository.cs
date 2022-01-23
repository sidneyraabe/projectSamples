using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.Taxes
{
    public class FileTaxRepository : ITax
    {
        public const string filePath = @".\Taxes.txt";
        public static List<Tax> taxes = new List<Tax>();
        public Tax LoadTaxRate(string StateAbbreviation)
        {
            ReadAllFromFile();
            return taxes.Where(x => x.StateAbbreviation == StateAbbreviation).FirstOrDefault();

        }
        private void ReadAllFromFile()
        {
            string[] entries = File.ReadAllLines(filePath);
            entries = entries.Skip(1).ToArray();

            foreach (var entry in entries)
            {
                Tax item = ConvertLineToTaxInfo(entry);
                taxes.Add(item);
            }
        }
        private Tax ConvertLineToTaxInfo(string line)
        {
            string[] columns = line.Split(',');

            Tax taxInstance = new Tax();

            taxInstance.StateAbbreviation = columns[0];
            taxInstance.StateName = columns[1];
            taxInstance.TaxRate = decimal.Parse(columns[2]);

            return taxInstance;
        }

        //potentially delete \/
        public List<Tax> GetTax()
        {
            List<Tax> all = new List<Tax>();
            foreach(Tax t in taxes)
            {
                all.Add(t);
            }
            return all;
        }
    }
}
