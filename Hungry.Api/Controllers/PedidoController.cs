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
        public IEnumerable<Produto> Get()
        {
            return Produto.GetAll();
        }
    }
}
