using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProductInventorySystem.Models;

namespace ProductInventorySystem
{

    [TestFixture]
    class Test
    {

        [SetUp]
        public void Setup()
        {
            //for any shared things you need to setup
        }

        [Test]
        public void GetCustomers_all_ListOfCustomer()
        {
            DatabaseAccessManager dbManager = new DatabaseAccessManager();

            List<Customer> customers = dbManager.GetCustomers();

            Assert.IsNotNull(customers);
        }


    }
}
