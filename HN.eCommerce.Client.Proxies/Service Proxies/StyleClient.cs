using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.ServiceModel;
using HN.eCommerce.Client.Contracts;

namespace HN.eCommerce.Client.Proxies
{
    [Export(typeof(IStyleService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StyleClient : UserClientBase<IStyleService>, IStyleService
    {
        public Entities.Style GetStyle(int merretStyleID)
        {
            return Channel.GetStyle(merretStyleID);
        }

        public Entities.Style[] GetAllStyles()
        {
            return Channel.GetAllStyles();
        }

        public Entities.Style UpdateStyle(Entities.Style style)
        {
            return Channel.UpdateStyle(style);
        }

        public void DeleteStyle(int merretStyleID)
        {
            Channel.DeleteStyle(merretStyleID);
        }

        public Task<Entities.Style> GetStyleAsync(int merretStyleID)
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Style[]> GetAllStlesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Style> UpdateStlesAsync(Entities.Style style)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStyleAsync(int merretStyleID)
        {
            throw new NotImplementedException();
        }
    }
}
