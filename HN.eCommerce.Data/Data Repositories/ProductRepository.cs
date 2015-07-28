using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.eCommerce.Business.Entities;
using HN.eCommerce.Data.Contracts;

namespace HN.eCommerce.Data
{
   
    [Export(typeof(IProductRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ProductRepository : DataRepositoryBase<Product>, IProductRepository
    {
        protected override Product AddEntity(eCommerceContext entityContext, Product entity)
        {
            return entityContext.ProductSet.Add(entity);
        }

        protected override Product UpdateEntity(eCommerceContext entityContext, Product entity)
        {
            return (from e in entityContext.ProductSet
                    where e.ProductId == entity.ProductId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Product> GetEntities(eCommerceContext entityContext)
        {
            return from e in entityContext.ProductSet
                   select e;
        }

        protected override Product GetEntity(eCommerceContext entityContext, int id)
        {
            var query = (from e in entityContext.ProductSet
                         where e.ProductId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public Product GetByAsin(string asinCode)
        {
            using (eCommerceContext entityContext = new eCommerceContext())
            {
                return (from a in entityContext.ProductSet
                        where a.Asin == asinCode
                        select a).FirstOrDefault();
            }
        }
    }
}