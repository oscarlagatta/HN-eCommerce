using HN.eCommerce.Business.Entities;
using Core.Common.Contracts;

namespace HN.eCommerce.Data.Contracts
{
    public interface IProductRepository : IDataRepository<Product>
    {
        Product GetByAsin(string asinCode);
    }
}