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
        [Route("Comments")]

        public List<Comments> comments()
        {
            return jwtservice.comments();
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

        [HttpGet]
        [Route("Testmonial")]
        public List<Testmonial> testmonials()
        {
            return jwtservice.testmonials();
        }



        [HttpGet]
        [Route("Search/{search}")]

        public List<SearchUser> searchUsers(String search)
        {
            return jwtservice.searchUsers(search);
        }


        [HttpGet]
        [Route("AllUserSearch")]
        public List<AllUserSearch> allUserSearches()
        {
            return jwtservice.allUserSearches();
        }




        [HttpPost]
        [Route("Rigester")]
        public void Rigesters(Rigester register)
        {
            jwtservice.Rigesters(register);
        }

        [HttpGet]
        [Route("chart")]
        public List<Chart> charts()
        {
            return jwtservice.charts();
        }

        [HttpGet]
        [Route("CommentNum")]
        public List<CommentNumcs> commentNumcs()
        {
            return jwtservice.commentNumcs();
        }

    }
}
