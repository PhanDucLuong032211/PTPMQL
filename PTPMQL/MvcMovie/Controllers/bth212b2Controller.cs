using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class bth212b2Controller: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(bth212b2 ps)
        {
          ps.D=((ps.A*0.7)+(ps.B*0.2)+(ps.C*0.1));
          string strOutput = "Diem hoc phan: " + ps.D;
          ViewBag.Diem = strOutput;
            return View();
        }
     
    }
}