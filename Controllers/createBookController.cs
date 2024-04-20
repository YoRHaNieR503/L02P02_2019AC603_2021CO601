using L02P02_2019AC603_2021CO601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace L02P02_2019AC603_2021CO601.Controllers
{
    public class createBookController : Controller
    {







        private readonly libreriaDbContext _dbContext;

        public createBookController(libreriaDbContext libreriaDbContexto)
        {
            _dbContext = libreriaDbContexto;
        }

        public IActionResult Index()
        {


            var listaLibros = (from l in _dbContext.libros
                               join a in _dbContext.autores on l.id_autor equals a.id
                               join c in _dbContext.categorias on l.id_categoria equals c.id
                               select new {
                                   NombreLibro = l.nombre,
                                   Descripcion = l.descripcion,
                                   Precio = l.precio,
                                   Autor = a.autor,
                                   Categoria = c.categoria
                               }).ToList();
            ViewData["ListadoLibros"] = listaLibros;
/***********************************************************************************************************/
            var listaAutor = (from a in _dbContext.autores
                              select a).ToList();
            ViewData["listaAutores"] = new SelectList(listaAutor, "id", "nombre");
/***********************************************************************************************************/
            var listaCategoria = (from c in _dbContext.categorias
                                  select c).ToList();
            ViewData["listaCategoria"] = new SelectList(listaAutor, "id", "categoria");
/***********************************************************************************************************/

            return View();
        }
    }
}
