public class Juego{
    private static string _username{get;set;}
    private static int _puntajeActual{get;set;}
    private static int  _cantidadPreguntasCorrectas{get;set;}
    private static List<Pregunta> _preguntas{get;set;}
    private static List<Respuesta> _respuestas{get;set;}


    public static void InicializarJuego(string username){
        _username = username;
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
        List<Pregunta> _preguntas= new List<Pregunta>();
        List<Respuesta> _respuesta = new List<Respuesta>();
    }

    public void ObtenerCategorias(){

    }

    public void ObtenerDificultades(){

    }

    public void CargarPartida(string username, int dificultad, int categoria){
        if(dificultad == 1){
            if(categoria == 1){
                _preguntas = BD.ObtenerPreguntas( 1, 1);
                _respuestas = BD.ObtenerRespuestas(List<Pregunta> _preguntas);
            }
        }
    }
}

