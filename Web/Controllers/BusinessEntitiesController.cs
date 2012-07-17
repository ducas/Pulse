using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Kendo.Mvc.UI;
using Web.Core;
using Web.Data;
using Web.Models.BusinessEntities;

namespace Web.Controllers
{

    public class BusinessEntitiesController : MaintenanceController<Details>
    {
        static BusinessEntitiesController()
        {
            Mapper.CreateMap<BusinessEntity, ListItem>();
            Mapper.CreateMap<BusinessEntity, Details>();
            Mapper.CreateMap<Details, BusinessEntity>();
        }

        private readonly IQueryBroker broker = new QueryBroker();

        protected override IEnumerable<object> GetList(int page, int pageSize)
        {
            return broker
                .Execute<GetBusinessEntityListRequest, GetBusinessEntityListResponse>(new GetBusinessEntityListRequest { Page = page, PageSize = pageSize })
                .Result
                .Select(Mapper.Map<ListItem>);
        }

        protected override Details Get(int id)
        {
            return broker
                .Execute<GetBusinessEntityRequest, GetBusinessEntityResponse>(new GetBusinessEntityRequest { Id = id })
                .Result
                .Map<Details>();
        }

        protected override IEnumerable<KeyValuePair<string, string>> Update(Details model)
        {
            return broker
                .Execute<UpdateBusinessEntityRequest, UpdateBusinessEntityResponse>(new UpdateBusinessEntityRequest { Entity = model.Map<BusinessEntity>() })
                .Errors;
        }

        protected override IEnumerable<KeyValuePair<string, string>> CreateItem(Details model)
        {
            return broker
                .Execute<CreateBusinessEntityRequest, CreateBusinessEntityResponse>(new CreateBusinessEntityRequest { Entity = model.Map<BusinessEntity>() })
                .Errors;
        }
    }

    public abstract class MaintenanceController<TModel> : Controller where TModel : class
    {
        public ActionResult Index()
        {
            return PartialOrFullView(null, "_Index");
        }

        public JsonResult IndexJson(DataSourceRequest request)
        {
            var items = GetList(request.Page, request.PageSize);
            return Json(new { Data = items, Total = items.Count() }, JsonRequestBehavior.AllowGet);
        }

        protected abstract IEnumerable<object> GetList(int page, int pageSize);

        public ActionResult View(int id)
        {
            return PartialOrFullView(Get(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(Get(id));
        }

        [HttpPost]
        public ActionResult Edit(TModel model)
        {
            if (ModelState.IsValid)
            {
                var result = Update(model);
                if (result == null || !result.Any()) return JsonOrRedirect("Index");

                foreach (var e in result) ModelState.AddModelError(e.Key, e.Value);
            }
            return JsonErrorsOrView(model);
        }

        protected abstract IEnumerable<KeyValuePair<string, string>> Update(TModel model);

        protected abstract TModel Get(int id);

        [HttpGet]
        public ActionResult Create()
        {
            return PartialOrFullView(null);
        }

        [HttpPost]
        public ActionResult Create(TModel model)
        {
            if (ModelState.IsValid)
            {
                var result = CreateItem(model);
                if (result == null || !result.Any()) return JsonOrRedirect("Index");

                foreach (var e in result) ModelState.AddModelError(e.Key, e.Value);
            }
            return JsonErrorsOrView(model);
        }

        protected abstract IEnumerable<KeyValuePair<string, string>> CreateItem(TModel model);

        private ActionResult JsonOrRedirect(string action)
        {
            return Request.IsAjaxRequest() ? Json(new { success = true, redirect = Url.Action(action) }) : RedirectToAction(action) as ActionResult;
        }

        private ActionResult JsonErrorsOrView(object model)
        {
            return Request.IsAjaxRequest()
                ? Json(new
                {
                    success = false,
                    errors = ModelState.ToDictionary(k => k.Key, v => v.Value.Errors.Select(e => e.ErrorMessage))
                })
                : View(model) as ActionResult;
        }

        private ActionResult PartialOrFullView(object model, string partial = null)
        {
            return Request.IsAjaxRequest() ? PartialView(partial, model) : View(model) as ActionResult;
        }
    }
}