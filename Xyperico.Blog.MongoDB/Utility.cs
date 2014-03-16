using MongoDB.Bson.Serialization;
using Xyperico.Base;


namespace Xyperico.Blog.MongoDB
{
  public static class Utility
  {
    public static void Initialize(IObjectContainer container)
    {
      Xyperico.Base.MongoDB.Utility.Initialize();

      BsonClassMap.RegisterClassMap<Blog>(cm =>
      {
        cm.AutoMap();
      });

      BsonClassMap.RegisterClassMap<BlogPost>(cm =>
      {
        cm.AutoMap();
      });

      ConfigureDependencies(container);
    }


    private static void ConfigureDependencies(IObjectContainer container)
    {
      container.AddComponent<IBlogRepository, BlogRepository>();
      container.AddComponent<IBlogPostRepository, BlogPostRepository>();
    }
  }
}
