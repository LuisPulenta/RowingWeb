namespace RowingWeb.WEB.Auth
{
    public interface ILoginService
    {

        Task LoginAsync(string token);

        Task LogoutAsync();

        Task GuardarValor(string key, string token);

        Task<string> RecuperarValor(string key);
    }
}
