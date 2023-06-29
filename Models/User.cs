namespace dotnet.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public DateTime DataNascimento { get; set; }
        public string Password { get; set; } = "";
        public string Role { get; set; } = "";
    }
}