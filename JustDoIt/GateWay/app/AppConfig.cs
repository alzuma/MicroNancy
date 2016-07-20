using System;
using GateWay.app.interfaces;

namespace GateWay.app
{
    class AppConfig : IAppConfig
    {
        public string SecretKey => "{C55F15DA-7DF7-4005-9C65-7167494F80E2}";
        public string TokenIssuer => "GateWay";
    }
}
