﻿using backend.Models;
using backend.Services.Infrastructure;
using backend.Services.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        ICustomer _customer;
        private readonly IConfiguration _config;
        public CustomerController(ICustomer customer, IConfiguration config)
        {
            _customer = customer;
            _config = config;
        }

        [HttpPost("create")]
        public IActionResult createAccount([FromBody] Customer customer)
        {
            if (ModelState.IsValid) 
            { 
                
                var result = _customer.SignUp(customer);
                if (result) 
                {
                    Console.WriteLine("registration success");
                    return Ok(result);
                    
                }else
                {
                    Console.WriteLine("registration failed");
                    return BadRequest(result);
                }
            }else
            {
                return BadRequest("ModelError");
            }
        }

        [HttpPost("login")]
        public IActionResult login([FromBody] Customer customer) 
        { 
            var email = customer.Email;
            var password = customer.Password;

            var result = _customer.Login(email, password);
            if (result)
            {
                var LoggedInCustomer = _customer.getCustomerByMail(email);

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, email),  // Email claim
                new(ClaimTypes.NameIdentifier, LoggedInCustomer.Id.ToString()),  // Admin ID claim
                new(ClaimTypes.GivenName, LoggedInCustomer.Name)  // Admin name claim
                    }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = credentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token), Id = LoggedInCustomer.Id });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("requestWork")]
        public IActionResult requestWork([FromBody] Project project)
        {
            var result = _customer.createProject(project);
            if (result)
            {
                return Ok(result);
            }else
            {
                return BadRequest();
            }
        }

        [HttpGet("myProject")]
        public IActionResult getMyProjects([FromQuery(Name = "id")] int Id)
        {
            var projects = _customer.getMyProject(Id);

            if(projects == null)
            {
                return NotFound();
            }
            else {
                return Ok(projects);
            }
        }

        [HttpPost("complaint")]
        public IActionResult makeComplaint([FromBody] Complaint complaint)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Ithu vera");
                return BadRequest(ModelState);
            }

            var result = _customer.createComplaint(complaint);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                Console.WriteLine("something went wrong");
                return BadRequest(result);
            }
        }

    }
}
