using System;


namespace Xyperico.Blog
{
  public interface IBlogPostRepository
  {
    void Add(BlogPost post);
    BlogPost Get(Guid id);
    void Update(BlogPost post);
    void Remove(Guid id);
  }
}
