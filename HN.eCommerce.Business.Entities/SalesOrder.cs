using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Core;

namespace HN.eCommerce.Business.Entities
{
    public class SalesOrder : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        public int SalesOrderId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }

        public int EntityId
        {
            get { return SalesOrderId; }
            set { SalesOrderId = value; }
        }

        public int OwnerAccountId
        {
            get{return AccountId;}
            set { AccountId = value; }
        }
    }
}
