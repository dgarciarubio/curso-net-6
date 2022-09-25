namespace Novedades.csharp10;

internal class StructConstructors
{
    public static void DoStuff()
    {
        var data = new Data();
        Console.WriteLine(data.ToString()); // Prints "1"

        data = default;
        Console.WriteLine(data); // Prints "0"

        data = (new Data[10])[0];
        Console.WriteLine(data); // Prints "0"
    }

    public readonly struct Data
    {
        private readonly int _value;

        public Data()
        {
            _value = 1;
        }

        public Data(int value)
        {
            _value = value;
        }

        public override string ToString() => _value.ToString();
    }
}
