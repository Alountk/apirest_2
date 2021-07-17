using System.ComponentModel.DataAnnotations;

namespace Skeleton.Api.DTOs
{
    public class UpdateItemDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }
    }
}