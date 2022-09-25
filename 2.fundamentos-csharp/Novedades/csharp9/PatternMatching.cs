namespace Novedades.csharp9;

public class PatternMatching
{
    public static void DoMoreStuff(int? number)
    {
        if (number is not null)
        {
            // Do stuff with the number
        }
    }

    public static void DoEvenMoreStuff(int? number)
    {
        if (number is >= 0 and <= 10)
        {
            // Do stuff with the number
        }
    }
}


