using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Magnify.Models;
using Microsoft.AspNet.Identity;
using System.Text;

namespace Magnify.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ventajas()
        {
            return View();
        }

        public IActionResult Precio()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Mail model)
        {
            if (ModelState.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table>");
                sb.Append("<tbody>");
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append($"Nombre:");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append($"{model.Name}");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append($"Email:");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append($"{model.Email}");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append($"Empresa:");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append($"{model.Enterprise}");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append($"Asunto:");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append($"{model.Subject}");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append($"Mensaje:");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append($"{model.Message}");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("</tr>");
                sb.Append("</tbody>");
                sb.Append("</table>");

                var Mail = new IdentityMessage
                {
                    Body = sb.ToString(),
                    Destination = "carlos@xipetechnology.com",
                    Subject = "Contacto"
                };

                var resp = MailController.SendSimpleMessage(Mail);
                Response.StatusCode = (int)resp.StatusCode;
            }
            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
