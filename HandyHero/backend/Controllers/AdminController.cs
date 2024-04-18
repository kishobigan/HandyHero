using backend.Models;
using backend.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;
        private IConfiguration _config;

        public AdminController(IAdmin adminRepository, IConfiguration config)
        {
            _admin = adminRepository;
            _config = config;
        }

        [HttpPost("create")]
        public IActionResult CreateAdmin([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var isAdmin = _admin.IsAdmin(admin);
                if (!isAdmin)
                {
                    var result = _admin.CreateAdmin(admin);
                    if (result)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost("adminLogin")]
        public IActionResult AdminLogin([FromBody] Admin admin)
        {
            var result = _admin.Login(admin.Email, admin.password);
            if (result)
            {
                // Retrieve admin details from the database
                var loggedInAdmin = _admin.GetAdminByEmail(admin.Email);

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, admin.Email),  // Email claim
                new(ClaimTypes.NameIdentifier, loggedInAdmin.Id.ToString()),  // Admin ID claim
                new(ClaimTypes.GivenName, loggedInAdmin.Name)  // Admin name claim
                    }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = credentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token), Id = loggedInAdmin.Id });
            }
            else
            {
                return Unauthorized("Invalid email or password");
            }
        }


        [HttpGet("isAuthenticated")]
        public IActionResult isAthenticated([FromQuery(Name = "token")] string token)
        {
            var validatedToken = _admin.validateToken(token);
            if (validatedToken != null)
            {
                return Ok(new { authenticated = true });
            }
            else
            {
                return Unauthorized(new { authenticated = false });
            }
        }

        [HttpGet("/something")]
        public IActionResult getAdmin([FromQuery(Name = "token")] string token)
        {
            var validatedToken = _admin.validateToken(token);
            if (validatedToken != null)
            {
                var adminId = validatedToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var adminName = validatedToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                return Ok(new { authenticated = true, adminId = adminId, adminName = adminName });

            }
            else
            {
                return Unauthorized(new { authenticated = false, message = "unAuthorized" });
            }
        }

        [HttpGet("")]
        public IActionResult getAdminById([FromQuery(Name = "id")] int id)
        {
            var admin = _admin.GetAdminById(id);
            if (admin != null)
            {
                return Ok(admin);
            }else
            {
                return Unauthorized(new { message = "Please Login" });
            }
        }

        [HttpGet("fieldWorkers")]
        public IActionResult GetFieldWorkers()
        {
            var fieldWorkers = _admin.GetFieldWorkers();

            if (fieldWorkers != null)
            {
                return Ok(fieldWorkers);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("customers")]
        public IActionResult GetCustomers()
        {
            var customers = _admin.GetCustomers();

            if (customers != null)
            {
                return Ok(customers);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPatch("acceptFieldWorker")]
        public IActionResult acceptFieldWorker([FromQuery] int adminId, string email)
        {
            var result = _admin.AcceptFieldWorker(email, adminId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch("rejectFieldWorker")]
        public IActionResult rejectFieldWorker([FromQuery] int adminId, string email)
        {
            var result = _admin.RejectFieldWorker(email, adminId);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("complaints")]
        public IActionResult getAllComplaints()
        {
            var Complaints = _admin.gettAllComplaints();
            return Ok(Complaints);
        }

    }
}
