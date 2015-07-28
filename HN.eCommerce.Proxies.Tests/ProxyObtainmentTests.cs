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

        /// <summary>
        /// obtain a proxy from the container and verify is the proper contract
        /// </summary>
        [TestMethod]
        public void obtain_proxy_from_container_using_service_contract()
        {
            IResourceMasterService proxy =
                ObjectBase.Container.GetExportedValue<IResourceMasterService>();

            Assert.IsTrue(proxy is ResourceMasterClient);
        }

        [TestMethod]
        public void obtain_proxy_from_service_factory()
        {
            IServiceFactory factory = new ServiceFactory();

            IResourceMasterService proxy = factory.CreateClient<IResourceMasterService>();

            Assert.IsTrue(proxy is ResourceMasterClient);
        }

        [TestMethod]
        public void obtain_service_factory_and_proxy_from_container()
        {
            IServiceFactory factory = 
                ObjectBase.Container.GetExportedValue<IServiceFactory>();

            IResourceMasterService proxy = factory.CreateClient<IResourceMasterService>();

            Assert.IsTrue(proxy is ResourceMasterClient);
        }

    }
}