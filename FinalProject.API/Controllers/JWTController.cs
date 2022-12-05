using FinalProject.core.Data;
using FinalProject.core.DTO;
using FinalProject.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private readonly IJWTService jwtservice;
        public JWTController(IJWTService jwtservice)
        {
            this.jwtservice = jwtservice;
        }

        [HttpPost]

        public IActionResult Auth([FromBody] Loginf login)
        {
            var token = jwtservice.Auth(login);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }

        }


        [HttpGet]
        public List<Report> Reports()
        {
            return jwtservice.Reports();
        }


        [HttpGet]
        [Route("Total")]
        public List<TotalUser> totalUser()
        {
            return jwtservice.totalUser();
        }



    }
}
