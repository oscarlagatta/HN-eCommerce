using System.ComponentModel.Composition;
using HN.eCommerce.Client.Contracts;
using HN.eCommerce.Client.Entities;
using Core.Common.ServiceModel;

namespace HN.eCommerce.Client.Proxies
{

    [Export(typeof(ICultureCountryCodeService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CultureCountryCodeClient : UserClientBase<ICultureCountryCodeService>, ICultureCountryCodeService
    {
        public CultureCountryCode GetCultureCountryCode(int cultureCountryCodeId)
        {
            return Channel.GetCultureCountryCode(cultureCountryCodeId);
        }

        public CultureCountryCode[] GetAllCultureCountryCode()
        {
            return Channel.GetAllCultureCountryCode();
        }

        public CultureCountryCode UpdateCultureCountryCode(CultureCountryCode cultureCountryCode)
        {
            return Channel.UpdateCultureCountryCode(cultureCountryCode);
        }

        public void DeleteCultureCountryCode(int cultureCountryCodeId)
        {
            Channel.DeleteCultureCountryCode(cultureCountryCodeId);
        }
    }
}