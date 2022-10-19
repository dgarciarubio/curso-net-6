namespace BusBookingApi.Rutas.Queries
{
    using BusBookingApi.Exceptions;
    using Dapper;
    using MediatR;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAsiento : IRequest<Model.Asiento>
    {
        public string RutaId { get; set; } = string.Empty;
        public int ViajeId { get; set; }
        public string AsientoId { get; set; } = string.Empty;
    }

    public class GetAsientoHandler : IRequestHandler<GetAsiento, Model.Asiento>
    {
        private readonly IDbConnection _dbConnection;

        public GetAsientoHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Model.Asiento> Handle(GetAsiento request, CancellationToken cancellationToken)
        {
            using var multi = await _dbConnection.QueryMultipleAsync(
                sql: @"SELECT Id, Origen, Destino FROM Rutas WHERE Id = @RutaId;
                       SELECT Id, Salida, Llegada FROM Viajes WHERE RutaId = @RutaId AND Id = @ViajeId;
                       SELECT Asientos.Id, Situacion, Espacio 
                            FROM Asientos 
                            INNER JOIN Viajes ON Asientos.ViajeId = Viajes.Id
                            WHERE RutaId = @RutaId AND ViajeId = @ViajeId AND Asientos.Id = @AsientoId;",
                param: new { RutaId = request.RutaId, ViajeId = request.ViajeId, AsientoId = request.AsientoId });

            var ruta = await multi.ReadSingleOrDefaultAsync<Model.Ruta?>();
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            var viaje = await multi.ReadSingleOrDefaultAsync<Model.Viaje?>();
            if (viaje is null)
            {
                throw new EntityNotFoundException("El viaje no existe");
            }
            var asiento = await multi.ReadSingleOrDefaultAsync<Model.Asiento?>();
            if (asiento is null)
            {
                throw new EntityNotFoundException("El asiento no existe");
            }
            return asiento;
        }
    }
}
