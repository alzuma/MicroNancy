using GateWay.app.interfaces;

namespace GateWay.app
{
    class AppConfig : IAppConfig
    {
        public string SecretKey => "TopSecretKey";
    }
}
