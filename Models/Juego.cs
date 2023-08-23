public static class Juego{
    private static string _username{get;set;}
    public static int _puntajeActual{get;set;} //tendria que ser private pero para que funcione esta asi. 
    private static int  _cantidadPreguntasCorrectas{get;set;}
    private static List<Pregunta> _preguntas{get;set;}
    private static List<Respuesta> _respuestas{get;set;}
    private static bool _fin = false;
    private static int contador = 0;
    private static List<Pregunta> ListaPreguntasHechas = new List<Pregunta>(); //guarda las preguntas ya hechas para evitar que se repitan jaja. 

   
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
    public static Pregunta ObtenerProximaPregunta(){ //agregar una lista que guarde todas las preguntas ya hechas para evitar que se repitan y para que cuando todas hayan sido respondidas se pueda terminar el juego. fz lo hace.
        
        Random random = new Random();
        Pregunta preguntaRandom;
        int indiceAleatorio;
        
        do{
            Console.WriteLine("Entro al do while de ObtenerProximaPregunta");
            indiceAleatorio = random.Next(0, _preguntas.Count); //cambiar para que solo elija preguntas de la categoria elegida por el usuario. 
            preguntaRandom = _preguntas[indiceAleatorio];
            Console.WriteLine("Lista preguntas hechas: " + ListaPreguntasHechas.Count);
        }while(ListaPreguntasHechas.Contains(preguntaRandom) && ListaPreguntasHechas.Count < 2);

        // while(ListaPreguntasHechas.Contains(preguntaRandom) ){
        //     indiceAleatorio = random.Next(0, _preguntas.Count); //cambiar para que solo elija preguntas de la categoria elegida por el usuario. 
        //     preguntaRandom = _preguntas[indiceAleatorio];
            
        // }
        Console.WriteLine("Salio del do while");
        ListaPreguntasHechas.Add(preguntaRandom);
        contador++;
        if(ListaPreguntasHechas.Count > 2){
            preguntaRandom = null; 
        }
        return preguntaRandom;
    }

    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta){ //cada pregunta tiene 3 opciones de respuesta. solo 1 opcion es correcta. tiene que mostrar esas 3 opciones. 
        List<Respuesta> ListaPosiblesRespuestas = new List<Respuesta>();
        Console.WriteLine(_respuestas[0].IdRespuesta);
        for(int i=0; i<_respuestas.Count; i++){ //se podria tambien hacer un foreach pero es lo mismo. aunque el foreach es mas limpio. 
            System.Console.WriteLine(idPregunta);
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
        // Console.WriteLine("Contenido: " + _respuestas[idRespuesta].Contenido); No se porque no anda esto y tira error. 
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
            }
        }
        int i = 0; 

        while(i < _preguntas.Count){
            if(_preguntas[i].IdPregunta == idPregunta){
                _preguntas.Remove(_preguntas[i]);
                Console.WriteLine("Borro la pregunta");
            }
            i++;
        }
        return validacion;  
    }
}