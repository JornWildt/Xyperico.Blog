using NUnit.Framework;
using Xyperico.Base;
using Xyperico.Base.Collections;


namespace Xyperico.Blogging.Tests
{
  [SetUpFixture]
  public class SetupFixture
  {
    public static void Setup(IObjectContainer container)
    {
      Xyperico.Blogging.MongoDB.Utility.Initialize(container);

      container.AddComponent<INameValueContextCollection, CallContextNamedValueCollection>();
      container.AddComponent<IBlogBuilder, BlogBuilder>();
      container.AddComponent<IBlogPostBuilder, BlogPostBuilder>();
    }


    [SetUp]
    public void TestSetup()
    {
      Xyperico.Base.Testing.TestHelper.ClearObjectContainer();
      Setup(Xyperico.Base.Testing.TestHelper.ObjectContainer);
    }
  }
}
