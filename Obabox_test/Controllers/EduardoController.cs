using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obabox_test.Models;

namespace Obabox_test.Controllers
{
    public class EduardoController : Controller
    {
        public ActionResult Estudante()
        {
            return View();
        }

        public JsonResult Estudante_SelecionarFiltro(EstudanteTesteEduardo.Filtro Filtro)
        {
            JsonResult result = new JsonResult() { Data = EstudanteTesteEduardo.SelecionarFiltro(Filtro)};
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EstudanteEditar()
        {
            EstudanteTesteEduardo Estudante = new EstudanteTesteEduardo();
            if (RouteData.Values["id"] != null)
                Estudante = EstudanteTesteEduardo.Selecionar(Convert.ToInt32(RouteData.Values["id"]));
            return View(Estudante);
        }

        public string EstudanteEditar_Alterar(EstudanteTesteEduardo Estudante) 
        {
            string Identificador = Estudante.Identificador.ToString();
            if(Estudante.Identificador != default(int))
            {
                EstudanteTesteEduardo.Alterar(Estudante);
               
            }
            else
            {
                Identificador= EstudanteTesteEduardo.Inserir(Estudante);
              
            }
            return Identificador;
        }


    }
}