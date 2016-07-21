using LiteDB;

namespace GateWay.server.db.interfaces
{
    public interface IDbContext
    {
        LiteDatabase DB();
    }
}
