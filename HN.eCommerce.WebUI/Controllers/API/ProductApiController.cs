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
    
    //[Authorize]
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [RoutePrefix("api/product")]
    [UsesDisposableService]
    public class ProductApiController : ApiControllerBase
    {

         [ImportingConstructor]
        public ProductApiController(IProductService productService)
        {
            _ProductService = productService;
        }

        IProductService _ProductService;

        protected override void RegisterServices(List<IServiceContract> disposableServices)
        {
            disposableServices.Add(_ProductService);
        }

        [HttpPost]
        [Route("availableproducts")]
        public HttpResponseMessage GetAvailableProducts(HttpRequestMessage request, [FromBody]AccountRegisterModel accountModel)
        {
            return GetHttpResponse(request, () =>
            {
                Product[] products = _ProductService.GetAllProducts();

                return request.CreateResponse<Product[]>(HttpStatusCode.OK, products);
            });
        }
    }
}
