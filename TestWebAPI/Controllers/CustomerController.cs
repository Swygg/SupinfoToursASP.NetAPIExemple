using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Models.DTO;
using TestWebAPI.Models.Inputs.Customer;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("/Customer")]
    [AllowAnonymous]
    public class CustomerController : Controller
    {
        private readonly ICustomersService _customersService;

        public CustomerController(ICustomersService customersService)
        {
            _customersService = customersService;
        }


        #region Methods with no specific return
        [HttpPost("Initiate")]
        public IActionResult Initiate()
        {
            try
            {
                _customersService.Initiate();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("Add")]
        public IActionResult Add(CustomerCreateInput c)
        {
            try
            {
                _customersService.Add(c);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400
            }
        }

        [HttpPost("Update")]
        public IActionResult Update(CustomerUpdateInput c)
        {
            try
            {
                _customersService.Update(c);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _customersService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400
            }
        }

        [HttpGet(Name = "ReadOne")]
        public IActionResult ReadOne(int id)
        {
            try
            {
                var c = _customersService.ReadOne(id);
                if (c == null)
                    throw new Exception("No customer with that id");
                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400
            }
        }

        [HttpGet("ReadAll")]
        public IActionResult ReadAll()
        {
            try
            {
                return Ok(_customersService.ReadAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);//400
            }
        }
        #endregion


        #region Methods with specific return
        [HttpPost("Initiate2")]
        public void Initiate2()
        {
            try
            {
                _customersService.Initiate();
                Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
            }

        }

        [HttpPut("Add2")]
        public void Add2(CustomerCreateInput c)
        {
            try
            {
                _customersService.Add(c);
                Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
            }
        }

        [HttpPost("Update2")]
        public void Update2(CustomerUpdateInput c)
        {
            try
            {
                _customersService.Update(c);
                Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
            }
        }

        [HttpDelete("Delete2")]
        public void Delete2(int id)
        {
            try
            {
                _customersService.Delete(id);
                Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
            }
        }

        [HttpGet("ReadOne2")]
        public Customer ReadOne2(int id)
        {
            try
            {
                var c = _customersService.ReadOne(id);
                if (c == null)
                    throw new Exception("No customer with that id");
                Response.StatusCode = 200;
                return c;
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return null;
            }
        }

        [HttpGet("ReadAll2")]
        public List<Customer> ReadAll2()
        {
            try
            {
                Response.StatusCode = 200;
                return _customersService.ReadAll();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return null;
            }
        } 
        #endregion
    }
}
