public class Juego{
    private static string _username{get;set;}
    private static int _puntajeActual{get;set;}
    private static int  _cantidadPreguntasCorrectas{get;set;}
    private static List<Pregunta> _preguntas{get;set;}
    private static List<Respuesta> _respuestas{get;set;}
    private static bool _fin = false;

    public static bool Fin{
        get{return _fin;}
        set{_fin = value;}
    }
    public static void InicializarJuego(){
        /*Aca le pueden mandar el nombre que ingreso el usuario por parametros y configurarlo ahora dice que tiene que estar vacio el nombre en la consigna.*/
        _username = "";
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
        List<Pregunta> _preguntas= new List<Pregunta>();
        List<Respuesta> _respuesta = new List<Respuesta>();
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
    }

    public Pregunta ObtenerProximaPregunta(){ //agregar una lista que guarde todas las preguntas ya hechas para evitar que se repitan y para que cuando todas hayan sido respondidas se pueda terminar el juego. fz lo hace.
        Random random = new Random();
        int indiceAleatorio = random.Next(0, _preguntas.Count);
        Pregunta preguntaRandom = _preguntas[indiceAleatorio];
        return preguntaRandom;
    }

    public List<Respuesta> ObtenerProximasRespuestas(int idPregunta){ //cada pregunta tiene 3 opciones de respuesta. solo 1 opcion es correcta. tiene que mostrar esas 3 opciones. 
        List<Respuesta> ListaPosiblesRespuestas = new List<Respuesta>();

        for(int i=0; i<_respuestas.Count; i++){ //se podria tambien hacer un foreach pero es lo mismo. aunque el foreach es mas limpio. 
            if(_respuestas[i].IdPregunta == idPregunta){
                ListaPosiblesRespuestas.Add(_respuestas[i]);
            }
        }
        return ListaPosiblesRespuestas;
    }

    public bool VerificarRespuesta(int idPregunta, int idRespuesta){ //terminar
        bool validacion = false; 

        foreach(Respuesta respuesta in _respuestas){
            if( respuesta.correcta == true){
                validacion = true; 
                _puntajeActual++;
                _cantidadPreguntasCorrectas++;
            }
        }
        return validacion; 
    }
}


