using CuttingEdge.Conditions;
using System;
using Xyperico.Base;


namespace Xyperico.Blogging
{
  public class Blog : IHaveId<Guid>
  {
    #region Persisted properties

    public Guid Id { get; protected set; }

    public string Key { get; protected set; }

    public string KeyLowerCase { get; protected set; }

    public string Title { get; protected set; }

    public string Description { get; protected set; }

    public Guid OwnerId { get; protected set; }

    #endregion


    public Blog()
    {
    }


    public Blog(string key, string title, string description, Guid ownerId)
    {
      Condition.Requires(key, "key").IsNotNullOrEmpty();
      Condition.Requires(title, "title").IsNotNullOrEmpty();
      Condition.Requires(description, "description").IsNotNull();

      Key = key;
      KeyLowerCase = key.ToLower();
      Title = title;
      Description = description;
      OwnerId = ownerId;
    }


    public void Update(string key, string title, string description)
    {
      Condition.Requires(key, "key").IsNotNullOrEmpty();
      Condition.Requires(title, "title").IsNotNullOrEmpty();
      Condition.Requires(description, "description").IsNotNull();

      Key = key;
      KeyLowerCase = key.ToLower();
      Title = title;
      Description = description;
    }
  }
}
