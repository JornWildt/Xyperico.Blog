using System;
using System.Collections.Generic;


namespace Xyperico.Blogging
{
  public interface IBlogPostRepository
  {
    void Add(BlogPost post);
    BlogPost Get(Guid id);
    IList<BlogPost> FindPostsByBlogForEdit(Guid blogId);
    void Update(BlogPost post);
    void Remove(Guid id);
  }
}
