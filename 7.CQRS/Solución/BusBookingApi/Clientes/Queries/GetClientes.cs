namespace BusBookingApi.Clientes.Queries
{
    using Dapper;
    using MediatR;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetClientes : IRequest<IEnumerable<Model.Cliente>>
    {
    }

    public class GetClientesHandler : IRequestHandler<GetClientes, IEnumerable<Model.Cliente>>
    {
        private readonly IDbConnection _dbConnection;

        public GetClientesHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<IEnumerable<Model.Cliente>> Handle(GetClientes request, CancellationToken cancellationToken)
        {
            return _dbConnection.QueryAsync<Model.Cliente>("SELECT Id AS Dni, Nombre, Apellidos, Email, Telefono, Foto FROM Clientes");
        }
    }
}
