namespace PlayerApp.Models;

public static class Constants
{
    public const string ConfigurationFile = "prefs.properties";
    
    
    public static Configuration DefaultConfiguration
    {
        get
        {
            var screen01 = new Screen()
            {
                Id =0,
                Size = new Size() { Width = 520, Height = 380 },
                Location = new Location()
                {
                    X = 600,
                    Y = 50,
                }
            };
            var screen02 = new Screen()
            {
                Id = 1,
                Size = new Size() { Width = 520, Height = 380 },
                Location = new Location()
                {
                    X = 600,
                    Y = 500,
                }
            };
            
            var screens = new LinkedList<Screen>();
            screens.AddLast(screen01);
            screens.AddLast(screen02);
                
            Configuration cnf = new()
            {
                Size = new Size
                {
                    Width = 600,
                    Height = 400
                },
                Location = new Location
                {
                    X = 50, 
                    Y = 50
                },
                Screens = screens
                
            };
            return cnf;
        }
    }

    public static Screen DefaultScreen
    {
        get
        {
            var screen01 = new Screen()
            {
                Size = new Size() { Width = 520, Height = 380 },
                Location = new Location()
                {
                    X = 600,
                    Y = 50,
                }
            };
            return screen01;
        }
    }
}