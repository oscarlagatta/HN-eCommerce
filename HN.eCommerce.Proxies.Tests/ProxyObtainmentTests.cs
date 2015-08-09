using HN.eCommerce.Client.Bootstrapper;
using HN.eCommerce.Client.Contracts;
using HN.eCommerce.Client.Proxies;
using Core.Common.Contracts;
using Core.Common.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HN.eCommerce.Proxies.Tests
{
    [TestClass]
    public class ProxyObtainmentTests
    {

        [TestInitialize]
        public void Initialize()
        {
            ObjectBase.Container = MEFLoader.Init();
        }

    }
}