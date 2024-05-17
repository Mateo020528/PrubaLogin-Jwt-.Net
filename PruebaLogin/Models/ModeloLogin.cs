namespace PRUEBALOGIN.Models
{
    public class LoginModel
    {
        public int Id {get; set; }
        public string? Email {get; set; }
        public string? Password {get; set; }
    }
    //Agregamos la clase De Authenticated
    public class Authenticated
    {
    public string? Token {get; set; }
    }
}