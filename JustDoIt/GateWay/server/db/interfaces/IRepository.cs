using LiteDB;

namespace GateWay.server.db.interfaces
{
    public interface IRepository<T> where T: new()
    {
        LiteCollection<T> GetTable(LiteDatabase db);
    }
}
