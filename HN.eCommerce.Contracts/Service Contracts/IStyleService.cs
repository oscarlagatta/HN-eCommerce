using System.ServiceModel;
using HN.eCommerce.Business.Entities;
using HN.eCommerce.Common;
using Core.Common.Exceptions;

namespace HN.eCommerce.Contracts
{
    [ServiceContract]
    public interface IStyleService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        Style GetStyle(int MerretStleID);

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