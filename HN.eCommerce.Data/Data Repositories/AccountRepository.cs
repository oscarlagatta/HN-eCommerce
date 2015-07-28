using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.eCommerce.Business.Entities;
using HN.eCommerce.Data.Contracts;

namespace HN.eCommerce.Data
{
    [Export(typeof(IAccountRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountRepository : DataRepositoryBase<Account>, IAccountRepository
    {
        protected override Account AddEntity(eCommerceContext entityContext, Account entity)
        {
            return entityContext.AccountSet.Add(entity);
        }

        protected override Account UpdateEntity(eCommerceContext entityContext, Account entity)
        {
            return (from e in entityContext.AccountSet
                    where e.AccountId == entity.AccountId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Account> GetEntities(eCommerceContext entityContext)
        {
            return from e in entityContext.AccountSet
                   select e;
        }

        protected override Account GetEntity(eCommerceContext entityContext, int id)
        {
            var query = (from e in entityContext.AccountSet
                         where e.AccountId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public Account GetByLogin(string login)
        {
            using (eCommerceContext entityContext = new eCommerceContext())
            {
                return (from a in entityContext.AccountSet
                        where a.LoginEmail == login
                        select a).FirstOrDefault();
            }
        }
    }
}