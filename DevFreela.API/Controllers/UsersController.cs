using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{id}/profile-picture")]

        public IActionResult PostProfilePicture(IFormFile file)
        {
            var description = $"File name: {file.FileName}, Size: {file.Length}";

            //Processar a imagem

            return Ok(description);
        }
    }
}
