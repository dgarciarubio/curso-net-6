namespace BusBookingApi.Rutas.Model;

public class Viaje
{
    public int Id { get; set; }

    public DateTime Salida { get; set; }

    public DateTime Llegada { get; set; }
}