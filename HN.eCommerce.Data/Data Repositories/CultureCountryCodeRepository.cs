using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.eCommerce.Business.Entities;
using HN.eCommerce.Data.Contracts;


namespace HN.eCommerce.Data
{
    [Export(typeof(ICultureCountryCodeRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CultureCountryCodeRepository : DataRepositoryBase<CultureCountryCode>, ICultureCountryCodeRepository
    {
        protected override CultureCountryCode AddEntity(eCommerceContext entityContext, CultureCountryCode entity)
        {
            return entityContext.CultureCountryCodeSet.Add(entity);
        }

        protected override CultureCountryCode UpdateEntity(eCommerceContext entityContext, CultureCountryCode entity)
        {
            return (from e in entityContext.CultureCountryCodeSet
                    where e.Id == entity.Id
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<CultureCountryCode> GetEntities(eCommerceContext entityContext)
        {
            return from e in entityContext.CultureCountryCodeSet
                   select e;
        }

        protected override CultureCountryCode GetEntity(eCommerceContext entityContext, int id)
        {
            var query = (from e in entityContext.CultureCountryCodeSet
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}