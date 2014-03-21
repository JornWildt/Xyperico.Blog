using System;
using Xyperico.Base.Testing;


namespace Xyperico.Blogging.Tests
{
  public class BlogPostBuilder : DisposingBuilder<BlogPost>, IBlogPostBuilder
  {
    #region Dependencies

    public IBlogPostRepository BlogPostRepository { get; set; }

    #endregion


    #region IBlogPostBuilder Members

    public BlogPost BuildPost(Guid blogId, string slug = null, string title = null, string body = null)
    {
      BlogPost b = new BlogPost(blogId, slug ?? "jura", title ?? "Jurassic Park", body ?? "Blah blah");
      RegisterInstance(b);
      BlogPostRepository.Add(b);
      return b;
    }

    #endregion


    protected override void DisposeInstance(BlogPost BlogPost)
    {
      BlogPostRepository.Remove(BlogPost.Id);
    }
  }
}
