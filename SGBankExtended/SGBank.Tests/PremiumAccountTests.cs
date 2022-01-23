using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL.WithdrawRules;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        //No deposit testing; premium uses same no-limit rule, as tested in BasicAccountTests

        [TestCase("66666", "Premium Account", 100, AccountType.Free, -50, false)]//wrongaccType
        [TestCase("66666", "Premium Account", 100, AccountType.Premium, 50, false)]//+withdraw
        [TestCase("66666", "Premium Account", 100, AccountType.Premium, -1000, false)]//overdraft>500
        [TestCase("66666", "Premium Account", 100, AccountType.Premium, -350, true)]

        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name,
            decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);
            Assert.AreEqual(response.Success, expectedResult);
        }
    }
}
