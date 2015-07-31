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
        [FaultContract(typeof(AuthorizationValidationException))]
        Style GetStyleInfo(int MerretStyleID);

        //[OperationContract]
        //[FaultContract(typeof(AuthorizationValidationException))]
        //[TransactionFlow(TransactionFlowOption.Allowed)]
        //void UpdateStyleInfo(Style style);
    }
}