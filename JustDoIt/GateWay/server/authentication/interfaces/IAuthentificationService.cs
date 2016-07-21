namespace GateWay.server.authentication.interfaces
{
    public interface IAuthentificationService
    {
        void AddAdminUser();
        string GenerateJwtToken();
    }
}
