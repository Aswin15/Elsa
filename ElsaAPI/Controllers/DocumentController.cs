using Elsa.Infrastructure.DocumentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace ElsaAPI.Controllers
{
    [Route("v1")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ModifyDocument _modifyDocument;

        public DocumentController(ModifyDocument modifyDocument)
        {
            _modifyDocument = modifyDocument;
        }

        [HttpGet("helloworld")]
        public IActionResult HelloWorld()
        {
            return Ok();
        }

        [HttpPost("file-upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            await _modifyDocument.UploadFile(file);
            return Ok();
        }

        [HttpGet("approval")]
        public IActionResult UserApproval()
        {
            return Ok();
        }

        [HttpPost("file-create")]
        public async Task<IActionResult> CreateFile()
        {
            await _modifyDocument.CreateFileAsync();
            return Ok();
        }
    }
}
