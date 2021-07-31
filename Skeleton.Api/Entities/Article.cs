using System;

namespace Skeleton.Api.Entities
{
  public class Article
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string BodyText { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
  }
}