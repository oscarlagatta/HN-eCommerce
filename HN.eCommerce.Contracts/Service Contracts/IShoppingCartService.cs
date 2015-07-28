using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using HN.eCommerce.Business.Entities;
using HN.eCommerce.Common;

namespace HN.eCommerce.Contracts
{
    [ServiceContract]
    public interface IShoppingCartService
    {
        [OperationContract]
        [FaultContract(typeof(AuthorizationValidationException))]
        IEnumerable<SalesOrder> GetSalesOrderHistory(string loginEmail);
    }
}