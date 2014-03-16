using System;
using Xyperico.Base.Testing;


namespace Xyperico.Blog.Tests
{
  public class BlogBuilder : DisposingBuilder<Blog>, IBlogBuilder
  {
    #region Dependencies

    public IBlogRepository BlogRepository { get; set; }

    #endregion


    #region IBlogBuilder Members

    public Blog BuildBlog(Guid ownerId, string key=null, string title=null, string description=null)
    {
      Blog b = new Blog(key ?? "myblog", title ?? "My blog", description ?? "Blah ...", ownerId);
      RegisterInstance(b);
      BlogRepository.Add(b);
      return b;
    }

    #endregion


    protected override void DisposeInstance(Blog Blog)
    {
      BlogRepository.Remove(Blog.Id);
    }
  }
}
