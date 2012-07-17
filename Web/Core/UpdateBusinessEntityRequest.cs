using System.Linq;
using Web.Data;

namespace Web.Core
{
    public class UpdateBusinessEntityRequest : IRequest<UpdateBusinessEntityResponse>
    {
        public BusinessEntity Entity { get; set; }

        UpdateBusinessEntityResponse IRequest<UpdateBusinessEntityResponse>.Execute()
        {
            var original = Context.Entities.Single(e => e.Id == Entity.Id);
            original.Name = Entity.Name;
            original.ShortDescription = Entity.ShortDescription;
            original.LongDescription = Entity.LongDescription;
            return new UpdateBusinessEntityResponse();
        }
    }
}