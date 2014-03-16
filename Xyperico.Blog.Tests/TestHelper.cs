namespace Xyperico.Blog.Tests
{
  public class TestHelper : Xyperico.Base.Testing.TestHelper
  {
    protected IBlogBuilder BlogBuilder = ObjectContainer.Resolve<IBlogBuilder>();


    protected override void TearDown()
    {
      base.TestFixtureTearDown();
      BlogBuilder.DisposeInstances();
    }
  }
}
