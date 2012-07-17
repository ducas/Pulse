using System.Collections.Generic;

namespace Web.Core
{
    public class ListResult
    {
        public IEnumerable<object> Items { get; set; }
        public int Total { get; set; }
    }
}