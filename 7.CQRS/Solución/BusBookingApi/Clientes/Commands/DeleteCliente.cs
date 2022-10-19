namespace BusBookingApi.Clientes.Commands
{
    using BusBookingApi.Exceptions;
    using BusBookingApi.Infrastructure;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCliente : IRequest
    {
        public string Dni { get; set; } = string.Empty;
    }

    public class DeleteClienteHandler : IRequestHandler<DeleteCliente, Unit>
    {
        private readonly BusBookingApiDbContext _dbContext;

        public DeleteClienteHandler(BusBookingApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteCliente request, CancellationToken cancellationToken)
        {
            var cliente = await _dbContext.Clientes.FindAsync(request.Dni);
            if (cliente is null)
            {
                throw new EntityNotFoundException("El cliente no existe");
            }
            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
