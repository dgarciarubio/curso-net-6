namespace BusBookingApi.Clientes
{
    using Microsoft.AspNetCore.Mvc;
    using BusBookingApi.Clientes.Model;

    [ApiController]
    [Route("v{version:apiVersion}/clientes")]
    [ApiVersion("1.0")]
    public class ClientesController : ControllerBase
    {
        private readonly MediatR.ISender _sender;

        public ClientesController(MediatR.ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Cliente>))]
        public Task<IEnumerable<Cliente>> GetClientes()
        {
            return _sender.Send(new Queries.GetClientes());
        }

        [HttpGet("{dni}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cliente))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<Cliente> GetCliente(string dni)
        {
            return _sender.Send(new Queries.GetCliente
            {
                Dni  = dni,
            });
        }

        [HttpPost("{dni}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateCliente(string dni, Cliente request)
        {
            if (request.Dni != dni)
            {
                return BadRequest("El dni no coincide");
            }

            await _sender.Send(new Commands.CreateCliente
            {
                Cliente = request,
            });

            return Created($"/Clientes/{dni}", request);
        }

        [HttpPut("{dni}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCliente(string dni, Cliente request)
        {
            if (request.Dni != dni)
            {
                return BadRequest("El dni no coincide");
            }

            await _sender.Send(new Commands.UpdateCliente
            {
                Cliente = request,
            });

            return NoContent();
        }

        [HttpDelete("{dni}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCliente(string dni)
        {
            await _sender.Send(new Commands.DeleteCliente
            {
                Dni = dni,
            });

            return NoContent();
        }
    }
}
