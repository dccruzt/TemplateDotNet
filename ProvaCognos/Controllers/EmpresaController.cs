using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvaCognos.Models;

namespace ProvaCognos.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            List<Empresa> model = EmpresaRepository.list();

            return View(model);
        }
    }
}