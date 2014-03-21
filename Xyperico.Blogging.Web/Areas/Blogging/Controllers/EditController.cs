using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Xyperico.Authentication.Contract;
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

      IList<Blog> blogs = BlogRepository.FindBlogsByOwnerForEdit(CurrentUserService.UserId);
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


    #region Editing posts

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
  }
}
