using System.Web.Http;
using Backend.Services.Interfaces;
using Backend.ViewModels;

namespace Backend.Controllers
{
    [AllowAnonymous]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("api/Customer")]
        public IHttpActionResult CustomerGetAll()
        {
            return Ok(_customerService.CustomerGetAll());
        }


        [HttpGet]
        [Route("api/Customer/{customerId:int}")]
        public IHttpActionResult CustomerGetById(int customerId)
        {
            return Ok(_customerService.CustomerGetById(customerId));
        }

        [HttpPost]
        [Route("api/Customer")]
        public IHttpActionResult CustomerCreate([FromBody] CustomerVM customer)
        {
            return Ok(_customerService.CustomerCreate(customer));
        }

        [HttpPut]
        [Route("api/Customer")]
        public IHttpActionResult CustomerUpdate([FromBody] CustomerVM customer)
        {
            return Ok(_customerService.CustomerUpdate(customer));
        }

        [HttpDelete]
        [Route("api/Customer/{customerId:int}")]
        public IHttpActionResult CustomerDelete(int customerId)
        {
            return Ok(_customerService.CustomerDelete(customerId));
        }
    }
}