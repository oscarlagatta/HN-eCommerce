using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using HN.eCommerce.Business.Common;

namespace HN.eCommerce.Business.Business_Engines
{
    [Export(typeof(IProductEngine))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class StyleEngine : IStyleEngine
    {
       

    }
}
