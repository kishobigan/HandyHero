using backend.Common;
using backend.DTO;
using backend.Models;
using backend.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FieldWorkerController : ControllerBase
    {
        IFieldWorker _fieldWorker;
        private IConfiguration _config;
        public FieldWorkerController(IFieldWorker fieldWorker, IConfiguration config)
        {
            _fieldWorker = fieldWorker;
            _config = config;
        }

        [HttpPost("createAccount")]
        public IActionResult RequestAccount([FromBody] FieldWorker fieldWorker)
        {
            if (ModelState.IsValid)
            {
                PasswordHash ph = new PasswordHash();
                var Password = ph.HashPassword(fieldWorker.Password);
                Console.WriteLine(Password);
                fieldWorker.Password = Password;
                Console.WriteLine(fieldWorker.Password);
                var result = _fieldWorker.signUp(fieldWorker);

                if (result)
                {
                    return Ok(result);
                } else
                {
                    return BadRequest("signup failed");
                }
            } else
            {
                return BadRequest("Model failed");
            }
        }

        [HttpPost("login")]
        public IActionResult login([FromBody] LoginRequest fieldWorker)
        {
            var email = fieldWorker.Email;
            var password = fieldWorker.Password;

            var result = _fieldWorker.login(email, password);

            if (!result)
            {
                return Unauthorized($"Username Password Incorrect {result}");
            }

            var loggedInWorker = _fieldWorker.GetFieldWorkerByEmail(email);

            // Authentication successful, generate JWT token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, loggedInWorker.Email),  // Email claim
            new Claim(ClaimTypes.NameIdentifier, loggedInWorker.Id.ToString()),  // Field worker ID claim
            new Claim(ClaimTypes.GivenName, loggedInWorker.Name)  // Field worker name claim
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token), Id = loggedInWorker.Id });
        }

        [HttpPatch("acceptProject")]
        public IActionResult acceptProject(Project project)
        {
            
                var result = _fieldWorker.acceptProject(project);
            if (result)
            {
                return Ok("Project Accepted");
            }else
            {
                return BadRequest("Project Accept failed");
            }
            
            
        }

        [HttpPatch("rejectProject")]
        public IActionResult rejectProject(Project project)
        {
            var result = _fieldWorker.rejectProject(project);
            if (result)
            {
                return Ok("Project Rejected");
            }else
            {
                return BadRequest("Project reject failed");
            }
        }

        [HttpGet("projects")]
        public IActionResult getProject([FromQuery(Name ="id")] int Id) 
        {
            var projects = _fieldWorker.GetProjects(Id);
            if (projects != null)
            {
                return Ok(projects);
            }else
            {
                return BadRequest("There is no project");
            }
        }

    }
}
