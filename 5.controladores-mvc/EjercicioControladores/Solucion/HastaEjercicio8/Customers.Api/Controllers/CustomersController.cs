
using Customers.Api.Models;
using Customers.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Customers.Api.Controllers
{
    [ApiController]
    [Route($"/{ApiConstants.ApiBase}/{ApiConstants.CustomersUri}")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet("", Name = nameof(CustomersController.GetCustomers))]
        [ProducesResponseType(typeof(IEnumerable<CustomerResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UpdateCustomerRequest>>> GetCustomers()
        {
            var customers = _customersService.GetCustomers();
            return Ok(customers);
        }

        [HttpGet($"{ApiConstants.ByPage}", Name = nameof(CustomersController.GetCustomersByPage))]
        [ProducesResponseType(typeof(IEnumerable<CustomerResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UpdateCustomerRequest>>> GetCustomersByPage([FromQuery] int page)
        {
            var countCustomers = _customersService.GetCustomers().Count();
            var customers = _customersService.GetCustomersByPage(page - 1);
            return Ok(new GetCustomersByPageResponse { CustomersCount = countCustomers, Data = customers });
        }

        [HttpGet(ApiConstants.CustomerParamId, Name = nameof(CustomersController.GetCustomer))]
        [ProducesResponseType(typeof(CustomerResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<UpdateCustomerRequest>> GetCustomer([FromRoute] int customerId)
        {
            var client = _customersService.GetCustomer(customerId);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPut(ApiConstants.CustomerParamId, Name = nameof(CustomersController.PutCustomer))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> PutCustomer([FromRoute] int customerId, [FromBody] UpdateCustomerRequest customer)
        {
            _customersService.UpdateCustomer(customerId, customer);
            return Ok();
        }

        [HttpPost("", Name = nameof(CustomersController.PostCustomer))]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<int>> PostCustomer([FromBody] CreateCustomerRequest customerRequest)
        {
            var id = _customersService.CreateCustomer(customerRequest);
            return CreatedAtAction(nameof(CustomersController.GetCustomer), new { customerId = id }, id);
        }

        [HttpDelete(ApiConstants.CustomerParamId, Name = nameof(CustomersController.DeleteCustomer))]
        [ProducesResponseType(typeof(CustomerResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteCustomer([FromRoute] int customerId)
        {
            _customersService.DeleteCustomer(customerId);
            return NoContent();
        }
    }
}
