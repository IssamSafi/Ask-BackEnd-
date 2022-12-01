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
        public AskingController(IService<Asking> service) : base(service)
        {
            _service = service;
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

        //[HttpPost]
        //[Route("ask")]
        //public ActionResult TakeActionStatus(int AskId, string status)
        //{
        //    try
        //    {
        //        var AskObj = _service.GetById(AskId);
        //        if (AskObj != null)
        //        {
        //            AskObj.Itsapprove = Convert.ToDecimal(status);
        //            _service.Update(AskObj);

        //            ///send email


        //            return Ok(true);
        //        }

        //        return Ok(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //[HttpGet]
        //[Route("getuser")]
        //public ActionResult GetAsksByUserID(int UserId)
        //{
        //    try
        //    {
        //        var list = _service.GetAll().Where(x => x.UserId == UserId);
        //        return Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
