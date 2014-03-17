using NUnit.Framework;
using Xyperico.Base.Exceptions;
using System;


namespace Xyperico.Blog.Tests
{
  [TestFixture]
  public class BlogRepositoryTests : TestHelper
  {
    Guid OwnerId1 = Guid.NewGuid();
    Guid OwnerId2 = Guid.NewGuid();

    IBlogRepository BlogRepository = new Xyperico.Blog.MongoDB.BlogRepository();


    [Test]
    public void CanAddAndGetBlog()
    {
      Blog b1 = null;

      try
      {
        // Arrange
        b1 = new Blog("myblog", "My blog", "Blah ...", OwnerId1);

        // Act
        BlogRepository.Add(b1);
        Blog b2 = BlogRepository.Get(b1.Id);

        // Assert
        Assert.IsNotNull(b2);
        Assert.AreEqual(b1.Id, b2.Id);
        Assert.AreNotEqual(b1.Id, Guid.Empty, "Persistence layer must assign IDs");
        Assert.AreEqual(b1.Key, b2.Key);
        Assert.AreEqual(b1.Title, b2.Title);
        Assert.AreEqual(b1.Description, b2.Description);
        Assert.AreEqual(b1.OwnerId, b2.OwnerId);
      }
      finally
      {
        BlogRepository.Remove(b1.Id);
      }
    }


    [Test]
    public void WhenAddingSameBlogTwiceItThrowsDuplicateKey()
    {
      // Arrange
      Blog b1 = BlogBuilder.BuildBlog(OwnerId1, key:"MYbloop");
      Blog b2 = new Blog("mybloop", "My Bloop", "Blah", OwnerId1);
      Blog b3 = new Blog("MYBLOOP", "My Bloop", "Blah", OwnerId1);

      BlogBuilder.RegisterInstance(b2);
      BlogBuilder.RegisterInstance(b3);

      // Act + Assert
      AssertThrows<DuplicateKeyException>(
        () => BlogRepository.Add(b2),
        ex => ex.Key == "Key");
      AssertThrows<DuplicateKeyException>(
        () => BlogRepository.Add(b3),
        ex => ex.Key == "Key");
    }


    [Test]
    public void CanAddBlogWithSameKeyForDifferentOwners()
    {
      // Arrange
      Blog b1 = BlogBuilder.BuildBlog(OwnerId1, key: "MYblah");
      Blog b2 = new Blog("myblah", "My Bloop", "Blah", OwnerId2);

      BlogBuilder.RegisterInstance(b2);

      // Act + Assert
      BlogRepository.Add(b2);
    }


    [Test]
    public void CanUpdateBlog()
    {
      // Arrange
      Blog b1 = BlogBuilder.BuildBlog(OwnerId1, key:"KarriusBaktus");

      // Act
      b1.Update("Karmikarius", "Karma Karius", "Blahhhhh");
      BlogRepository.Update(b1);

      Blog b2 = BlogRepository.Get(b1.Id);

      // Assert
      Assert.AreEqual("Karmikarius", b2.Key);
      Assert.AreEqual("Karma Karius", b2.Title);
      Assert.AreEqual("Blahhhhh", b2.Description);
    }


    [Test]
    public void CanDeleteBlog()
    {
      // Arrange
      Blog b1 = BlogBuilder.BuildBlog(OwnerId1, key: "KarriusBaktus");

      // Act
      BlogRepository.Remove(b1.Id);

      AssertThrows<MissingResourceException>(() => BlogRepository.Get(b1.Id));
    }
  }
}
