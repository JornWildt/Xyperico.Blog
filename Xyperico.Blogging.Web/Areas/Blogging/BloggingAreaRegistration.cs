using log4net;
using System.Web.Mvc;
using Xyperico.Base;

namespace Xyperico.Blogging.Web.Areas.Blogging
{
  public class BlogAreaRegistration : AreaRegistration
  {
    ILog Logger = LogManager.GetLogger(typeof(BlogAreaRegistration));

    
    public override string AreaName
    {
      get
      {
        return "Blogging";
      }
    }

    
    public override void RegisterArea(AreaRegistrationContext context)
    {
      Logger.Debug("Register Blogging area");

      context.MapRoute(
          "Blogging_default",
          "app/blog/{controller}/{action}/{id}",
          new { controller = "home", action = "show", id = "" }
      );

      ConfigureDependencies(ObjectContainer.Container);
    }


    private void ConfigureDependencies(IObjectContainer container)
    {
      Xyperico.Blogging.MongoDB.Utility.Initialize(container);
      //container.AddComponent<IUserNameValidator, FilebasedUserNameValidator>();
    }
  }
}
