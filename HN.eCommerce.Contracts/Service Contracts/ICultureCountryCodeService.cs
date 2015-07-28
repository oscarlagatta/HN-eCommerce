using System;
using System.ServiceModel;
using HN.eCommerce.Business.Entities;
using Core.Common.Exceptions;

namespace HN.eCommerce.Contracts
{
    [ServiceContract]
    public interface ICultureCountryCodeService
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