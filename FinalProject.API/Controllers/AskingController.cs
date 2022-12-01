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
    public class AskingController : Controller<Asking>
    {

        private readonly IService<Asking> _service;
        private readonly IService<Userf> userservice;

        public AskingController(IService<Asking> service, IService<Userf> userservice) : base(service)
        {
            _service = service;
            this.userservice=userservice;
        }

        //[HttpGet]
        //[Route("GetAsk")]
        //public ActionResult GetAllAskingUsers()
        //{
        //    try
        //    {
        //        var list = _service.GetAll();
        //        return Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpPost]
        [Route("ask")]
        public ActionResult TakeActionStatus(int AskId,decimal status)
        {
            try
            {
                var AskObj = _service.GetById(AskId);
                if (AskObj != null)
                {
                    AskObj.Itsapprove = status;
                    _service.Update(AskObj);
                    if (status==1)
                    {
                        ///send email
                        var user = userservice.GetById(Convert.ToInt32(AskObj.UserId));
                    }
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
