public class Pregunta{
    public int IdPregunta{get;set;}
    public int IdCategoria{get;set;}
    public int IdDificultad{get;set;}
    public string Enunciado {get;set;}
    public string Foto {get;set;}

    //no va el constructor porque sino el dapper no puede iniciar porque no se podrian crear las tablas en la base de datos. 

}