using EmpresasCrudJL.Datos;
using EmpresasCrudJL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EmpresasCrudJL.Controllers
{
    public class MantenedorController : Controller
    {
        JugadorDatos jugadorDatos = new JugadorDatos();

        public IActionResult Listar()
        {
            //La vista muestra una lista de contactos
            var oLista = jugadorDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Devuelve solo la vista
            return View();
        }


        [HttpPost]
        public IActionResult Guardar(JugadorModel oJugador)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = jugadorDatos.Guardar(oJugador);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int ID)
        {

            var oJugador = jugadorDatos.Obtener(ID);
            return View(oJugador); // Pasa el modelo a la vista Editar.cshtml
        }


        [HttpPost]
        public IActionResult Editar(JugadorModel oJugador)
        {
            if (!ModelState.IsValid)
            {
                return View(oJugador);  // Asegúrate de devolver el modelo aquí
            }

            var respuesta = jugadorDatos.Editar(oJugador);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(oJugador);  // También devolver el modelo si la edición falla
            }
        }

        public IActionResult Eliminar(int ID)
        {
            //Devuelve solo la vista
            var oJugador = jugadorDatos.Obtener(ID);
            return View(oJugador);
        }


        [HttpPost]
        public IActionResult Eliminar(JugadorModel oJugador)
        {

            var respuesta = jugadorDatos.Eliminar(oJugador.ID);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }


    }
}
