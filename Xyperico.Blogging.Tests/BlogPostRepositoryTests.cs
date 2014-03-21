using NUnit.Framework;
using System;
using Xyperico.Base.Exceptions;
using Xyperico.Blogging.MongoDB;


namespace Xyperico.Blogging.Tests
{
  [TestFixture]
  public class BlogPostRepositoryTests : TestHelper
  {
    Guid BlogId1 = Guid.NewGuid();
    Guid BlogId2 = Guid.NewGuid();

    IBlogPostRepository BlogPostRepository = new BlogPostRepository();


    [Test]
    public void CanAddAndGetBlogPost()
    {
      BlogPost b1 = null;

      try
      {
        // Arrange
        b1 = new BlogPost(BlogId1, "rest-assured", "REST assured", "Blah");

        // Act
        BlogPostRepository.Add(b1);
        BlogPost b2 = BlogPostRepository.Get(b1.Id);

        // Assert
        Assert.IsNotNull(b2);
        Assert.AreEqual(b1.Id, b2.Id);
        Assert.AreNotEqual(b1.Id, Guid.Empty, "Persistence layer must assign IDs");
        Assert.AreEqual(b1.BlogId, b2.BlogId);
        Assert.AreEqual(b1.Slug, b2.Slug);
        Assert.AreEqual(b1.Title, b2.Title);
        Assert.AreEqual(b1.Body, b2.Body);
        Assert.AreEqual(b1.PublishDate.ToLongDateString(), b2.PublishDate.ToLongDateString());
      }
      finally
      {
        BlogPostRepository.Remove(b1.Id);
      }
    }


    [Test]
    public void WhenAddingSameBlogPostSlugTwiceItThrowsDuplicateKey()
    {
      // Arrange
      BlogPost p1 = BlogPostBuilder.BuildPost(BlogId1, "MYslug", "My title", "Blah blah ...");
      BlogPost p2 = new BlogPost(BlogId1, "myslug", "My title", "My body");
      BlogPost p3 = new BlogPost(BlogId1, "MYSLUG", "My title", "My body");

      BlogPostBuilder.RegisterInstance(p2);
      BlogPostBuilder.RegisterInstance(p3);

      // Act + Assert
      AssertThrows<DuplicateKeyException>(
        () => BlogPostRepository.Add(p2),
        ex => ex.Key == "Slug");
      AssertThrows<DuplicateKeyException>(
        () => BlogPostRepository.Add(p3),
        ex => ex.Key == "Slug");
    }


    [Test]
    public void CanAddBlogPostWithSameSlugForDifferentBlogs()
    {
      // Arrange
      BlogPost p1 = BlogPostBuilder.BuildPost(BlogId1, "MYslug", "My title", "Blah blah ...");
      BlogPost p2 = new BlogPost(BlogId2, "myslug", "My title", "My body");

      BlogPostBuilder.RegisterInstance(p2);

      // Act + Assert
      BlogPostRepository.Add(p2);
    }


    [Test]
    public void CanUpdateBlogPost()
    {
      // Arrange
      BlogPost p1 = BlogPostBuilder.BuildPost(BlogId1, "some-slug", "My title", "Blah blah ...");

      // Act
      p1.Update("slug-2", "New title", "New body");
      BlogPostRepository.Update(p1);

      BlogPost p2 = BlogPostRepository.Get(p1.Id);

      // Assert
      Assert.AreEqual("slug-2", p2.Slug);
      Assert.AreEqual("New title", p2.Title);
      Assert.AreEqual("New body", p2.Body);
    }


    [Test]
    public void CanDeleteBlogPost()
    {
      // Arrange
      BlogPost p1 = BlogPostBuilder.BuildPost(BlogId1, "some-slug", "My title", "Blah blah ...");

      // Act
      BlogPostRepository.Remove(p1.Id);

      AssertThrows<MissingResourceException>(() => BlogPostRepository.Get(p1.Id));
    }
  }
}
