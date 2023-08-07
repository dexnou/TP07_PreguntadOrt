public class Respuesta{
    private int IdRespuesta{get;set;}
    private int IdPregunta{get;set;}
    private int Opcion{get;set;}
    private string Contenido{get;set;}
    private bool Correcta{get;set;}
    private string Foto{get;set;}
      

    //no va el constructor porque sino el dapper no puede iniciar porque no se podrian crear las tablas en la base de datos. 
}