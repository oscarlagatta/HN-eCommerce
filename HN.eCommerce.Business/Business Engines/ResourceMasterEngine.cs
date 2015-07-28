using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using HN.eCommerce.Business.Common;
using HN.eCommerce.Business.Entities;

namespace HN.eCommerce.Business
{
    [Export(typeof(IResourceMasterEngine))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ResourceMasterEngine : IResourceMasterEngine
    {
        public bool IsMasterResourceActive(int ResourceId, IEnumerable<ResourceMaster> resourceMasterList )
        {
            bool resourceAvailable = true;

            // here the business logic
            ResourceMaster resourceMaster = resourceMasterList.Where(r => r.ResourceId == ResourceId).FirstOrDefault();
            if (resourceMaster != null && resourceMaster.Culture == "ar") // && resourceMaster.Avctive == true )
            {
                resourceAvailable = false;
            }

            return resourceAvailable;
        }
    }
}