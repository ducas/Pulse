using System.ComponentModel.DataAnnotations;

namespace Web.Data
{
    public class BusinessEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(100)]
        public string ShortDescription { get; set; }
        [StringLength(200)]
        public string LongDescription { get; set; }
    }
}
