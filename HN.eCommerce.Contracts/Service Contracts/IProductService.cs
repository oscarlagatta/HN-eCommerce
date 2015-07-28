using System;
using System.ServiceModel;
using HN.eCommerce.Business.Entities;
using Core.Common.Exceptions;

namespace HN.eCommerce.Contracts
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Product GetProduct(int productId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Product[] GetAllProducts();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Product UpdateProdcut(Product product);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteProduct(int ProductId);

        Product[] GetAvailableProducts(DateTime pickupDate, DateTime returnDate);
    }
}