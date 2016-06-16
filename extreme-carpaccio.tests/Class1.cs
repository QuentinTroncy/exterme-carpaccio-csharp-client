using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using xCarpaccio.client;

namespace extreme_carpaccio.tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void JeTestToutDUnCoup()
        {
            Order order = null;
             order.Prices = new decimal[1];
             order.Prices[0] = (decimal) 1.5;

             order.Quantities = new int[1];
             order.Quantities[0] = 2;


        }
    }
}
