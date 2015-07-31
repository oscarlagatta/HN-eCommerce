using System.ServiceModel;
using System.Threading.Tasks;
using HN.eCommerce.Client.Entities;
using Core.Common.Contracts;
using Core.Common.Exceptions;

namespace HN.eCommerce.Client.Contracts
{
    [ServiceContract]
    public interface IStyleService : IServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Product GetStyle(int merretStyleID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Product[] GetAllStyles();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Style UpdateStyle(Style style);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteStyle(int merretStyleID);


        #region Async Operations

        [OperationContract]
        Task<Style> GetStyleAsync(int merretStyleID);

        [OperationContract]
        Task<Style[]> GetAllStlesAsync();

        [OperationContract]
        Task<Style> UpdateStlesAsync(Style style);

        [OperationContract]
        Task DeleteStyleAsync(int merretStyleID);

        #endregion
    }
}