using MongoDB.Driver.Builders;
using System;


namespace Xyperico.Blog.MongoDB
{
  public class BlogPostRepository : GenericRepository<BlogPost, Guid>, IBlogPostRepository
  {
    public override void Setup()
    {
      base.Setup();
      Collection.EnsureIndex(
        new IndexKeysBuilder().Ascending("OwnerId", "Slug"),
        IndexOptions.SetSparse(true).SetUnique(true));
    }
  }
}
