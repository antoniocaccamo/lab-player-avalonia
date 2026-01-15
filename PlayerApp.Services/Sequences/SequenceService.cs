using System.Xml.Serialization;
using PlayerApp.XML;

namespace PlayerApp.Services.Sequences;

public class SequenceService : ISequenceService
{
    
    private readonly XmlSerializer  _serializer = new XmlSerializer( typeof( SequenceType ) );
    
    public SequenceType? Read(FileInfo fileInfo)
    {
        var sequence = (SequenceType) _serializer.Deserialize(new FileStream( fileInfo.FullName, FileMode.Open) );
        return sequence;
    }
}



