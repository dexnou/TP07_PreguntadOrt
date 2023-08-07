﻿using Microsoft.AspNetCore.Mvc;

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
        Juego.CargarPartida(username, dificultad, categoria);

        if(username =! "" || dificultad >0 && dificultad <=3 || categoria >0 && categoria<=3){
            return RedirectToAction("Jugar");
        }else{
            return RedirectToActrion("ConfigurarJuego");
        }
    }

    public IActionResult Jugar(){
        ViewBag.Pregunta = Juego.ObtenerProximaPregunta(); 
        if(ViewBag.Pregunta != null){ //si ViewBag.Pregunta obtiene una pregunta, continua el juego
            ViewBag.RespuestasAPregunta = Juego.ObtenerProximasRespuestas();
            return View("Juego");
        }else{ //sino, si se queda sin preguntas, te redirige a fin del juego. 
            return View("Fin");
        }
    }


    [HttpPost]public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){
        ViewBag.Respuesta = Juego.VerificarRespuesta(idPregunta,idRespuesta);
        return View("Respuesta");
    }
}
