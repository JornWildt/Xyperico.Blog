using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Linq;
using System.Collections.Generic;


namespace Xyperico.Blogging.MongoDB
{
  public class BlogRepository : GenericRepository<Blog, Guid>, IBlogRepository
  {
    public override void Setup()
    {
      base.Setup();
      Collection.EnsureIndex(
        new IndexKeysBuilder().Ascending("OwnerId", "KeyLowerCase"),
        IndexOptions.SetSparse(true).SetUnique(true));
    }


    protected override string MapDuplicateKeyErrorToKeyName(string error)
    {
      if (error.Contains("KeyLowerCase"))
        return "Key";
      else
        return null;
    }


    public IList<Blog> FindBlogsByOwnerForEdit(Guid ownerId)
    {
      var query = from b in Collection.AsQueryable<Blog>()
                  where b.OwnerId == ownerId
                  select b;
      return query.ToList();
    }
  }
}
