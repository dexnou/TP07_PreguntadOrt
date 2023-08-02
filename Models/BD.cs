using System.Data.SqlClient; 
using Dapper; 

public class BD{
private static string _connectionString = @"Server=localhost;DataBase=PreguntadOrt;Trusted_Connection=True;";
 
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

    public static List<Pregunta> ObtenerPreguntas(int idDificultad, int idCategoria){
        List<Pregunta> listaPreguntas;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            if(idDificultad == -1){
                string sql = "SELECT * FROM DIFICULTAD"; //revisar si esta bien asi la query
            }
            if(idCategoria == -1){
                string sql = "SELECT * FROM CATEGORIAS";
            }
        }

        return listaPreguntas; 
    }
    
    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas){
        List<Respuesta> listaRespuestas;
        
    }
}

