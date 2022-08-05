using JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Admins")]
        [Authorize (Roles ="Administrator")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName}, you are {currentUser.Role} ");
        } 
        [HttpGet("Sellers")]
        [Authorize (Roles ="Seller")]
        public IActionResult SellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName}, you are {currentUser.Role} ");
        }
        [HttpGet("AdminsAndSellers")]
        [Authorize(Roles = "Administrator,Seller")]
        public IActionResult AdminsAndSellersEndpoint()
        {
            var currentUser = GetCurrentUser();
            return Ok($"Hi {currentUser.GivenName}, you are {currentUser.Role} ");
        }
        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi, you're on public property");
        }
        private UserModel GetCurrentUser()
        {
            var Identity = HttpContext.User.Identity as ClaimsIdentity;
            if(Identity != null)
            {
                var userClaims = Identity.Claims;
                return new UserModel
                {
                    UserName=userClaims.FirstOrDefault
                    (o=>o.Type==ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress=userClaims.FirstOrDefault(o=>
                    o.Type==ClaimTypes.Email)?.Value,
                    GivenName=userClaims.FirstOrDefault(o=>
                    o.Type==ClaimTypes.GivenName)?.Value,
                    Surname=userClaims.FirstOrDefault(o=>
                    o.Type==ClaimTypes.Surname)?.Value,
                    Role=userClaims.FirstOrDefault(o=>
                    o.Type==ClaimTypes.Role)?.Value
                };
            }
            return null;
        }

    }
}
