using Example.EntyFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.EntyFramework.Controllers
{
    public class BibliotecaController : Controller
    {
        // GET: Biblioteca
        public ActionResult Index()
        {

            List<LibroModel> list = new List<LibroModel>();

            using (var context = new BibliotecaEntities())
            {
                var query = from d in context.Libro
                            join l in context.LibAut on d.IdLibro equals l.IdLibro
                            join a in context.Autor on l.IdAutor equals a.IdAutor
                            select new
                            {
                                ID = d.IdLibro,
                                Titulo = d.Titulo,
                                NombreAutor = a.Nombre
                            };

                foreach (var item in query)
                {
                    LibroModel lib = new LibroModel();
                    lib.Autor = item.NombreAutor;
                    lib.Titulo = item.Titulo;
                    list.Add(lib);
                }
            }


            return View(list);
        }

        [HttpPost]
        public ActionResult agregarLibro(string titulo, string editorial, string area)
        {
            using (var context = new BibliotecaEntities())
            {

                var nuevoLibro = new Libro
                {
                    Titulo = titulo,
                    Editorial = editorial,
                    Area = area
                };

                context.Libro.Add(nuevoLibro);
                context.SaveChanges();

            }

            return View();
        }

        [HttpPost]
        public ActionResult modificarLibro(int id, string titulo, string editorial, string area)
        {
            using (var context = new BibliotecaEntities())
            {

                var student = (from d in context.Libro
                               where d.IdLibro == id
                               select d).Single();
                student.Titulo = titulo;
                student.Editorial = editorial;
                student.Area = area;
                context.SaveChanges();

            }
        

            return View();
        }


    }
}