using System;
using System.ComponentModel.DataAnnotations;

namespace Skeleton.Api.DTOs
{
    public record ItemDTO(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
    public record CreateItemDTO([Required][MaxLength(50)] string Name, [MaxLength(300)] string Description, [Range(1, 1000)] decimal Price);
    public record UpdateItemDTO([Required][MaxLength(50)] string Name, [MaxLength(300)] string Description, [Range(1, 1000)] decimal Price);
}