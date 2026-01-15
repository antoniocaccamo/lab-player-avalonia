namespace PlayerApp.Models;

public class Screen
{
    public int Id;
    public Size Size { get; set; }
    public Location Location { get; set; }

        

    public override string ToString()
    {
        return $"{{ \"Id\"  : {Id}, \"Size\" :  {Size} , \"Location\" : {Location} }}";
    }
}