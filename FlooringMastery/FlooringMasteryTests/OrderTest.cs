using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.BLL.Products;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using NUnit.Framework;

namespace FlooringMasteryTests
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void CanLoadOrderTestData()
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderLookupResponse response = manager.LookupDate("06012013");

            Assert.IsNotNull(response.Order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("Wise", response.Order[0].CustomerName);
        }

        [Test]
        public void CanLoadTaxTestData()
        {
            TaxManager tmanager = TaxManagerFactory.Create();

            TaxLookupResponse response = tmanager.LookupTax("OH");

            Assert.IsNotNull(response.Tax);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("Ohio", response.Tax.StateName);
        }

        [Test]
        public void CanLoadProductTestData()
        {
            ProductManager pmanager = ProductManagerFactory.Create();

            ProductLookupResponse response = pmanager.LookupProduct("Carpet");

            Assert.IsNotNull(response.Product);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("Carpet", response.Product.ProductType);
        }

        [Test]
        public void WeDoNotProvideLatexFlooringYouWeirdo()
        {
            ProductManager pmanager = ProductManagerFactory.Create();

            ProductLookupResponse response = pmanager.LookupProduct("Latex");

            Assert.IsFalse(response.Success);
        }

        [Test]
        public void NotValidState()
        {
            TaxManager tmanager = TaxManagerFactory.Create();

            TaxLookupResponse response = tmanager.LookupTax("TX");

            Assert.IsFalse(response.Success);

        }
    }
}
