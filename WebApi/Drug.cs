using System.ComponentModel.DataAnnotations;
using WebApi.Attributes;

namespace WebApi
{
    public class Drug
    {
        [MaxLength(30)]
        public string Code { get; set; }

        [MaxLength(100)]
        public string Label { get; set; }

        public string Description { get; set; }

        [Required]
        [GreaterThenZero]
        public decimal Price { get; set; }
    }
}
