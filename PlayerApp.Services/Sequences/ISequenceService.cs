using PlayerApp.XML;

namespace PlayerApp.Services.Sequences;

public interface ISequenceService
{
    
    SequenceType? Read( FileInfo fileInfo );
    
}