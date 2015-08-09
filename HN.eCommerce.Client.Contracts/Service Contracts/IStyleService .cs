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
        Style GetStyle(int merretStyleID);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Style[] GetAllStyles();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Style UpdateStyle(Style style);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteStyle(int MerretStleID);
    }
}