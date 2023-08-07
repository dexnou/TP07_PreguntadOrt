using Microsoft.AspNetCore.Mvc;

namespace TP07_PreguntadOrt.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConfigurarJuego(){
        Juego.InicializarJuego();
        
        ViewBag.Categoria = Juego.ObtenerCategorias();
        ViewBag.Dificultad = Juego.ObtenerDificultades();
        return View();
    }

    public IActionResult Comenzar(string username, int dificultad, int categoria){
        ViewBag.Username = username;
        Juego.CargarPartida(username, dificultad, categoria);
        if(username != "" || dificultad >0 && dificultad <=3 || categoria >0 && categoria<=3){
            return RedirectToAction("Jugar");
        }else{
            return RedirectToAction("ConfigurarJuego");
        }
    }

    public IActionResult Jugar(int idPregunta){
        ViewBag.Pregunta = Juego.ObtenerProximaPregunta(); 
        if(ViewBag.Pregunta != null){ //si ViewBag.Pregunta obtiene una pregunta, continua el juego
            ViewBag.RespuestasAPregunta = Juego.ObtenerProximasRespuestas(idPregunta);
            return View("Juego");
        }else{ //sino, si se queda sin preguntas, te redirige a fin del juego. 
            return View("Fin");
        }
    }


    [HttpPost]public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){
        ViewBag.Respuesta = Juego.VerificarRespuesta(idPregunta,idRespuesta);
        ViewBag.PuntajeFinal = Juego._puntajeActual; //ver si esto funciona...
        return View("Respuesta");
    }
}
