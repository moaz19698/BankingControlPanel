namespace BankingControlPanel.Application.Users.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string password, string role);
    }
}