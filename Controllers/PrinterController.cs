using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawPrintService.Controllers
{
    [Route("api/[controller]")]
    public class PrinterController : Controller
    {
        public sealed class PrintRequest
        {
            public string Title { get; set; }
            public byte[] Data { get; set; }
        }

        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public PrinterController(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello World!";
        }

        [HttpPost]
        public IActionResult Post([FromForm]string Title, IFormFile Data)
        {
            var printer = new RawPrint.Printer();
            try
            {
                var stream = Data.OpenReadStream();

                byte[] binData = new byte[stream.Length];
                stream.Read(binData, 0, (int)stream.Length);
                stream.Seek(0, System.IO.SeekOrigin.Begin);


                printer.PrintRawStream(
                    Util.RawPrintSettings.Printer,
                    Data.OpenReadStream(),
                    Title, false);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
