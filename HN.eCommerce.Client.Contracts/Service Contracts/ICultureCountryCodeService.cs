using System;
using System.ServiceModel;
using HN.eCommerce.Client.Entities;
using Core.Common.Contracts;
using Core.Common.Exceptions;

namespace HN.eCommerce.Client.Contracts
{
    [ServiceContract]
    public interface ICultureCountryCodeService :IServiceContract
    {
        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CultureCountryCode GetCultureCountryCode(int cultureCountryCodeId);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CultureCountryCode[] GetAllCultureCountryCode();

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CultureCountryCode UpdateCultureCountryCode(CultureCountryCode cultureCountryCode);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void DeleteCultureCountryCode(int cultureCountryCodeId);
    }
}