namespace BusBookingApi.Rutas
{
    using Microsoft.AspNetCore.Mvc;
    using BusBookingApi.Rutas.Model;

    [ApiController]
    [Route("v{version:apiVersion}/rutas")]
    [ApiVersion("1.0")]
    public class RutasController : ControllerBase
    {
        private readonly MediatR.ISender _sender;

        public RutasController(MediatR.ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Ruta>))]
        public Task<IEnumerable<Ruta>> GetRutas()
        {
            return _sender.Send(new Queries.GetRutas());
        }

        [HttpGet("{rutaId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ruta))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<Ruta> GetRuta(string rutaId)
        {
            return _sender.Send(new Queries.GetRuta
            {
                Id = rutaId,
            });
        }

        [HttpGet("{rutaId}/viajes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Viaje>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IEnumerable<Viaje>> GetViajes(string rutaId)
        {
            return _sender.Send(new Queries.GetViajes
            {
                RutaId = rutaId,
            });
        }

        [HttpGet("{rutaId}/viajes/{viajeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Viaje))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<Viaje> GetViaje(string rutaId, int viajeId)
        {
            return _sender.Send(new Queries.GetViaje
            {
                RutaId = rutaId,
                ViajeId = viajeId,
            });
        }

        [HttpGet("{rutaId}/viajes/{viajeId}/asientos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Asiento>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IEnumerable<Asiento>> GetAsientos(string rutaId, int viajeId)
        {
            return _sender.Send(new Queries.GetAsientos
            {
                RutaId = rutaId,
                ViajeId = viajeId,
            });
        }

        [HttpGet("{rutaId}/viajes/{viajeId}/asientos/{asientoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Asiento))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<Asiento> GetAsiento(string rutaId, int viajeId, string asientoId)
        {
            return _sender.Send(new Queries.GetAsiento
            {
                RutaId = rutaId,
                ViajeId = viajeId,
                AsientoId = asientoId
            });
        }
    }
}
