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


    public IList<AdminBlogListDTO> FindBlogsByOwnerForAdmin(Guid ownerId)
    {
      var restriction = Query<AdminBlogListDTO>.EQ(b => b.OwnerId, ownerId);
      var sort = SortBy<AdminBlogListDTO>.Ascending(b => b.Title);
      var fields = Fields<AdminBlogListDTO>.Include(b => b.Id, b => b.Key, b => b.Title, b => b.Description, b => b.OwnerId);
      var query = MDb.GetCollection<AdminBlogListDTO>(CollectionName)
        .Find(restriction).SetSortOrder(sort)
        .SetFields(fields);
      return query.ToList();
    }
  }
}
