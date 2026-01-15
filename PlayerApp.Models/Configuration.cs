namespace PlayerApp.Models
{

    public class Configuration
    {
        public Size Size { get; set; }
        public Location Location { get; set; }

        public LinkedList<Screen>  Screens { get; set; } = new LinkedList<Screen>();
        

        public override string ToString()
        {
            return $"{{ \"Size\" :  {Size} , \"Location\" : {Location} , \"Screens\" : {Screens} }}";
        }
    }
}