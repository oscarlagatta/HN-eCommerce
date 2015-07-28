using System.ComponentModel.Composition.Hosting;
using HN.eCommerce.Data;

namespace HN.eCommerce.Business.Bootstrapper
{
    public static class MEFLoader
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ProductRepository).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ProductEngine).Assembly));

            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }
    }
}