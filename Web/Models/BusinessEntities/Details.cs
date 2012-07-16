using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.BusinessEntities
{
    public class Details
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string ShortDescription { get; set; }
        [Required]
        [StringLength(200)]
        public string LongDescription { get; set; }
    }
}