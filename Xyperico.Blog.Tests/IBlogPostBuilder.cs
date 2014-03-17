using System;
using Xyperico.Base.Testing;


namespace Xyperico.Blog.Tests
{
  public interface IBlogPostBuilder : IDisposingBuilder<BlogPost>
  {
    BlogPost BuildPost(Guid blogId, string slug=null, string title=null, string body=null);
  }
}
