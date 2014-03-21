using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Collections.Generic;


namespace Xyperico.Blogging.MongoDB
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


    public IList<BlogPost> FindPostsByBlogForEdit(Guid blogId)
    {
      var query = from p in Collection.AsQueryable<BlogPost>()
                  where p.BlogId == blogId
                  select p;
      return query.ToList();
    }
  }
}
