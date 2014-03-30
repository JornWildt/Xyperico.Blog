using System;
using System.Collections.Generic;


namespace Xyperico.Blogging
{
  public interface IBlogRepository
  {
    void Add(Blog blog);
    Blog Get(Guid id);
    IList<AdminBlogListDTO> FindBlogsByOwnerForAdmin(Guid ownerId);
    void Update(Blog blog);
    void Remove(Guid id);
  }
}
