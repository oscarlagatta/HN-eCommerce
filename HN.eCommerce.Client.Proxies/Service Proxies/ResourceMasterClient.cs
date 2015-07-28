using System.ComponentModel.Composition;
using System.ServiceModel;
using System.Threading;
using HN.eCommerce.Client.Contracts;
using Core.Common.ServiceModel;

namespace HN.eCommerce.Client.Proxies
{
    [Export(typeof(IResourceMasterService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ResourceMasterClient : UserClientBase<IResourceMasterService>, IResourceMasterService
    {
        
        public Entities.ResourceMaster GetMasterResource(string resourceKey)
        {
            return Channel.GetMasterResource(resourceKey);
        }

        public Entities.ResourceMaster[] GetAllMasterResources()
        {
            return Channel.GetAllMasterResources();
        }

        public Entities.ResourceMaster UpdateMasterResource(Entities.ResourceMaster resource)
        {
            return Channel.UpdateMasterResource(resource);
        }

        public void DeleteMasterResource(int ResourceId)
        {
            Channel.DeleteMasterResource(ResourceId);
        }

        public string[] GetAvailableMasterResources()
        {
            return Channel.GetAvailableMasterResources();
        }
    }
}