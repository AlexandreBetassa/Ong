namespace Ong.Domain.Command.Autenticacao.CreateToken
{
    public class TokenResponse
    {
        public object IdUsuario { get; set; }
        public object Nome { get; set; }
        public object Email { get; set; }
        public string AccessToken { get; set; }
        public string Cpf { get; set; }
    }
}