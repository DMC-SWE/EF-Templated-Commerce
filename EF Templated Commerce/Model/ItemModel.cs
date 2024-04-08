using System.ComponentModel.DataAnnotations;

namespace EF_Templated_Commerce.Model
{
    public class ItemModel
    {
        public int Id { get; set; }

        [Required()]
        public string? Name { get; set; }

        [Required()]
        public string? Description { get; set; }

        [Required()]
        [Range(1, 1000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public float Price { get; set; }

    }
}
