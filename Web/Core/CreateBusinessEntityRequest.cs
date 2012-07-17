using System.Linq;
using Web.Data;

namespace Web.Core
{
    public class CreateBusinessEntityRequest : IRequest<CreateBusinessEntityResponse>
    {
        public BusinessEntity Entity { get; set; }

        CreateBusinessEntityResponse IRequest<CreateBusinessEntityResponse>.Execute()
        {
            Entity.Id = Context.Entities.Max(e => e.Id) + 1;
            Context.Entities.Add(Entity);
            return new CreateBusinessEntityResponse();
        }
    }
}