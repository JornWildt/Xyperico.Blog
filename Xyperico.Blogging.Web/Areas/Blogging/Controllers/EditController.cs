using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Xyperico.Base.Exceptions;
using Xyperico.Blogging.Web.Areas.Blogging.Models;


namespace Xyperico.Blogging.Web.Areas.Blogging.Controllers
{
  public class EditController : Controller
  {
    #region Editing blogs

    [HttpGet]
    public ActionResult blogs()
    {
      if (!User.Identity.IsAuthenticated)
      {
        throw new MissingResourceException("No blogs for anonymous user.");
      }

      IList<AdminBlogListDTO> blogs = BlogRepository.FindBlogsByOwnerForAdmin(CurrentUserService.UserId);
      EditBlogsModel model = new EditBlogsModel
      {
        Blogs = blogs
      };
      return View(model);
    }


    [HttpGet]
    public ActionResult createblog()
    {
      return View(new EditCreateBlogModel());
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult createblog(EditCreateBlogModel model)
    {
      if (ModelState.IsValid)
      {
        Blog b = new Blog(model.Key, model.Title, model.Description, CurrentUserService.UserId);
        BlogRepository.Add(b);
        return RedirectToAction("posts", "edit", new { id = b.Id });
      }
      return View(model);
    }

    #endregion


    #region List posts

    [HttpGet]
    public ActionResult posts(Guid id)
    {
      if (!User.Identity.IsAuthenticated)
      {
        throw new MissingResourceException("No blogs for anonymous user.");
      }

      Blog blog = BlogRepository.Get(id);
      IList<BlogPost> posts = BlogPostRepository.FindPostsByBlogForEdit(id);

      EditPostsModel model = new EditPostsModel
      {
        Blog = blog,
        Posts = posts
      };
      return View(model);
    }

    #endregion


    #region Create post

    [HttpGet]
    public ActionResult createpost(Guid id)
    {
      Blog b = BlogRepository.Get(id);
      return View(new EditCreatePostModel { Blog = b });
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult createpost(Guid id, EditCreatePostModel model)
    {
      if (ModelState.IsValid)
      {
        BlogPost p = new BlogPost(id, model.Slug, model.Title, model.Body);
        BlogPostRepository.Add(p);
        return RedirectToAction("posts", "edit", new { id = id });
      }
      return View(model);
    }

    #endregion


    #region Edit post

    [HttpGet]
    public ActionResult editpost(Guid id)
    {
      BlogPost p = BlogPostRepository.Get(id);
      Blog b = BlogRepository.Get(p.BlogId);
      EditEditPostModel model = new EditEditPostModel
      {
        Blog = b,
        Title = p.Title,
        Slug = p.Slug,
        Body = p.Body
      };
      return View(model);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult editpost(Guid id, EditEditPostModel model)
    {
      if (ModelState.IsValid)
      {
        BlogPost p = BlogPostRepository.Get(id);
        p.Update(model.Slug, model.Title, model.Body);
        BlogPostRepository.Update(p);
        return RedirectToAction("posts", "edit", new { id = p.BlogId });
      }
      return View(model);
    }

    #endregion
  }
}
