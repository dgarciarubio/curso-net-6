namespace Novedades.csharp8;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AsynchronousStreams
{
    public static async Task DoWork()
    {
        await foreach (var data in GetData(100))
        {
            Console.WriteLine(data);
        }
    }

    private static async IAsyncEnumerable<int> GetData(int size)
    {
        var random = new Random();

        for (int i = 0; i < size; i++)
        {
            await Task.Delay(1000);
            yield return random.Next(100);
        }
    }
}
