using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HN.eCommerce.Client.Contracts;
using HN.eCommerce.Client.Entities;
using HN.eCommerce.WebUI.Core;
using HN.eCommerce.WebUI.Models;
using Core.Common.Contracts;

namespace HN.eCommerce.WebUI.Controllers.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/culturecountrycode")]
    [UsesDisposableService]
    public class CultureCountryCodeApiController : ApiControllerBase
    {
         [ImportingConstructor]
        public CultureCountryCodeApiController(ICultureCountryCodeService cultureCountryCodeService)
        {
            _cultureCountryCodeService = cultureCountryCodeService;
        }

         ICultureCountryCodeService _cultureCountryCodeService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_cultureCountryCodeService);
        }

        [HttpPost]
        [Route("availableculturecountrycodes")]
        public HttpResponseMessage GetAvailableProducts(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                CultureCountryCode[] cultureCountryCodes = _cultureCountryCodeService.GetAllCultureCountryCode();

                return request.CreateResponse<CultureCountryCode[]>(HttpStatusCode.OK, cultureCountryCodes);
            });
        }
    }
}
