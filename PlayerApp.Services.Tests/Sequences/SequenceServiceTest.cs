using System;
using System.IO;
using JetBrains.Annotations;
using Microsoft.Testing.Platform.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayerApp.Services.Sequences;

namespace PlayerApp.Services.Tests.Sequences;

[TestClass]
[TestSubject(typeof(SequenceService))]
public class SequenceServiceTest
{

    [TestMethod]
    public void When_Read_Then_Return_Sequence()
    {
        var sequenceService = new SequenceService();
        Assert.IsNotNull(sequenceService);

        var path = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "../../..", "default.xseq"));
        Assert.IsTrue(path.Exists);
        
        var sequence = sequenceService.Read(path);
        Assert.IsNotNull(sequence);
        Assert.IsNotNull(sequence.Name);
        Assert.IsNotEmpty(sequence.Videos);

        Console.WriteLine($"sequence  [{sequence.Name}]");
        foreach (var video in sequence.Videos)
        {
            Assert.IsNotNull(video);
            Console.WriteLine(($"video {video.Type} {video.Path}"));
        }
    }
}