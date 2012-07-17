using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        protected override ListResult GetList(int page, int pageSize)
        {
            var result = broker
                .Execute<GetBusinessEntityListRequest, GetBusinessEntityListResponse>(new GetBusinessEntityListRequest { Page = page, PageSize = pageSize });
            return new ListResult
                {
                    Total = result.TotalItems,
                    Items = result.Result
                };
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
}