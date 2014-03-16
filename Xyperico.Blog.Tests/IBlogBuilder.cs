using System;
using Xyperico.Base.Testing;


namespace Xyperico.Blog.Tests
{
  public interface IBlogBuilder : IDisposingBuilder<Blog>
  {
    Blog BuildBlog(Guid ownerId, string key=null, string title=null, string description=null);
  }
}
