using System;
using System.Collections.Generic;

namespace proxy_web_api.Controllers
{
    public class Order : BaseModel
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public List<object> Items { get; set; }
        public DateTime OrderPlacedDateTime { get; set; }
        public string Store { get; set; }
    }
}