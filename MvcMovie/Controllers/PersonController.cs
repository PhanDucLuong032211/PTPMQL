using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Person ps)
        {
           string strOutput="xin chao"+ps.PersonId+" "+ps.FullName+""+ps.Address;
           ViewBag.infoPerson=strOutput;
            return View();
        }
     
    }
}