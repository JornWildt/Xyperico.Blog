using CuttingEdge.Conditions;
using System;
using Xyperico.Base;


namespace Xyperico.Blogging
{
  public class BlogPostView : IHaveId<Guid>
  {
    #region Persisted properties

    public Guid Id { get; protected set; }

    public string Slug { get; protected set; }

    public string Title { get; protected set; }

    public string Body { get; protected set; }

    public DateTime PublishDate { get; protected set; }

    #endregion

    
    public BlogPostView(Guid id, string slug, string title, string body, DateTime publishDate)
    {
      Condition.Requires(slug, "slug").IsNotNullOrEmpty();
      Condition.Requires(title, "title").IsNotNullOrEmpty();
      Condition.Requires(body, "body").IsNotNull();

      Id = id;
      Slug = slug;
      Title = title;
      Body = body;
      PublishDate = publishDate;
    }
  }
}
