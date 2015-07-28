using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Antlr.Runtime;
using HN.eCommerce.Client.Contracts;
using HN.eCommerce.Client.Entities;
using HN.eCommerce.WebUI.Core;
using HN.eCommerce.WebUI.Models;
using Core.Common.Contracts;

namespace HN.eCommerce.WebUI.Controllers.API
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/resourcemaster")]
    public class ResourceMasterApiController : ApiControllerBase
    {
        [ImportingConstructor]
        public ResourceMasterApiController(IResourceMasterService resourceMasterService,
            ICultureCountryCodeService cultureCountryCodeService)
        {
            _ResourceMasterService = resourceMasterService;
            _CultureCountryCodeService = cultureCountryCodeService;
        }

        ICultureCountryCodeService _CultureCountryCodeService;
        IResourceMasterService _ResourceMasterService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_ResourceMasterService);
            disposableServices.Add(_CultureCountryCodeService);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("availableresourcemaster")]
        public HttpResponseMessage GetAvailableResourceMaster(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                string[] resourcesMasters = _ResourceMasterService.GetAvailableMasterResources();

                return request.CreateResponse<string[]>(HttpStatusCode.OK, resourcesMasters);
            });
        }


        /// <summary>
        /// Returns a list of currently used cultures
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("editcultures")]
        public HttpResponseMessage EditCultures(HttpRequestMessage request)
        {
            return GetHttpResponse(request, () =>
            {
                string[] existingCultures = _ResourceMasterService.GetAllMasterResources().Select(rm=>rm.Culture).Distinct().ToArray();

                return request.CreateResponse<string[]>(HttpStatusCode.OK, existingCultures);
            });
        }

        /// <summary>
        /// Get a list of all the resources for a specific culture
        /// </summary>
        /// <param name="request"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("cultureresources/{culture}")]
        public HttpResponseMessage CultureResources(HttpRequestMessage request, string culture)
        {
            return GetHttpResponse(request, () =>
            {
                ResourceMaster[] existingResources = _ResourceMasterService.GetAllMasterResources().Where(rm => rm.Culture == culture).ToArray();

                return request.CreateResponse<ResourceMaster[]>(HttpStatusCode.OK, existingResources);
            });
        }

        /// <summary>
        /// Update a Resource with a new description
        /// </summary>
        /// <param name="request"></param>
        /// <param name="resourceMasterModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateresource")]
        public HttpResponseMessage UpdateResource(HttpRequestMessage request, [FromBody]ResourceMasterModel resourceMasterModel)
        {
            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                //ResourceMaster existingResourceMaster = _ResourceMasterService.GetAllMasterResources().Where(rm => rm.ResourceId == resourceMasterModel.ResourceId).FirstOrDefault();
                ResourceMaster existingResourceMaster = _ResourceMasterService.GetAllMasterResources().FirstOrDefault(rm => rm.ResourceId == resourceMasterModel.ResourceId);

                if (existingResourceMaster != null)
                {
                    existingResourceMaster.Value = resourceMasterModel.Value;

                    ResourceMaster resourceMaster = _ResourceMasterService.UpdateMasterResource(existingResourceMaster);

                    response = request.CreateResponse<ResourceMaster>(HttpStatusCode.OK, resourceMaster);
                }

                return response;
            });
        }


        
    }
}
