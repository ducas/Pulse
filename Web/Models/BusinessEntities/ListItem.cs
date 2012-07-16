using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.BusinessEntities
{
    public class ListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}