using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Interfaces;
using SGBank.Models;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        public const string filePath = @".\Accounts.txt";
        public static List<Account> data;

        public Account LoadAccount(string AccountNumber)
        {
            ReadAllFromFile();
            return data.Where(x => x.AccountNumber == AccountNumber).FirstOrDefault();
        }

        public void SaveAccount(Account account)
        {
            ReadAllFromFile();
            foreach (var item in data)
            {
                if (item.AccountNumber == account.AccountNumber)
                {
                    item.Balance = account.Balance;
                }
            }
            SaveAllToFile();
            //var originalLines = File.ReadAllLines(filePath);
            //var updatedLines = new List<string>();

            //foreach (var line in originalLines)
            //{
            //    string[] columns = line.Split(',');
            //    if (columns[0] == account.AccountNumber)
            //    {
            //        columns[2] = account.Balance.ToString();
            //    }

            //    updatedLines.Add(string.Join(",", columns));
            //}

            //File.WriteAllLines(filePath, updatedLines);
        }

        private void ReadAllFromFile()
        {
            string[] entries = File.ReadAllLines(filePath);
            entries = entries.Skip(1).ToArray();

            foreach (var entry in entries)
            {
                Account item = ConvertLineToAccount(entry);
                data.Add(item);
            }
        }

        private void SaveAllToFile()
        {
            string[] lines = new string[data.Count() + 1];
            lines[0] = "AccountNumber,Name,Balance,Type";
            int index = 1;

            foreach (var item in data)
            {
                string line = ConvertAccountToLine(item);
                lines[index] = line;
                index++;
            }

            File.WriteAllLines(filePath, lines);
        }

        private string ConvertAccountToLine(Account item)
        {
            return string.Format("{0},{1},{2},{3}", item.AccountNumber, item.Name, item.Balance, item.Type.ToString().ToUpper()[0]);
        }

        private Account ConvertLineToAccount(string line)
        {
            string[] columns = line.Split(',');
            Account account = new Account();
            account.AccountNumber = columns[0];
            account.Name = columns[1];
            account.Balance = Convert.ToDecimal(columns[2]);

            account.Type = AccountType.Free;
            if (columns[3] == "P")
                account.Type = AccountType.Premium;
            if (columns[3] == "B")
                account.Type = AccountType.Basic;
            return account;
        }
    }
}
