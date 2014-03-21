using System.ComponentModel.DataAnnotations;
using Xyperico.Base.DataAnnotations;


namespace Xyperico.Blogging.Web.Areas.Blogging.Models
{
  public class EditCreateBlogModel
  {
    [Required()]
    [StringLength(250)]
    [LocalizedDisplayName("Title", NameResourceType = typeof(_.Blogging))]
    public string Title { get; set; }

    [Required()]
    [StringLength(250)]
    [LocalizedDisplayName("Blog_key", NameResourceType = typeof(_.Blogging))]
    public string Key { get; set; }

    [StringLength(1000)]
    [LocalizedDisplayName("Description", NameResourceType = typeof(_.Blogging))]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    public string Description { get; set; }
  }
}