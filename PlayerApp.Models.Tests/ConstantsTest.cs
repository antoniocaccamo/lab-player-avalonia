using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayerApp.Models;

namespace PlayerApp.Models.Tests;

[TestClass]
[TestSubject(typeof(Constants))]
public class ConstantsTest
{

    [TestMethod]
    public void When_Config_Then_OK()
    {
        var config = Constants.DefaultConfiguration;
        Assert.IsNotNull(config);
        Assert.IsNotNull(config.Size);
        Assert.IsNotNull(config.Size.Width);
        Assert.IsNotNull(config.Size.Height);
        Assert.IsNotNull(config.Location);
        Assert.IsNotNull(config.Location.X);
        Assert.IsNotNull(config.Location.Y);
        Assert.IsNotNull(config.Screens);
        Console.WriteLine($"configuration : {config}");
    }
}