using DemoDapperAPI.Models;
using DemoDapperAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoDapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // GET: api/<ClientesController>
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clienteService = new ClientServices();
            {
                var cliente = clienteService.GetClientes();
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Mensaje: There is not clients");
            }
        }

        [HttpGet]
        [Route("ASYNC")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAsync()
        {
            var clienteService = new ClientServices();
            {
                var cliente = await clienteService.GetClientesAsync();
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Mensaje: There is not clients");
            }
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            var clienteService = new ClientServices();
            {
                var cliente = clienteService.GetClienteById(id);
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Mensaje: There is not client with id: " + id);
            }
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            var clienteService = new ClientServices();
            {
                clienteService.AddClient(cliente, true);

            }
        }

        //api/cliente/async
        [HttpPost]
        [Route("ASYNC")]
        public async Task PostAsync([FromBody] Cliente cliente)
        {
            try
            {
                var clienteService = new ClientServices();
                {
                    cliente.id = 0;
                    await clienteService.AddClientAsync(cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                var clienteService = new ClientServices();
                {
                    cliente.id = id;
                    clienteService.UpdateClient(cliente, true);
                }

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPut("{id}")]
        [Route("ASYNC")]
        public async Task PutAsync([FromBody] Cliente cliente)
        {
            try
            {
                var clienteService = new ClientServices();
                {
                    await clienteService.UpdateClientAsync(cliente);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
