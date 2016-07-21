using GateWay.server.db.interfaces;
using LiteDB;

namespace GateWay.server.db.components
{
    public class DbContext : IDbContext
    {
        public LiteDatabase DB()
        {
            return new LiteDatabase(@"gateway.db");
        }
    }
}
