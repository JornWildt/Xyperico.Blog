using System;


namespace Xyperico.Blog
{
  public interface IBlogRepository
  {
    void Add(Blog blog);
    Blog Get(Guid id);
    void Update(Blog blog);
    void Remove(Guid id);
  }
}
