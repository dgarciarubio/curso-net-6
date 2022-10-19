namespace BusBookingApi.Rutas.Queries
{
    using BusBookingApi.Exceptions;
    using Dapper;
    using MediatR;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetRuta : IRequest<Model.Ruta>
    {
        public string Id { get; set; } = string.Empty;
    }

    public class GetRutaHandler : IRequestHandler<GetRuta, Model.Ruta>
    {
        private readonly IDbConnection _dbConnection;

        public GetRutaHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Model.Ruta> Handle(GetRuta request, CancellationToken cancellationToken)
        {
            var ruta = await _dbConnection.QuerySingleOrDefaultAsync<Model.Ruta?>(
                sql: "SELECT Id, Origen, Destino FROM Rutas WHERE Id = @Id",
                param: new { Id = request.Id });
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            return ruta;
        }
    }
}
