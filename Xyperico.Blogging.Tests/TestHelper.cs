namespace Xyperico.Blogging.Tests
{
  public class TestHelper : Xyperico.Base.Testing.TestHelper
  {
    protected IBlogBuilder BlogBuilder = ObjectContainer.Resolve<IBlogBuilder>();
    protected IBlogPostBuilder BlogPostBuilder = ObjectContainer.Resolve<IBlogPostBuilder>();


    protected override void TearDown()
    {
      base.TestFixtureTearDown();
      BlogBuilder.DisposeInstances();
      BlogPostBuilder.DisposeInstances();
    }
  }
}
