namespace Novedades.csharp10;

internal class Records
{
    public static void DoStuff()
    {
        var person1 = new Person()
        {
            FirstName = "Pepe",
            LastName = "Pérez",
        };

        // person1.FirstName = "Paco"; error de compilación!

        var person2 = new Person()
        {
            FirstName = "Pepe",
            LastName = "Pérez",
        };

        if (person1 == person2) //True, comparación por valor
        {
            var person3 = person2 with { LastName = "Martínez" };

            if (person3 == person2) //False, with copia datos sin modificar los originales
            {
                //No debería estar aquí
            }
        }
    }

    public record struct Person
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}
