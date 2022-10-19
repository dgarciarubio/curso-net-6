namespace BusBookingApi.Clientes.Commands
{
    using BusBookingApi.Exceptions;
    using BusBookingApi.Infrastructure;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateCliente : IRequest
    {
        public Model.Cliente Cliente { get; set; } = new Model.Cliente();
    }

    public class UpdateClienteHandler : IRequestHandler<UpdateCliente, Unit>
    {
        private readonly BusBookingApiDbContext _dbContext;

        public UpdateClienteHandler(BusBookingApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCliente request, CancellationToken cancellationToken)
        {
            var cliente = await _dbContext.Clientes.FindAsync(request.Cliente.Dni);
            if (cliente is null)
            {
                throw new EntityNotFoundException("El cliente no existe");
            }
            cliente.SetFullName(request.Cliente.Nombre, request.Cliente.Apellidos);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
