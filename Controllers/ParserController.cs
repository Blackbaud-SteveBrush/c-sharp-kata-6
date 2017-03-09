using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace c_sharp_kata_6.Controllers {

  [Route("[controller]")]
  public class ParserController : Controller {

    [HttpPost("bytes")]
    public IActionResult PostBytes(string query) {
      if (query == null) {
        return BadRequest();
      }
      var bytes = Encoding.ASCII.GetBytes(query);
      var result = new Dictionary<string, byte[]>(){
        { "bytes", bytes }
      };
      return Content(JsonConvert.SerializeObject(result), "application/json");
    }
  }
}