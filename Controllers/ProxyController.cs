using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace proxy_web_api.Controllers
{
    [ApiController]
    public class ProxyController : ControllerBase
    {
        private readonly ILogger<ProxyController> _logger;

        public ProxyController(ILogger<ProxyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [HttpPost]
        [HttpPut]
        [Route("[controller]")]
        public IActionResult CommonAction([FromBody] Object payload)
        {
            object responseObject = null;

            if (payload != null)
            {
                BaseModel record = JsonConvert.DeserializeObject<BaseModel>(payload.ToString());
                switch (record.Type)
                {
                    case nameof(Customer):
                        responseObject = JsonConvert.DeserializeObject<Customer>(payload.ToString());
                        Console.WriteLine($"The Payload-Object is {nameof(Customer)} \n CustomerId : {(responseObject as Customer).CustomerId}");
                        break;
                    case nameof(Order):
                        responseObject = JsonConvert.DeserializeObject<Order>(payload.ToString());
                        Console.WriteLine($"The Payload-Object is {nameof(Order)} \n OrderId : {(responseObject as Order).OrderId}");
                        break;
                    default:
                        break;
                }
            }
            switch (Request.Method)
            {
                case "POST":
                    return Created(Request.Path, responseObject);
                case "PUT":
                    return Accepted(responseObject);
                case "GET":
                    return Ok(responseObject);
                default:
                    return NotFound();
            }
        }


        [HttpGet]
        [HttpPost]
        [HttpPut]
        [Route("[controller]/with-param")]
        public IActionResult CommonActionWithQueryParam([FromBody] Object payload, [FromQuery] string type)
        {
            object responseObject = null;

            if (payload != null)
            {
                switch (type)
                {
                    case nameof(Customer):
                        responseObject = JsonConvert.DeserializeObject<Customer>(payload.ToString());
                        Console.WriteLine($"The Payload-Object is {nameof(Customer)} \n CustomerId : {(responseObject as Customer).CustomerId}");
                        break;
                    case nameof(Order):
                        responseObject = JsonConvert.DeserializeObject<Order>(payload.ToString());
                        Console.WriteLine($"The Payload-Object is {nameof(Order)} \n OrderId : {(responseObject as Order).OrderId}");
                        break;
                    default:
                        break;
                }
            }
            switch (Request.Method)
            {
                case "POST":
                    return Created(Request.Path, responseObject);
                case "PUT":
                    return Accepted(responseObject);
                case "GET":
                    return Ok(responseObject);
                default:
                    return NotFound();
            }
        }
    }
}
