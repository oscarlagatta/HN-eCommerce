using HN.eCommerce.Business.Entities;
using Core.Common.Contracts;

namespace HN.eCommerce.Data.Contracts
{
    public interface IAccountRepository : IDataRepository<Account>
    {
        Account GetByLogin(string login);
    }
}