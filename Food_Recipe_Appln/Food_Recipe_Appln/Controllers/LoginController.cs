using Food_Recipe_Appln.Models;
using Microsoft.AspNetCore.Mvc;

namespace Food_Recipe_Appln.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public LoginController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET /api/Login
        [HttpGet("For All Login Users")]
        public ActionResult<IEnumerable<Login>> GetAllLogins()
        {
            var logins = _context.tbl_Login.ToList();
            return Ok(logins);
        }

        // POST /api/login
        [HttpPost("register")]
        public ActionResult<Login> AddLogin([FromBody] Login newLogin)
        {
            if (newLogin == null)
            {
                return BadRequest();
            }

            _context.tbl_Login.Add(newLogin);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllLogins), new { id = newLogin.Id }, newLogin);
        }

        [HttpPost("login")]
        public ActionResult<Login> Authenticate([FromBody] Login login)
        {
            if (login == null)
            {
                return BadRequest();
            }

            var user = _context.tbl_Login
                .FirstOrDefault(u => u.UserName == login.UserName && u.PassWord == login.PassWord);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);

        }
    }
}