using MongoDB.Driver.Builders;
using System;


namespace Xyperico.Blog.MongoDB
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
  }
}
