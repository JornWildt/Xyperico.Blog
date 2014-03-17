using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Options;
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
        cm.MapField(p => p.PublishDate).SetSerializationOptions(new DateTimeSerializationOptions(System.DateTimeKind.Local));
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
