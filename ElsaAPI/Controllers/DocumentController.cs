using Elsa.Infrastructure.DocumentService;
using ElsaAPI.Entities;
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
        private readonly UserService _userService;

        public DocumentController(ModifyDocument modifyDocument, UserService userService)
        {
            _modifyDocument = modifyDocument;
            _userService = userService;
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

        [HttpPost("approval")]
        public IActionResult UserApproval(User user)
        {
            return Ok();
        }

        [HttpPost("file-create")]
        public IActionResult CreateFile(User user)
        {
            _modifyDocument.CreateFileAsync(user.Name);
            return Ok();
        }

        [HttpPost("newuser")]
        public IActionResult AddUser()
        {
            var newUser = new User
            {
                Id = 1,
                Name = "sad"
            };
            _userService.CreateUser(newUser);
            return Ok();
        }
    }
}
