using NUnit.Framework;
using Xyperico.Base;
using Xyperico.Base.Collections;


namespace Xyperico.Blog.Tests
{
  [SetUpFixture]
  public class SetupFixture
  {
    public static void Setup(IObjectContainer container)
    {
      Xyperico.Blog.MongoDB.Utility.Initialize(container);

      container.AddComponent<INameValueContextCollection, CallContextNamedValueCollection>();
      container.AddComponent<IBlogBuilder, BlogBuilder>();
    }


    [SetUp]
    public void TestSetup()
    {
      Xyperico.Base.Testing.TestHelper.ClearObjectContainer();
      Setup(Xyperico.Base.Testing.TestHelper.ObjectContainer);
    }
  }
}
