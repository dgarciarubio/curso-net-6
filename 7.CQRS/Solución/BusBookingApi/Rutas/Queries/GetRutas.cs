namespace BusBookingApi.Rutas.Queries
{
    using Dapper;
    using MediatR;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetRutas : IRequest<IEnumerable<Model.Ruta>>
    {
    }

    public class GetRutasHandler : IRequestHandler<GetRutas, IEnumerable<Model.Ruta>>
    {
        private readonly IDbConnection _dbConnection;

        public GetRutasHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<IEnumerable<Model.Ruta>> Handle(GetRutas request, CancellationToken cancellationToken)
        {
            return _dbConnection.QueryAsync<Model.Ruta>("SELECT Id, Origen, Destino FROM Rutas");
        }
    }
}
