namespace PlayerApp.Events.Media;

public class PlayMediaEvent : PlayerMediaEvent
{
    
    private readonly Uri _uri;

    public PlayMediaEvent(Uri uri)
    {
        _uri = uri;
    }
    
    public Uri Uri => _uri;
}