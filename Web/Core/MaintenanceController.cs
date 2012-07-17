using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace Web.Core
{
    public abstract class MaintenanceController<TModel> : Controller where TModel : class
    {
        public ActionResult Index()
        {
            return PartialOrFullView(null, "_Index");
        }

        public JsonResult IndexJson(DataSourceRequest request)
        {
            var result = GetList(request.Page, request.PageSize);
            return Json(new { Data = result.Items, result.Total }, JsonRequestBehavior.AllowGet);
        }

        protected abstract ListResult GetList(int page, int pageSize);

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