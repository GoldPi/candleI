using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuickProject.Areas.Developer.Controllers
{
    public class ManageUserController : Controller
    {
        public ManageUserController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}