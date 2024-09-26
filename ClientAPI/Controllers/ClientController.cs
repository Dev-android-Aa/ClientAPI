using ClientAPI.Models;
using ClientAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Client>> GetAll() => ClientServices.GetALL();
        [HttpGet("{id}")]
        public ActionResult <Client> GetByID(int id){

            var client = ClientServices.GetByID(id);
            if(client == null)
            {
                return NotFound();
            }
            return client;

        }
        [HttpPost]
        public ActionResult  CreateClient(Client client)
        {
            ClientServices.ADDClient(client);
            return CreatedAtAction(nameof(CreateClient), new { id = client.Id }, client);
           

        }
        [HttpPut("{id}")]
        public ActionResult UpdateClient(Client client , int id)
        {
            if(id != client.Id)
            {
                return BadRequest();
            }

           var existClient = ClientServices.GetByID(id);
            if(existClient is null)
            {
                return NotFound();
            }
            ClientServices.Update(client);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult<Client> DeleteByID(int id)
        {

            var client = ClientServices.GetByID(id);
            if (client == null)
            {
                return NotFound();
            }
            ClientServices.Delete(id);
            return NoContent();


        }


    }
}
