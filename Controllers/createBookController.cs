using L02P02_2019AC603_2021CO601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            ViewData["listaAutores"] = new SelectList(listaAutor, "id", "autor");
/***********************************************************************************************************/
            var listaCategoria = (from c in _dbContext.categorias
                                  select c).ToList();
            ViewData["listaCategoria"] = new SelectList(listaCategoria, "id", "categoria");
/***********************************************************************************************************/

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GuardarLibro(string nombre, string descripcion, decimal precio, int autorId, int categoriaId)
        {
            var nuevoLibro = new libros
            {
                nombre = nombre,
                descripcion = descripcion,
                precio = precio,
                id_autor = autorId,
                id_categoria = categoriaId 
            };

            _dbContext.libros.Add(nuevoLibro);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }


    }
}
