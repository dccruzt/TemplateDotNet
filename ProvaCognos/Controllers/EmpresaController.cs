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
        public ActionResult Index()
        {
            List<Empresa> model = EmpresaRepository.list();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = EmpresaRepository.get(id);

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Empresa model)
        {
            EmpresaRepository.create(model);

            return RedirectToAction("Details", new { id = model.EmpresaID });
        }

        public ActionResult Edit(int id)
        {
            Empresa model = EmpresaRepository.get(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Empresa model)
        {
            EmpresaRepository.update(model);

            return RedirectToAction("Details", new { id = model.EmpresaID });
        }
    }
}