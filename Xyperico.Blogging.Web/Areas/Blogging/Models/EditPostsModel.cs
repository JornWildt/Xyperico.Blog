using System.Collections.Generic;


namespace Xyperico.Blogging.Web.Areas.Blogging.Models
{
  public class EditPostsModel
  {
    public Blog Blog { get; set; }
    public IList<BlogPost> Posts { get; set; }
  }
}