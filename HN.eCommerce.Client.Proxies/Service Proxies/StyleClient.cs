using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.ServiceModel;
using HN.eCommerce.Client.Contracts;
using HN.eCommerce.Client.Entities;

namespace HN.eCommerce.Client.Proxies
{
    [Export(typeof(IStyleService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StyleClient : UserClientBase<IStyleService>, IStyleService
    {
        public Style GetStyle(int merretStyleID)
        {
            return Channel.GetStyle(merretStyleID);
        }

        public Style[] GetAllStyles()
        {
            var styles = Channel.GetAllStyles();

            return styles;
        }

        public Style UpdateStyle(Style style)
        {
            return Channel.UpdateStyle(style);
        }

        public void DeleteStyle(int MerretStleID)
        {
            Channel.DeleteStyle(MerretStleID);
        }
    }
}
