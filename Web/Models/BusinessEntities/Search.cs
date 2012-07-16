using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.BusinessEntities
{
    public class Search
    {
        public Search()
        {
            Page = 1;
            PageSize = 10;
        }

        public string Text { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<ListItem> Items { get; set; }
    }
}