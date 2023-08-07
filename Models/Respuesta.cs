public class Respuesta{
    public int IdRespuesta{get;set;}
    public int IdPregunta{get;set;}
    public int Opcion{get;set;}
    public string Contenido{get;set;}
    public bool Correcta{get;set;}
    public string Foto{get;set;}
      

    //no va el constructor porque sino el dapper no puede iniciar porque no se podrian crear las tablas en la base de datos. 
}