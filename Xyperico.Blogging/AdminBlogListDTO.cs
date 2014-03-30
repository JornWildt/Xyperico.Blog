using System;


namespace Xyperico.Blogging
{
  public class AdminBlogListDTO
  {
    #region Persisted properties

    public Guid Id { get; set; }

    public string Key { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int PostCount { get; set; }

    public Guid OwnerId { get; set; }

    #endregion


    public AdminBlogListDTO()
    {
    }
  }
}
