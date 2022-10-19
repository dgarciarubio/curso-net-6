namespace BusBookingApi.Clientes.Queries
{
    using BusBookingApi.Exceptions;
    using Dapper;
    using MediatR;
    using System.Data;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCliente : IRequest<Model.Cliente>
    {
        public string Dni { get; set; } = string.Empty;
    }

    public class GetClienteHandler : IRequestHandler<GetCliente, Model.Cliente>
    {
        private readonly IDbConnection _dbConnection;

        public GetClienteHandler(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Model.Cliente> Handle(GetCliente request, CancellationToken cancellationToken)
        {
            var cliente = await _dbConnection.QuerySingleOrDefaultAsync<Model.Cliente?>(
                sql: "SELECT Id AS Dni, Nombre, Apellidos, Email, Telefono, Foto FROM Clientes WHERE Id = @Dni",
                param: new { Dni = request.Dni });
            if (cliente is null)
            {
                throw new EntityNotFoundException("El cliente no existe");
            }
            return cliente;
        }
    }
}
