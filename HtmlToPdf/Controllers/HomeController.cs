using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlToPdf.Models;

namespace HtmlToPdf.Controllers
{
    public class HomeController : Controller
    {
        private Pdf pdf;

        public HomeController()
        {
            pdf = new Pdf();
        }

        public ActionResult Index()
        {
            return View();
        }
                

        [HttpGet]
        public FileStreamResult GetPdf()
        {
            try
            {
                return pdf.HtmlToPdf((Html)Session["Html"]);
            }
            catch (Exception ex)
            {                
                return null;
            }

        }

        [HttpPost]
        public ActionResult PostHtml(Html Html)
        {
            var response = new Response();

            try
            {
                Session["Html"] = Html;
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }

            return Json(response);
        }
    }
}