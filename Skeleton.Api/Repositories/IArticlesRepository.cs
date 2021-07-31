using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Skeleton.Api.Entities;

namespace Skeleton.Api.Repositories
{

  public interface IArticlesRepository
  {
    Task<Article> GetArticleAsync(Guid id);
    Task<IEnumerable<Article>> GetArticlesAsync();
    Task CreateArticleAsync(Article article);
    Task UpdateArticleAsync(Article article);
    Task DeleteArticleAsync(Guid id);
  }
}