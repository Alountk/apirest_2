using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class CreateItemDTO
    {
        [Required]
        [MaxLength(16)]
        public string Name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}