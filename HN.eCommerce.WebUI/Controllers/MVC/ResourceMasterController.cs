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
    [System.Web.Mvc.RoutePrefix("resourcemaster")]
    public class ResourceMasterController : ViewControllerBase
    {
        [ImportingConstructor]
        public ResourceMasterController(IResourceMasterService resourceMasterService)
        {
            _ResourceMasterService = resourceMasterService;
        }

        IResourceMasterService _ResourceMasterService;

        [System.Web.Mvc.HttpGet]
        public ActionResult Index()
        {
            try
            {
                string[] resourcesMasters = _ResourceMasterService.GetAvailableMasterResources();

                var resourceMasterModel = resourcesMasters.Select(name => new ResourceMasterModel()
                {
                    Name = name
                });
                return View(resourceMasterModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Create()
        {
            return View(new ResourceMasterModel());
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ActionName("Create")]
        public ActionResult CreateResourceMaster(string Name)
        {
            try
            {
                var resourceMasterCultures =
                    _ResourceMasterService.GetAllMasterResources().Select(rm => rm.Culture).Distinct();

                foreach (var resourceMasterCulture in resourceMasterCultures)
                {
                    _ResourceMasterService.UpdateMasterResource(new ResourceMaster
                    {
                        Name = Name,
                        Culture = resourceMasterCulture
                    });
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(string Name)
        {
            try
            {
                var resourceMasterName =
                    _ResourceMasterService.GetAllMasterResources().Where(rm => rm.Name == Name).Select(rm => rm.Name).FirstOrDefault();

                return View(new ResourceMasterModel
                {
                    Name = resourceMasterName
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ActionName("Edit")]
        public ActionResult EditResourceMaster(string Name, [FromBody]ResourceMasterModel resourceMasterModel, FormCollection formCollection)
        {
            try
            {
                string resourceMasterEdit = formCollection["NameHidden"];

                var resourceMasterCultures =
                    _ResourceMasterService.GetAllMasterResources().Where(rm => rm.Name == resourceMasterEdit);

                foreach (var resourceMasterCulture in resourceMasterCultures)
                {
                   // _ResourceMasterService.UpdateMasterResource(resourceMasterCulture);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("editcultures")]
        public ActionResult EditCultures()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("cultureresources")]
        public ActionResult CultureResources(string culture)
        {
            return View();
        }
    }
}