using FinalProject.core.Data;
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
    public class TestimonialController : Controller<Testimonialf>
    {
        private readonly IService<Testimonialf> _service;

        public TestimonialController(IService<Testimonialf> service) : base(service)
        {
            _service = service; 

        }

        
        [HttpGet]
        [Route("Status/{testID},{status}")]
        public ActionResult TestmonialStatus(int testID, decimal status)
        {
            try
            {
               var TestObj = _service.GetById(testID);
                if (TestObj != null)
                {
                    TestObj.Itsapprove = status;
                    _service.Update(TestObj);
                    //if (status == 1)
                    //{
                    
                    //}
                    //else if (status == 0)
                    //{
                      
                    //}
                    return Ok(true);
                }

                return Ok(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
