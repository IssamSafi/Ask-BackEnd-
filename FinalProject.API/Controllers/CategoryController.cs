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
    public class CategoryController : Controller<Categoryf>
    {


        public CategoryController(IService<Categoryf> categoryService) : base(categoryService)
        {

        }
    
    }
}
