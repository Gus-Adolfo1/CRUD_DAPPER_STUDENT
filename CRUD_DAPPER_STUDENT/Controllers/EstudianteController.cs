using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Logic;

namespace CRUD_DAPPER_STUDENT.Controllers
{
    public class EstudianteController : Controller
    {
        LogicStudent logicStudent = new LogicStudent();
        // GET: EstudianteController
        public ActionResult Index()
        {
            var roles = logicStudent.getAll();
            return View(roles);
        }

        // GET: EstudianteController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener el usuario

            var estudiante = logicStudent.getId(id);

            if (estudiante == null)
            {
                return NotFound();
            }


            return View(estudiante);


        }

        // GET: EstudianteController/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: EstudianteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudiante estudiante)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    logicStudent.Create(estudiante);

                    TempData["mensaje"] = "El usuario se ha creado correctamente";
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(estudiante);
            }
        }

        // GET: EstudianteController/Edit/5
        public ActionResult Edit(int id)
        {


            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener el usuario

            var estudiante = logicStudent.getId(id);

            if (estudiante == null)
            {
                return NotFound();
            }


            return View(estudiante);
        }




        // POST: EstudianteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Estudiante estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pCliente = logicStudent.Update(estudiante, estudiante.Id);
                    TempData["mensaje"] = "El usuario se ha actualizado correctamente";
                    return RedirectToAction("Index");
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(estudiante);
            }
        }

        // GET: EstudianteController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Obtener el usuario

            var estudiante = logicStudent.getId(id);

            if (estudiante == null)
            {
                return NotFound();
            }


            return View(estudiante);

        }

          
        

        // POST: EstudianteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Estudiante estudiante)
        {
            try
            {
                var pEstudiante = logicStudent.Delete(estudiante.Id);
                TempData["mensaje"] = "El Estudiante se ha borrado correctamente";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
