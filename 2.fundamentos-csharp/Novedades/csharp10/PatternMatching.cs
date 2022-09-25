namespace Novedades.csharp10;

public class PatternMatching
{
    public enum Country
    {
        USA,
        Spain,
    }

    public class Location
    {
        public Country Country { get; set; }
    }

    public class Activity
    {
        public Location Location { get; set; } = new Location();
    }

    public static int GetAdultAge(Activity activity)
    {
        return activity switch
        {
            { Location.Country: Country.Spain } => 18,
            { Location.Country: Country.USA } => 21,
            _ => 20,
        };
    }
}


