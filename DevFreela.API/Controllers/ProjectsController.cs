using DevFreela.API.Models;
using DevFreela.API.Persistence;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        private readonly DevFreelaDbContext _context;
        public ProjectsController(DevFreelaDbContext context)
        {
            _context = context;
        }

        //GET api/projects?search=crm
        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var projects = _context.Projects
                .Include(p => p.Client) // Inclui a navegação para Client
                .Include(p => p.Freelancer) // Inclui a navegação para Freelancer
                .Where(p => !p.IsDeleted).ToList();

            var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();

            return Ok(projects);
        }

        //GET api/projects/1234
        [HttpGet("{id}")] // Tem que colocar chave para ele entender como parâmetro

        public IActionResult GetById(int id)
        {
            return Ok();
        }

        //POST api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        // PUT api/projects/1234
        [HttpPut("{id}")]

        public IActionResult Put(int id, UpdateProjectInputModel model)
        {

            return NoContent();
        }

        // DELETE api/projects/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        // PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        // PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            return NoContent();
        }

        // POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(CreateProjectCommentInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model );
        }
    }
}
