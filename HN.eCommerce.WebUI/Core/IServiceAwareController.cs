using System.Collections.Generic;
using Core.Common.Contracts;

namespace HN.eCommerce.WebUI.Core
{
    public interface IServiceAwareController
    {
        void RegisterDisposableServices(List<IServiceContract> disposableServices);

        List<IServiceContract> DisposableServices { get; }
    }
}