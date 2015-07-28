using System.ServiceModel;
using HN.eCommerce.Client.Entities;
using Core.Common.Contracts;
using Core.Common.Exceptions;

namespace HN.eCommerce.Client.Contracts
{
    [ServiceContract]
    public interface IResourceMasterService : IServiceContract
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