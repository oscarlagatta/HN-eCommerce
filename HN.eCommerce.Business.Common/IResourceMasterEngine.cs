using System.Collections.Generic;
using Core.Common.Contracts;
using HN.eCommerce.Business.Entities;

namespace HN.eCommerce.Business.Common
{
    public interface IResourceMasterEngine : IBusinessEngine
    {
        bool IsMasterResourceActive(int ResourceId, IEnumerable<ResourceMaster> resourceMasterList);
    }
}