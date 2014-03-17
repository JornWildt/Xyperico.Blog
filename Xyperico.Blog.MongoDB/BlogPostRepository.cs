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
        new IndexKeysBuilder().Ascending("BlogId", "SlugLowerCase"),
        IndexOptions.SetSparse(true).SetUnique(true));
    }


    protected override string MapDuplicateKeyErrorToKeyName(string error)
    {
      if (error.Contains("SlugLowerCase"))
        return "Slug";
      else
        return null;
    }
  }
}
