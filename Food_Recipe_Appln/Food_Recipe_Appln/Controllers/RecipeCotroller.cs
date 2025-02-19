using Food_Recipe_Appln.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food_Recipe_Appln.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RecipeController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET /api/Recipe
        [HttpGet("For Get Recipe")]
        public ActionResult<IEnumerable<Login>> GetAllRecipe()
        {
            var logins = _context.tbl_Recipe.ToList();
            return Ok(logins);
        }

        // POST /api/Recipe
        [HttpPost("For Add Recipe")]
        public ActionResult<Login> AddLogin([FromBody] Recipe newRecipe)
        {
            if (newRecipe == null)
            {
                return BadRequest();
            }

            _context.tbl_Recipe.Add(newRecipe);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllRecipe), new { id = newRecipe.Recipe_id }, newRecipe);
        }
        // DELETE /api/Recipe/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipe = _context.tbl_Recipe.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.tbl_Recipe.Remove(recipe);
            _context.SaveChanges();

            return NoContent();
        }


        // PUT /api/Recipe/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateRecipe(int id, [FromBody] Recipe updatedRecipe)
        {
            if (updatedRecipe == null || updatedRecipe.Recipe_id != id)
            {
                return BadRequest();
            }

            var existingRecipe = _context.tbl_Recipe.FirstOrDefault(r => r.Recipe_id == id);
            if (existingRecipe == null)
            {
                return NotFound();
            }

            existingRecipe.Recipe_Name = updatedRecipe.Recipe_Name;
            existingRecipe.Ingrdients = updatedRecipe.Ingrdients;
            existingRecipe.Description = updatedRecipe.Description;

            _context.tbl_Recipe.Update(existingRecipe);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
