﻿namespace Novedades.csharp7;

public class PatternMatching
{
    public static int DoStuff(object obj)
    {
        if (obj is null) // is expression
        {
            throw new ArgumentNullException(nameof(obj));
        }

        if (!(obj is string strValue) || // is expression with assignment
            !int.TryParse(strValue, out int result))  // out argument with assignment
        {
            throw new ArgumentException("Invalid value", nameof(obj));
        }

        return result;
    }
}


