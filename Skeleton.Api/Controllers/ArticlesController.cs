using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skeleton.Api.DTOs;
using Skeleton.Api.Entities;
using Skeleton.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Skeleton.Api.Controllers
{
  [ApiController]
  // [Route("[controller]")]
  [Route("articles")]
  public class ArticlesController : ControllerBase
  {
    private readonly IArticlesRepository _repository;
    private readonly ILogger<ArticlesController> _logger;
    public ArticlesController(IArticlesRepository repository, ILogger<ArticlesController> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<ArticleDTO>> GetArticlesAsync(string title = null)
    {
      var articles = (await _repository.GetArticlesAsync())
                  .Select(article => article.AsDto());

      if (!string.IsNullOrWhiteSpace(title))
        articles = articles.Where(article => article.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

      _logger.LogInformation($"{DateTime.UtcNow.ToString("hh:mm:ss")}: Retrieve {articles.Count()} articles");

      return articles;
    }

    // GET /articles/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ArticleDTO>> GetArticleAsync(Guid id)
    {
      var article = await _repository.GetArticleAsync(id);

      if (article is null)
      {
        return NotFound();
      }

      return article.AsDto();
    }

    // POST /articles
    [HttpPost]
    public async Task<ActionResult<ArticleDTO>> CreateArticleAsync(CreateArticleDTO articleDTO)
    {
      Article article = new()
      {
        Id = Guid.NewGuid(),
        Title = articleDTO.Title,
        BodyText = articleDTO.BodyText,
        CreatedDate = DateTimeOffset.UtcNow
      };
      await _repository.CreateArticleAsync(article);
      return CreatedAtAction(nameof(GetArticleAsync), new { id = article.Id }, article.AsDto());
    }

    // PUT /articles/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateArticleAsync(Guid id, UpdateArticleDTO articleDTO)
    {
      var existingArticle = await _repository.GetArticleAsync(id);

      if (existingArticle is null)
      {
        return NotFound();
      }

      existingArticle.Title = articleDTO.Title;
      existingArticle.BodyText = articleDTO.BodyText;

      await _repository.UpdateArticleAsync(existingArticle);

      return NoContent();
    }

    // DELETE /articles/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteArticleAsync(Guid id)
    {
      var existingArticle = await _repository.GetArticleAsync(id);

      if (existingArticle is null)
      {
        return NotFound();
      }

      await _repository.DeleteArticleAsync(id);

      return NoContent();
    }
  }
}