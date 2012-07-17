using System.Linq;
using Web.Core;

namespace Web.Controllers
{
    public class DeleteBusinessEntityRequest : IRequest<DeleteBusinessEntityResponse>
    {
        public int Id { get; set; }

        DeleteBusinessEntityResponse IRequest<DeleteBusinessEntityResponse>.Execute()
        {
            Context.Entities.Remove(Context.Entities.Single(e => e.Id == Id));
            return new DeleteBusinessEntityResponse();
        }
    }
}