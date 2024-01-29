using ABM_Customer.Business.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABM_Customer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {

        private Business.Interfaces.ICustomer _businessCustomer;

        public HomeController(Business.Interfaces.ICustomer businessCustomer)
        {
            _businessCustomer = businessCustomer;
        }


        [HttpPost]
        [Route("ResetCustomerData")]
        public IActionResult ResetCustomerData()
        {
            try
            {
                _businessCustomer.ResetCustomer();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "ERROR EN EL METODO ResetCustomerData()");
            }
        }

        [HttpGet]
        [Route("GetCustomers")]
        public IActionResult GetCustomers()
        {
            try
            {
                //Obtenemos todos los customers de la DDBB
                List<Data.Entities.Customers> customersList = _businessCustomer.GetList()
                                                                               .OrderByDescending(c => c.id)
                                                                               .Take(1000)
                                                                               .ToList();
                //Mapeamos a DTOs
                List<CustomerDTO> customersDTO = _businessCustomer.MapToDTO(customersList);

                return StatusCode(StatusCodes.Status200OK, customersDTO);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "ERROR EN EL METODO GetCustomers()");
            }
        }

        [HttpPut]
        [Route("CreateCustomer")]
        public IActionResult CreateCustomer(Business.Requests.NewConsumer consumer)
        {
            try
            {
                _businessCustomer.Create(consumer);

                return StatusCode(StatusCodes.Status200OK);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "ERROR AL CREAR UN NUEVO CUSTOMER");
            }


        }


        [HttpDelete]
        [Route("DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _businessCustomer.Delete(id);
                return StatusCode(StatusCodes.Status200OK);
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "ERROR AL ELIMINAR UN CUSTOMER");
            }
        }

    }
}
