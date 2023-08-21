using System.Data.SqlClient; 
using Dapper; 

public class BD{
private static string _connectionString = @"Server=localhost;DataBase=PreguntadOrt;Trusted_Connection=True;";
 
    public static List<Categoria> ObtenerCategorias(){
        List<Categoria> listaCategorias;
        using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT * FROM Categorias1";
        listaCategorias = db.Query<Categoria>(sql).ToList();
        }
        return listaCategorias;
    }
    
    public static List<Dificultad> ObtenerDificultades(){
        List<Dificultad> listaDificultades;
        using(SqlConnection db = new SqlConnection(_connectionString)){
        string sql = "SELECT * FROM Dificultades1"; //ver si los nombres de las tablas de la base de datos se llaman igual para verificar. 
        listaDificultades = db.Query<Dificultad>(sql).ToList();
        }
        return listaDificultades;
    }

    public static List<Pregunta> ObtenerPreguntas(int idDificultad, int idCategoria){ //review del profe: son 4 queries distintas segun 4 casos distintos: si dificultad = -1 y categoria no, si dificultad y categoria son -1, si categoria -1 y dificultad no y si ninguna es -1. UTILIZAR WHERE. 
        List<Pregunta> listaPreguntas = new List <Pregunta>(); 
        using(SqlConnection db = new SqlConnection(_connectionString)){ //el problema era que ambos ids que llegaban por parametros eran iguales a 0
            
            if(idDificultad == -1 && idCategoria == -1){
                string sql = "SELECT * FROM Preguntas1"; 
                listaPreguntas = db.Query<Pregunta>(sql).ToList();
            }
            else if(idDificultad == -1 && idCategoria != -1){
                string sql = "SELECT * FROM Preguntas1 WHERE IdCategoria = @IdCategoria"; 
                listaPreguntas = db.Query<Pregunta>(sql, new{IdCategoria = idCategoria}).ToList();
            }
            else if(idCategoria == -1 && idDificultad != -1){
                string sql = "SELECT * FROM Preguntas1 WHERE IdDificultad = @IdDificultad"; 
                listaPreguntas = db.Query<Pregunta>(sql, new{IdDificultad = idDificultad}).ToList();
            }
            // else if(idCategoria != -1 && idDificultad != -1){
            else{
                string sql =  "SELECT * FROM Preguntas1 WHERE IdDificultad = @IdDificultad AND IdCategoria = @IdCategoria"; 
                listaPreguntas = db.Query<Pregunta>(sql, new{IdDificultad = idDificultad, IdCategoria = idCategoria}).ToList();     
            }
            // foreach(var pal in listaPreguntas){
            //     Console.WriteLine(pal.Enunciado);
            // }
        }
        return listaPreguntas;
    }

    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas){
        List<Respuesta> listaRespuestas = new List<Respuesta>();
            
        foreach(Pregunta preg in preguntas){
            string SQL = "SELECT * FROM Respuestas1 WHERE IdPregunta = @pIdPregunta";
            // string SQL = "SELECT * FROM Respuestas";
            using(SqlConnection db = new SqlConnection(_connectionString)){
                listaRespuestas.AddRange(db.Query<Respuesta>(SQL, new{pIdPregunta = preg.IdPregunta}));
            }
        }
        return listaRespuestas;
    }
}