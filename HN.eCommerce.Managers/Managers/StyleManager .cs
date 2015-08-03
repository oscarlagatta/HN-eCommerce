using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using HN.eCommerce.Business.Common;
using HN.eCommerce.Business.Entities;
using HN.eCommerce.Contracts;
using HN.eCommerce.Data.Contracts;
using Core.Common.Contracts;
using Core.Common.Exceptions;
using System;

namespace HN.eCommerce.Managers.Managers
{
     [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class StyleManager : ManagerBase, IStyleService
    {
        [Import]
        private IDataRepositoryFactory _dataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _businessEngineFactory;

        public StyleManager()
        {

        }

        
        public StyleManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        public StyleManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
            _businessEngineFactory = businessEngineFactory;
        }


        #region IStyleSservice implementations


        public Style[] GetAllStyles()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var accountRepository
                    = _dataRepositoryFactory.GetDataRepository<IStyleRepository>();

                IEnumerable<Style> styles = accountRepository.Get();

                return styles.ToArray();
            });
        }

        public Style GetStyleInfo(int MerretStyleID)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var productRepositoryFactory = _dataRepositoryFactory.GetDataRepository<IStyleRepository>();

                Style styleEntity = productRepositoryFactory.Get(MerretStyleID);

                if (styleEntity == null)
                {
                    NotFoundException ex
                        = new NotFoundException(string.Format("Style with Id {0} is not in the database. ", MerretStyleID));

                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }

                return styleEntity;
            });
        }


        [OperationBehavior(TransactionScopeRequired = true)]

        public Style UpdateStyleInfo(Style style)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var styleRepository = _dataRepositoryFactory.GetDataRepository<IStyleRepository>();

                Style updatedStyle = null;

                if (style.MerretStyleID == 0)
                    updatedStyle = styleRepository.Add(style);
                else
                    updatedStyle = styleRepository.Update(style);

                return updatedStyle;
            });
        }

        public Style GetStyle(int merretStyleID)
        {
            throw new NotImplementedException();
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public Style UpdateStyle(Style style)
        {
            throw new NotImplementedException();
        }

        public void DeleteStyle(int merretStyleID)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}