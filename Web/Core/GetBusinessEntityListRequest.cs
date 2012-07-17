using System.Linq;

namespace Web.Core
{
    public class GetBusinessEntityListRequest : IRequest<GetBusinessEntityListResponse>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        GetBusinessEntityListResponse IRequest<GetBusinessEntityListResponse>.Execute()
        {
            return new GetBusinessEntityListResponse
                {
                    Result = Context.Entities
                        .Skip((Page - 1) * PageSize)
                        .Take(PageSize)
                };
        }
    }
}