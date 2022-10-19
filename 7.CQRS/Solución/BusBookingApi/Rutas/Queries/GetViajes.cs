namespace BusBookingApi.Rutas.Queries
{
    using BusBookingApi.Exceptions;
    using Dapper;
    using MediatR;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetViajes : IRequest<IEnumerable<Model.Viaje>>
    {
        public string RutaId { get; set; } = string.Empty;
    }

    public class GetViajesHandler : IRequestHandler<GetViajes, IEnumerable<Model.Viaje>>
    {
        private readonly IDbConnection _dbConnection;

        public GetViajesHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Model.Viaje>> Handle(GetViajes request, CancellationToken cancellationToken)
        {
            using var multi = await _dbConnection.QueryMultipleAsync(
               sql: @"SELECT Id, Origen, Destino FROM Rutas WHERE Id = @Id;
                       SELECT Id, Salida, Llegada FROM Viajes WHERE RutaId = @Id",
               param: new { Id = request.RutaId });

            var ruta = await multi.ReadSingleOrDefaultAsync<Model.Ruta?>();
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            return await multi.ReadAsync<Model.Viaje>();
        }
    }
}
