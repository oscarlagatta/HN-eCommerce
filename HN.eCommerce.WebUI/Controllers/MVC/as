using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HN.eCommerce.WebUI.Core;
using System.ComponentModel.Composition;
using HN.eCommerce.Client.Contracts;

namespace HN.eCommerce.WebUI.Controllers.MVC
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Web.Mvc.RoutePrefix("style")]
    public class StyleController : ViewControllerBase
    {
        [ImportingConstructor]
        public StyleController(IStyleService styleService)
        {
            _styleService = styleService;
        }

        IStyleService _styleService;

        // GET: Style
        public ActionResult Index()
        {
            try
            {
                var resourcesMasters = _styleService.GetAllStyles().ToArray();

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}