using HN.eCommerce.Client.Bootstrapper;
using HN.eCommerce.Client.Contracts;
using HN.eCommerce.Client.Proxies;
using Core.Common.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HN.eCommerce.Proxies.Tests
{
    [TestClass]
    public class ServiceAccessTests
    {
        [TestMethod]
        public void test_product_client_connection()
        {
            ProductClient proxy = new ProductClient();

            proxy.Open();
        }

    }
}