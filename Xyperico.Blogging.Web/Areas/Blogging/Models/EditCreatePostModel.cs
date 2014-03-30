using System.ComponentModel.DataAnnotations;
using Xyperico.Base.DataAnnotations;


namespace Xyperico.Blogging.Web.Areas.Blogging.Models
{
  public class EditCreatePostModel
  {
    public Blog Blog { get; set; }

    [Required()]
    [StringLength(250)]
    [LocalizedDisplayName("Title", NameResourceType = typeof(_.Blogging))]
    public string Title { get; set; }

    [Required()]
    [StringLength(250)]
    [LocalizedDisplayName("Post_slug", NameResourceType = typeof(_.Blogging))]
    public string Slug { get; set; }

    [LocalizedDisplayName("Post_body", NameResourceType = typeof(_.Blogging))]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Body { get; set; }
  }
}