﻿using System;
using Xyperico.Base.Testing;


namespace Xyperico.Blogging.Tests
{
  public interface IBlogPostBuilder : IDisposingBuilder<BlogPost>
  {
    BlogPost BuildPost(Guid blogId, string slug=null, string title=null, string body=null);
  }
}
