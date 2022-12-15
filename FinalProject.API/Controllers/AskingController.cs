using FinalProject.core.Data;
using FinalProject.core.Service;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net.Mail;
using System.Threading.Tasks;

using MailKit.Net.Smtp;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AskingController : Controller<Asking>
    {

        private readonly IService<Asking> _service;
        private readonly IService<Userf> _userservice;
        private readonly IService<Likeanddislike> _likeservice;

        public AskingController(IService<Asking> service, IService<Userf> userservice, IService<Likeanddislike> likeservice) : base(service)
        {
            _service = service;
            _userservice=userservice;
            _likeservice = likeservice;
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

        [HttpGet]
        [Route("ask/{AskId},{status}")]
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
                        ///
                        
                        //var user = _userservice.GetById(Convert.ToInt32(AskObj.UserId));
                        
                        MimeMessage message = new MimeMessage();
                        MailboxAddress from = new MailboxAddress(" aprrove quastion", "201810741@std-zuj.edu.jo");
                        message.From.Add(from);
                        MailboxAddress to = new MailboxAddress("User", "safiesam3@gmail.com");
                        message.To.Add(to);
                        message.Subject = "About of Accept quastion";
                        BodyBuilder bodyBuilder = new BodyBuilder();
                        bodyBuilder.HtmlBody =
                        "<p style=\"color:pink\">quastion approve </p>" + "Thank you for asking" + "<p>Unfortunately, the reservation is already available </p>";
                        message.Body = bodyBuilder.ToMessageBody();
                        using (var clinte = new SmtpClient())
                        {
                            clinte.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                            clinte.Authenticate("201810741@std-zuj.edu.jo", "SaFiCo##**00");
                            clinte.Send(message);
                            clinte.Disconnect(true);
                        }
                    } else if (status==0)
                    {
                        MimeMessage message = new MimeMessage();
                        MailboxAddress from = new MailboxAddress(" Reject quastion", "201810741@std-zuj.edu.jo");
                        message.From.Add(from);
                        MailboxAddress to = new MailboxAddress("User", "safiesam3@gmail.com");
                        message.To.Add(to);
                        message.Subject = "About of Reject quastion";
                        BodyBuilder bodyBuilder = new BodyBuilder();
                        bodyBuilder.HtmlBody =
                        "<p style=\"color:pink\">quastion Reject </p>" + "Sorry" + "<p>Unfortunately, the reservation is already available </p>";
                        message.Body = bodyBuilder.ToMessageBody();
                        using (var clinte = new SmtpClient())
                        {
                            clinte.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
                            clinte.Authenticate("201810741@std-zuj.edu.jo", "SaFiCo##**00");
                            clinte.Send(message);
                            clinte.Disconnect(true);
                        }
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

        [HttpPut]
        [Route("UpdateLike")]
        public void Update(Likeanddislike t)
        {
            _likeservice.Update(t);
        }

        [HttpGet]
        [Route("GetLike")]
        public List<Likeanddislike> GetAllLike()
        {

            return _likeservice.GetAll();

        }

        [HttpPost]
        [Route("CreateLike")]
        public void Create(Likeanddislike t)
        {
            _likeservice.Create(t);
        }



    }
}
