namespace BankingControlPanel.Application.Common.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(string email, string password);
    }
}