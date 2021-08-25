using System;

namespace proxy_web_api.Controllers
{
    public class BaseModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int Version { get; set; }
    }
}