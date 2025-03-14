using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Text.Encodings.Web;
namespace MvcMovie.Controllers
{
    public class bth212b1Controller: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(bth212b1 ps)
        {
          ps.BMI = ps.Weight / (ps.Height * ps.Height);
          string strOutput = "Chỉ số BMI của bạn là: " + ps.BMI;
          ViewBag.BMI = strOutput;
            return View();
        }
     
    }
}