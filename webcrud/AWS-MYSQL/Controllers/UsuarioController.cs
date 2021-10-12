using AWS_MYSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWS_MYSQL.Controllers
{
    public class UsuarioController : Controller
    {

        public ActionResult Index()
        {
            List<Usuario> registros = Usuario.Listar();
            return View(registros);
        }

        public ActionResult Cadastrar(int? id)
        {
            Usuario model = new Usuario();
            if (id.HasValue && id.Value > 0)
                model = Usuario.RecuperarUsuario(id.Value);

            return View(model);
        }

        [HttpPost]
        public ActionResult SalvarUsuario(Usuario model)
        {
            model.Salvar();
            return RedirectToAction("Index");

        }

        public ActionResult DeletarUsuario(int id)
        {
            Usuario.Deletar(id);
            return RedirectToAction("Index");

        }

    }
}
