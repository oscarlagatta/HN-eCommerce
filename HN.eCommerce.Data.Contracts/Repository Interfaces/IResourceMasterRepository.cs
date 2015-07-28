using HN.eCommerce.Business.Entities;
using Core.Common.Contracts;
using System.Collections.Generic;

namespace HN.eCommerce.Data.Contracts
{
    public interface IResourceMasterRepository : IDataRepository<ResourceMaster>
    {
        IEnumerable<ResourceMaster> GetByCultureCode(string cultureCode);
    }
}