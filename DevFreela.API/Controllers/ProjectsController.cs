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
            var project = _context.Projects
                .Include(p => p.Client) // Inclui a navegação para Client
                .Include(p => p.Freelancer) // Inclui a navegação para Freelancer
                .Include(p => p.Comments) // Inclui a navegação para Comments
                .SingleOrDefault(p => p.Id == id); // Procura o projeto com o ID especificado

            var model = ProjectViewModel.FromEntity(project);

            return Ok(model);
        }

        //POST api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            var project = model.ToEntity(); // Converte o modelo de entrada para a entidade Project
            _context.Projects.Add(project);
            _context.SaveChanges(); // Salva as alterações no banco de dados

            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        // PUT api/projects/1234
        [HttpPut("{id}")]

        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if(project == null)
            {
                return NotFound();
            }

            project.Update(model.Title, model.Description, model.TotalCost);

            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/projects/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            project.Start();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        // PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(CreateProjectCommentInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model );
        }
    }
}
