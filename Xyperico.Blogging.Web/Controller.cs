using Xyperico.Authentication.Contract;


namespace Xyperico.Blogging.Web
{
  public class Controller : Xyperico.Web.Mvc.Controller
  {
    #region Dependencies

    public IBlogRepository BlogRepository { get; set; }
    public IBlogPostRepository BlogPostRepository { get; set; }
    public ICurrentUserService CurrentUserService { get; set; }

    #endregion
  }
}