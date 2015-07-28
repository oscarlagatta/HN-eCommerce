using System.ServiceModel;
using HN.eCommerce.Business.Entities;
using Core.Common.Exceptions;

namespace HN.eCommerce.Contracts
{
    [ServiceContract]
    public interface IResourceMasterService
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ResourceMaster GetMasterResource(string resourceKey);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ResourceMaster[] GetAllMasterResources();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        ResourceMaster UpdateMasterResource(ResourceMaster resource);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteMasterResource(int ResourceId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        string[] GetAvailableMasterResources();

    }
}