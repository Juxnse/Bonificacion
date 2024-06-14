using System.Linq;
using System.Web.Mvc;


namespace WebApplication5.Controllers
{
    public class CursosFuncionalidadesController : Controller
    {
        private BonificacionEntities db = new BonificacionEntities();

        // GET: CursosFuncionalidades/BuscarCurso
        public ActionResult BuscarCurso()
        {
            return View();
        }

        // POST: CursosFuncionalidades/BuscarCurso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarCurso(string codigoCurso)
        {
            if (string.IsNullOrEmpty(codigoCurso))
            {
                ModelState.AddModelError("", "Debe ingresar un código de curso.");
                return View();
            }

            Curso curso = db.Curso.FirstOrDefault(c => c.CodigoCurso == codigoCurso);
            if (curso == null)
            {
                ModelState.AddModelError("", "Curso no encontrado.");
                return View();
            }

            return View("DetallesCurso", curso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
