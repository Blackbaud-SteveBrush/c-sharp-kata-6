using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace c_sharp_kata_6.Controllers {

  public class FormData {
    public string Query { get; set; }
  }

  [Route("[controller]")]
  public class ParserController : Controller {

    [HttpPost("bytes")]
    public IActionResult PostBytes(FormData formData) {
      if (formData.Query == null) {
        return BadRequest();
      }
      var bytes = Encoding.ASCII.GetBytes(formData.Query);
      var result = new Dictionary<string, byte[]>(){
        { "bytes", bytes }
      };
      return Content(JsonConvert.SerializeObject(result), "application/json");
    }
  }
}