using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class bth212b3Controller: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(bth212b3 ps)
        {
          ps.C=ps.A*ps.B;
          string strOutput = "Don gia " + ps.C+ " VND";
          ViewBag.Z = strOutput;
            return View();
        }
     
    }
}