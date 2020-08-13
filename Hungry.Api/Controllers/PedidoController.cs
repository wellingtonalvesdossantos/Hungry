using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hungry.Core;

namespace Hungry.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Pedido> GetByCustomer(int clientId)
        {
            return Pedido.GetByCustomer(clientId);
        }

        [HttpPost]
        public ActionResult AddNewOrder(Pedido pedido)
        {
            try
            {
                pedido.Create();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
