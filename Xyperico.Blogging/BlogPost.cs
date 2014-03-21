using CuttingEdge.Conditions;
using System;
using Xyperico.Base;


namespace Xyperico.Blogging
{
  public class BlogPost : IHaveId<Guid>
  {
    #region Persisted properties

    public Guid BlogId { get; protected set; }

    public Guid Id { get; protected set; }

    public string Slug { get; protected set; }

    public string SlugLowerCase { get; protected set; }

    public string Title { get; protected set; }

    public string Body { get; protected set; }

    public DateTime PublishDate { get; protected set; }

    #endregion

    
    public BlogPost(Guid blogId, string slug, string title, string body)
    {
      Condition.Requires(slug, "slug").IsNotNullOrEmpty();
      Condition.Requires(title, "title").IsNotNullOrEmpty();
      Condition.Requires(body, "body").IsNotNull();

      BlogId = blogId;
      Slug = slug;
      SlugLowerCase = slug.ToLower();
      Title = title;
      Body = body;
      PublishDate = DateTime.Now;
    }


    public void Update(string slug, string title, string body)
    {
      Condition.Requires(slug, "slug").IsNotNullOrEmpty();
      Condition.Requires(title, "title").IsNotNullOrEmpty();
      Condition.Requires(body, "body").IsNotNull();

      Slug = slug;
      SlugLowerCase = slug.ToLower();
      Title = title;
      Body = body;
    }
  }
}
