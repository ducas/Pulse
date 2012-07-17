using System.Collections.Generic;
using Web.Data;

namespace Web.Core
{
    public class GetBusinessEntityListResponse
    {
        public IEnumerable<BusinessEntity> Result { get; set; }
    }
}