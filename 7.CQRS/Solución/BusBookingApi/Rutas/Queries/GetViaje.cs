namespace BusBookingApi.Rutas.Queries
{
    using BusBookingApi.Exceptions;
    using Dapper;
    using MediatR;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetViaje : IRequest<Model.Viaje>
    {
        public string RutaId { get; set; } = string.Empty;
        public int ViajeId { get; set; }
    }

    public class GetViajeHandler : IRequestHandler<GetViaje, Model.Viaje>
    {
        private readonly IDbConnection _dbConnection;

        public GetViajeHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Model.Viaje> Handle(GetViaje request, CancellationToken cancellationToken)
        {
            using var multi = await _dbConnection.QueryMultipleAsync(
               sql: @"SELECT Id, Origen, Destino FROM Rutas WHERE Id = @RutaId;
                       SELECT Id, Salida, Llegada FROM Viajes WHERE RutaId = @RutaId AND Id = @ViajeId",
               param: new { RutaId = request.RutaId, ViajeId = request.ViajeId });

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
            return viaje;
        }
    }
}
