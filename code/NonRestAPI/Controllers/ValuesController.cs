using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NonRestAPI.Controllers
{
    public class ValuesController : Controller
    {
        

        [HttpPost("api/action")]
        public ActionResponse DoAction([FromBody]ActionRequest request)
        {
            try
            {
                Action a = Enum.Parse<Action>(request.Action);


                return new ActionResponse
                {
                    Status = "Ok " + request.Action
                };
            }
            catch
            {
                return new ActionResponse
                {
                    Status = "Error"
                };
            }
        }
    }

    public class ActionResponse
    {
        public string Status { get; set; }
    }
    public class ActionRequest
    {
        public string Action { get; set; }
    }
    public enum Action
    {
        GetBook,
        CreateBook
    }
}
