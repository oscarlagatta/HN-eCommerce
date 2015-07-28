using System.Collections.Generic;
using System.ServiceModel;
using HN.eCommerce.Client.Entities;
using HN.eCommerce.Common;
using Core.Common.Contracts;

namespace HN.eCommerce.Client.Contracts
{
    [ServiceContract]
    public interface IShoppingCartService : IServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(AuthorizationValidationException))]
        IEnumerable<SalesOrder> GetSalesOrderHistory(string loginEmail);
    }
}