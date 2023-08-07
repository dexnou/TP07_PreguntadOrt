using System.Data.SqlClient; 
using Dapper; 

public class BD{
private static string _connectionString = @"Server=localhost;DataBase=PreguntadORT;Trusted_Connection=True;";
 
    public static List<Categoria> ObtenerCategorias(){
        List<Categoria> listaCategorias;
        using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT * FROM CATEGORIAS";
        listaCategorias = db.Query<Categoria>(sql).ToList();
        }
        return listaCategorias;
    }
    
    public static List<Dificultad> ObtenerDificultades(){
        List<Dificultad> listaDificultades;
        using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT * FROM DIFICULTAD";
        listaDificultades = db.Query<Dificultad>(sql).ToList();
        }
        return listaDificultades;
    }

    public static List<Pregunta> ObtenerPreguntas(int idDificultad, int idCategoria){ //review del profe: son 4 queries distintas segun 4 casos distintos: si dificultad = -1 y categoria no, si dificultad y categoria son -1, si categoria -1 y dificultad no y si ninguna es -1. UTILIZAR WHERE. 
        List<Pregunta> listaPreguntas; 
        using(SqlConnection db = new SqlConnection(_connectionString)){
            
            if(idDificultad == -1 && idCategoria == -1){
                string sql = ""; 
                listaPreguntas = db.Query<Pregunta>(sql).ToList();
            }
            else if(idDificultad == -1 && idCategoria != -1){
                string sql = "SELECT * FROM PREGUNTAS WHERE IdCategoria = @pIdCategoria"; 
                listaPreguntas = db.Query<Pregunta>(sql).ToList();
            }
            else if(idCategoria == -1 && idDificultad != -1){
                string sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pIdDificultad"; 
                listaPreguntas = db.Query<Pregunta>(sql).ToList();
            }
            else if(idCategoria != -1 && idDificultad != -1){
                string sql = "SELECT * FROM PREGUNTAS"; 
                listaPreguntas = db.Query<Pregunta>(sql).ToList();
            }
            else{
                string sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pIdDificultad AND IdCategoria = @pIdCategoria"; 
                listaPreguntas = db.Query<Pregunta>(sql).ToList();
            }
        }
        return listaPreguntas;
    }

    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas){
        List<Respuesta> listaRespuestas = new List<Respuesta>();
            
        foreach(Pregunta preg in preguntas){
            string SQL = "SELECT * FROM Respuestas WHERE IdPregunta = @pIdPregunta";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                listaRespuestas.AddRange(db.Query<Respuesta>(SQL, new{pIdPregunta = preg.IdPregunta}));
            }
        }
        return listaRespuestas;
    }
}

