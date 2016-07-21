using GateWay.server.db.entities;
using GateWay.server.db.interfaces;

namespace GateWay.server.authentication.interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        void AddUser(UserEntity user);
        UserEntity FindByLogin(string Login);
    }
}