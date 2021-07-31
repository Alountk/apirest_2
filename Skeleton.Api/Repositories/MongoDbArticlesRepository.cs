using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skeleton.Api.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Skeleton.Api.Repositories
{
  public class MongoDbArticlesRepository : IArticlesRepository
  {
    private const string databaseName = "api";
    private const string collectionName = "articles";
    private readonly IMongoCollection<Article> articlesCollection;
    private readonly FilterDefinitionBuilder<Article> filterBuilder = Builders<Article>.Filter;
    public MongoDbArticlesRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(databaseName);
      articlesCollection = database.GetCollection<Article>(collectionName);
    }
    public async Task CreateArticleAsync(Article article)
    {
      await articlesCollection.InsertOneAsync(article);
    }

    public async Task DeleteArticleAsync(Guid id)
    {
      var filter = filterBuilder.Eq(deleteArticle => deleteArticle.Id, id);
      await articlesCollection.DeleteOneAsync(filter);

    }

    public async Task<Article> GetArticleAsync(Guid id)
    {
      var filter = filterBuilder.Eq(article => article.Id, id);
      return await articlesCollection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Article>> GetArticlesAsync()
    {
      return await articlesCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task UpdateArticleAsync(Article article)
    {
      var filter = filterBuilder.Eq(existingArticle => existingArticle.Id, article.Id);
      await articlesCollection.ReplaceOneAsync(filter, article);

    }
  }
}