﻿using Fritz.WebFormsTest.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xunit;
using Xunit.Abstractions;

namespace Fritz.WebFormsTest.Test
{

  public class PrecompilerFixture : IDisposable
  {

    public PrecompilerFixture()
    {

      Uri codeBase = new Uri(GetType().Assembly.CodeBase);
      var currentFolder = new DirectoryInfo(Path.GetDirectoryName(codeBase.LocalPath));
      var webFolder = currentFolder.Parent.Parent.Parent.GetDirectories("WebFormsTest.Web")[0];

      WebApplicationProxy.Create(webFolder.FullName, true);
      WebApplicationProxy.Initialize();

    }

    public void Dispose()
    {
      WebApplicationProxy.DisposeIt();
    }

  }

  [CollectionDefinition("Precompiler collection")]
  public class PrecompiledWebCollection : ICollectionFixture<PrecompilerFixture>
  {
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
  }


}