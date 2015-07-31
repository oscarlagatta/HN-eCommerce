using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.eCommerce.Business.Entities;
using HN.eCommerce.Data.Contracts;

namespace HN.eCommerce.Data
{
   
    [Export(typeof(IProductRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StyleRepository : DataRepositoryBase<Style>, IStyleRepository
    {
        protected override Style AddEntity(eCommerceContext entityContext, Style entity)
        {
            return entityContext.StyleSet.Add(entity);
        }

        protected override Style UpdateEntity(eCommerceContext entityContext, Style entity)
        {
            return (from e in entityContext.StyleSet
                    where e.MerretStyleID == entity.MerretStyleID
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Style> GetEntities(eCommerceContext entityContext)
        {
            return from e in entityContext.StyleSet
                   select e;
        }

        protected override Style GetEntity(eCommerceContext entityContext, int id)
        {
            var query = (from e in entityContext.StyleSet
                         where e.MerretStyleID == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }


    }
}