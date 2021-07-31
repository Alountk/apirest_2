using Skeleton.Api.DTOs;
using Skeleton.Api.Entities;

namespace Skeleton.Api
{
  public static class Extensions
  {
    public static ItemDTO AsDto(this Item item)
    {
      return new ItemDTO(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
    }
    public static ArticleDTO AsDto(this Article article)
    {
      return new ArticleDTO(article.Id, article.Title, article.BodyText, article.CreatedDate);
    }
  }
}