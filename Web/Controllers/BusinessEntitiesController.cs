using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Web.Data;
using Web.Models.BusinessEntities;

namespace Web.Controllers
{
    public class BusinessEntitiesController : Controller
    {
        private const string successCookieName = "business-entity-success";

        private static readonly List<BusinessEntity> entities = new List<BusinessEntity>
            {
                new BusinessEntity{Id = 1, Name = "Test", ShortDescription = "Short", LongDescription = "Long" }
            };

        public ActionResult Index(Search model)
        {
            var query = entities.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(model.Text))
            {
                query = entities.Where(
                    e =>
                    e.Name.Contains(model.Text) || e.ShortDescription.Contains(model.Text) ||
                    e.LongDescription.Contains(model.Text)
                    );
            }

            model.Items = query.Skip((model.Page - 1) * model.PageSize)
                .Take(model.PageSize)
                .Select(e => new ListItem
                    {
                        Id = e.Id,
                        Name = e.Name,
                        ShortDescription = e.ShortDescription,
                        LongDescription = e.LongDescription
                    });

            return PartialOrFullView(model, "_Index");
        }

        public ActionResult IndexJson(DataSourceRequest request)
        {
            return Json(new { Data = entities, Total = entities.Count }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult View(int id)
        {
            var model = entities.Single(e => e.Id == id);
            var details = new Details { Id = id, Name = model.Name, ShortDescription = model.ShortDescription, LongDescription = model.LongDescription };
            return PartialOrFullView(details);
        }

        public ActionResult Edit(int id)
        {
            var model = entities.Single(e => e.Id == id);
            return View(new Details
            {
                Id = id,
                Name = model.Name,
                ShortDescription = model.ShortDescription,
                LongDescription = model.LongDescription
            });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialOrFullView(null);
        }

        [HttpPost]
        public ActionResult Create(Details model)
        {
            if (!ModelState.IsValid) return JsonErrorsOrView(model);

            //TODO: SAVE!
            entities.Add(new BusinessEntity
                {
                    Id = entities.Max(e => e.Id) + 1,
                    Name = model.Name,
                    ShortDescription = model.ShortDescription,
                    LongDescription = model.LongDescription
                });

            Response.AppendCookie(new HttpCookie(successCookieName, "Created"));

            return JsonOrRedirect("Index");
        }

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