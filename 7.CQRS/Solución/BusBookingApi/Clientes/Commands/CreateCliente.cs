namespace BusBookingApi.Clientes.Commands
{
    using BusBookingApi.Exceptions;
    using BusBookingApi.Infrastructure;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCliente : IRequest
    {
        public Model.Cliente Cliente { get; set; } = new Model.Cliente();
    }

    public class CreateClienteHandler : IRequestHandler<CreateCliente, Unit>
    {
        private readonly BusBookingApiDbContext _dbContext;

        public CreateClienteHandler(BusBookingApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateCliente request, CancellationToken cancellationToken)
        {
            var clienteExistente = await _dbContext.Clientes.FindAsync(request.Cliente.Dni);
            if (clienteExistente is not null)
            {
                throw new EntityAlreadyExistingException("El cliente con ese DNI ya existe");
            }
            var cliente = new Cliente(request.Cliente.Dni, request.Cliente.Nombre, request.Cliente.Apellidos);
            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
