namespace SysPedidos.Model
{
    public class Login
    {
        public long LoginId { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public Cliente ClienteId { get; set; }
    }
}
