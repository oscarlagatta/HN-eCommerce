using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.eCommerce.Business.Entities;
using HN.eCommerce.Data.Contracts;

namespace HN.eCommerce.Data
{
    [Export(typeof(IResourceMasterRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ResourceMasterRepository: DataRepositoryBase<ResourceMaster>, IResourceMasterRepository
    {
        protected override ResourceMaster AddEntity(eCommerceContext entityContext, ResourceMaster entity)
        {
            return entityContext.ResourceMasterSet.Add(entity);
        }

        protected override ResourceMaster UpdateEntity(eCommerceContext entityContext, ResourceMaster entity)
        {
            return (from e in entityContext.ResourceMasterSet
                    where e.ResourceId == entity.ResourceId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<ResourceMaster> GetEntities(eCommerceContext entityContext)
        {
            return from e in entityContext.ResourceMasterSet
                   select e;
        }

        protected override ResourceMaster GetEntity(eCommerceContext entityContext, int id)
        {
            var query = (from e in entityContext.ResourceMasterSet
                         where e.ResourceId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<ResourceMaster> GetByCultureCode(string cultureCode)
        {
            using (eCommerceContext entityContext = new eCommerceContext())
            {
                return  (from e in entityContext.ResourceMasterSet
                    where e.Culture == cultureCode
                    select e);
            }
        }
    }
}