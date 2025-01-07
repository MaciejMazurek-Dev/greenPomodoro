namespace greenPomodoro.Application.Contracts.Identity
{
    public interface IAuthService
    {
        public string Login(string email, string password);
        public bool Register(string email, string password);
    }
}
