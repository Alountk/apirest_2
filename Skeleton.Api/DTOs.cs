using System;
using System.ComponentModel.DataAnnotations;

namespace Skeleton.Api.DTOs
{
  public record ItemDTO(Guid Id, string Name, string Description, decimal Price, DateTimeOffset CreatedDate);
  public record CreateItemDTO([Required][MaxLength(50)] string Name, [MaxLength(300)] string Description, [Range(1, 1000)] decimal Price);
  public record UpdateItemDTO([Required][MaxLength(50)] string Name, [MaxLength(300)] string Description, [Range(1, 1000)] decimal Price);
  public record ArticleDTO(Guid Id, string Title, string BodyText, DateTimeOffset CreatedDate);
  public record CreateArticleDTO([Required][MaxLength(50)] string Title, [MaxLength(1000)] string BodyText);
  public record UpdateArticleDTO([Required][MaxLength(50)] string Title, [MaxLength(1000)] string BodyText);
}