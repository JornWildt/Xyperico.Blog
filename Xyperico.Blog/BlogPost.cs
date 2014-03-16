using System;
using Xyperico.Base;


namespace Xyperico.Blog
{
  public class BlogPost : IHaveId<Guid>
  {
    #region Persisted properties

    public Guid Id { get; protected set; }

    public string Slug { get; protected set; }

    public string Title { get; protected set; }

    public string Body { get; protected set; }

    public DateTime Published { get; protected set; }

    public Guid OwnerId { get; protected set; }

    #endregion

    
    public BlogPost()
    {
    }
  }
}
