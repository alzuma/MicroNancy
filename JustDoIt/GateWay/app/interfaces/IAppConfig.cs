namespace GateWay.app.interfaces
{
    public interface IAppConfig
    {
        string SecretKey { get; }
        string TokenIssuer { get; }
    }
}
