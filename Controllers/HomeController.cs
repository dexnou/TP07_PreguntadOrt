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
        Console.WriteLine("IDS: " + username + " " + dificultad + " " + categoria);
        ViewBag.Username = username; 
        Console.WriteLine("Username en viewBag en comenzar: " + ViewBag.Username); 
        Juego.CargarPartida(username, dificultad, categoria);
        if(username != "" || dificultad >0 && dificultad <=3 || categoria >0 && categoria<=3){
            return RedirectToAction("Jugar");
        }else{
            return RedirectToAction("ConfigurarJuego");
        }
    }

    public IActionResult Jugar(){
        Console.WriteLine("Entro a jugar");
        ViewBag.Pregunta = Juego.ObtenerProximaPregunta(); 
        if(ViewBag.Pregunta != null){ //si ViewBag.Pregunta obtiene una pregunta, continua el juego
            ViewBag.RespuestasAPregunta = Juego.ObtenerProximasRespuestas(ViewBag.Pregunta.IdPregunta);
            return View("Juego");
        }else{ //sino, si se queda sin preguntas, te redirige a fin del juego. 
            Console.WriteLine("AL FIN");
            return View("Fin");
        }
    }

    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){
            Console.WriteLine("Entro a verificarRespuesta de Controller");
        ViewBag.Respuesta = Juego.VerificarRespuesta(idPregunta,idRespuesta);
            Console.WriteLine("Salio de verificarRespuesta de Controller");
        ViewBag.PuntajeFinal = Juego._puntajeActual; //ver si esto funciona...
        return View("Respuesta");
    }
}