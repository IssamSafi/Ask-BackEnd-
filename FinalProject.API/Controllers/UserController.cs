using FinalProject.core.Data;
using FinalProject.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller<Userf>
    {


        public UserController(IService<Userf> userService) : base(userService)
        {

        }

        [Route("uploadImage")]
        [HttpPost]
        public Userf UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\User\\Documents\\GitHub\\FinalProjectAngular\\src\\assets", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Userf item = new Userf ();
            item.ImagePath = fileName;
            return item;
        }

    }
}

       
