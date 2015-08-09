using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web.Http;
using System.Web.Mvc;
using HN.eCommerce.Client.Contracts;
using HN.eCommerce.Client.Entities;
using HN.eCommerce.WebUI.Core;
using HN.eCommerce.WebUI.Models;

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
            _StyleService = styleService;
        }

        IStyleService _StyleService;

        [System.Web.Mvc.HttpGet]
        public ActionResult Index()
        {
            try
            {
                Style[] styles = _StyleService.GetAllStyles();

                var styleModel = styles.Select(description => new StyleModel()
                {
                    MerretDescription = description.ToString()
                });
                return View(styleModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}