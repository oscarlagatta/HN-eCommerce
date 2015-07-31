using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Core;

namespace HN.eCommerce.Client.Entities
{
    public class Style : ObjectBase
    {

        private int _merretStyleID;

        public int MerretStyleID
        {
            get { return _merretStyleID; }
            set { _merretStyleID = value; }
        }

        private string _merretDescription;

        public string MerretDescription
        {
            get { return _merretDescription; }
            set { _merretDescription = value; }
        }

        private Nullable<int> _departmentID;

        public Nullable<int> DepartmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }

        private string _brandID;

        public string BrandID
        {
            get { return _brandID; }
            set { _brandID = value; }
        }

    }
}
