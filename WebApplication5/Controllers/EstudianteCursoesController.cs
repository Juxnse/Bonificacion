using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5;

namespace WebApplication5.Controllers
{
    public class EstudianteCursoesController : Controller
    {
        private BonificacionEntities db = new BonificacionEntities();

        // GET: EstudianteCursoes
        public ActionResult Index()
        {
            var estudianteCurso = db.EstudianteCurso.Include(e => e.Curso).Include(e => e.Estudiante);
            return View(estudianteCurso.ToList());
        }

        // GET: EstudianteCursoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstudianteCurso estudianteCurso = db.EstudianteCurso.Find(id);
            if (estudianteCurso == null)
            {
                return HttpNotFound();
            }
            return View(estudianteCurso);
        }

        // GET: EstudianteCursoes/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "CodigoCurso");
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Identificacion");
            return View();
        }

        // POST: EstudianteCursoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstudianteCursoId,EstudianteId,CursoId")] EstudianteCurso estudianteCurso)
        {
            if (ModelState.IsValid)
            {
                db.EstudianteCurso.Add(estudianteCurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "CodigoCurso", estudianteCurso.CursoId);
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Identificacion", estudianteCurso.EstudianteId);
            return View(estudianteCurso);
        }

        // GET: EstudianteCursoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstudianteCurso estudianteCurso = db.EstudianteCurso.Find(id);
            if (estudianteCurso == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "CodigoCurso", estudianteCurso.CursoId);
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Identificacion", estudianteCurso.EstudianteId);
            return View(estudianteCurso);
        }

        // POST: EstudianteCursoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstudianteCursoId,EstudianteId,CursoId")] EstudianteCurso estudianteCurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudianteCurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Curso, "CursoId", "CodigoCurso", estudianteCurso.CursoId);
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Identificacion", estudianteCurso.EstudianteId);
            return View(estudianteCurso);
        }

        // GET: EstudianteCursoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstudianteCurso estudianteCurso = db.EstudianteCurso.Find(id);
            if (estudianteCurso == null)
            {
                return HttpNotFound();
            }
            return View(estudianteCurso);
        }

        // POST: EstudianteCursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstudianteCurso estudianteCurso = db.EstudianteCurso.Find(id);
            db.EstudianteCurso.Remove(estudianteCurso);
            db.SaveChanges();
            return RedirectToAction("Index");
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
