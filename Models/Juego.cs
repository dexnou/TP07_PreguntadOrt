public static class Juego{
    private static string _username{get;set;}
    public static int _puntajeActual{get;set;} //tendria que ser private pero para que funcione esta asi. 
    private static int  _cantidadPreguntasCorrectas{get;set;}
    private static List<Pregunta> _preguntas{get;set;}
    private static List<Respuesta> _respuestas{get;set;}
    private static bool _fin = false;

   
    public static bool Fin{
        get{return _fin;}
        set{_fin = value;}
    }
    public static void InicializarJuego(){
        _username = "";
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
    }

    public static List<Categoria> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }

    public static List<Dificultad> ObtenerDificultades(){
        return BD.ObtenerDificultades();
    }

    public static void CargarPartida(string username, int dificultad, int categoria){
        _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        _respuestas = BD.ObtenerRespuestas(_preguntas);
        _username = username;
    }
    public static Pregunta ObtenerProximaPregunta(){ 
        Random random = new Random();
        Pregunta preguntaRandom = null;
        int indiceAleatorio;

            indiceAleatorio = random.Next(0, _preguntas.Count); 
            Console.WriteLine("Indice aleatorio: " + indiceAleatorio);

            if (indiceAleatorio >= 0 && indiceAleatorio < _preguntas.Count) {
                preguntaRandom = _preguntas[indiceAleatorio];
                Console.WriteLine("pregunta random: " + preguntaRandom.Enunciado);
            } else {
                Console.WriteLine("Índice fuera de rango");
                preguntaRandom = null;
            }

        return preguntaRandom;
    }

    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta){ //cada pregunta tiene 3 opciones de respuesta. solo 1 opcion es correcta. tiene que mostrar esas 3 opciones. 
        List<Respuesta> ListaPosiblesRespuestas = new List<Respuesta>();
        Console.WriteLine(_respuestas[0].IdRespuesta);
        for(int i=0; i<_respuestas.Count; i++){ //se podria tambien hacer un foreach pero es lo mismo. aunque el foreach es mas limpio. 
            Console.WriteLine(idPregunta);
            if(_respuestas[i].IdPregunta == idPregunta){
                ListaPosiblesRespuestas.Add(_respuestas[i]);
            }
        }
        // int j = 0;
        // foreach(Respuesta respuesta in _respuestas){
        //     if(respuesta.IdPregunta == idPregunta){
        //         ListaPosiblesRespuestas.Add(_respuestas[j]);
        //     }
        //     j++;
        // }
        
        return ListaPosiblesRespuestas;
    }

    public static bool VerificarRespuesta(int idPregunta, int idRespuesta){ 
        bool validacion = false; 
        Console.WriteLine("Entro a verificarRespuesta de Juego");
        Console.WriteLine("IdRespuesta: " + idRespuesta);
        Console.WriteLine("IdPregunta: " + idPregunta);
     
        Respuesta respuestaCorrecta = new Respuesta();
        

        foreach(Respuesta r in _respuestas){
            if(r.Correcta == true && r.IdPregunta == idPregunta){
                respuestaCorrecta = r;
            }
        }
        Console.WriteLine("Respuesta correcta: " + respuestaCorrecta.Contenido + ". IdPregunta: " + respuestaCorrecta.IdPregunta);
        if(idPregunta == respuestaCorrecta.IdPregunta){
            Console.WriteLine("Mismo idPregunta");
            if(idRespuesta == respuestaCorrecta.IdRespuesta){
                Console.WriteLine("Mismo idRespuesta");
                validacion = true;
                _puntajeActual++;
            }
        }
        int i = 0; 

        while(i < _preguntas.Count){ 
            if(_preguntas[i].IdPregunta == idPregunta){
                _preguntas.Remove(_preguntas[i]);
                Console.WriteLine("BORRO LA PREGUNTA");
                
            }
            i++;
        }
        
        return validacion;  
    }
}