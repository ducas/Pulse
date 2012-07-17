using System.Linq;

namespace Web.Core
{
    public class GetBusinessEntityRequest : IRequest<GetBusinessEntityResponse>
    {
        public int Id { get; set; }

        GetBusinessEntityResponse IRequest<GetBusinessEntityResponse>.Execute()
        {
            return new GetBusinessEntityResponse { Result = Context.Entities.Single(e => e.Id == Id) };
        }
    }
}