using Core.Common.Contracts;
using Core.Common.Data;

namespace HN.eCommerce.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, eCommerceContext>
       where T : class, IIdentifiableEntity, new()
    {
    }
}