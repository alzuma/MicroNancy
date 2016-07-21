using System;
using GateWay.server.authentication.interfaces;
using GateWay.server.db.entities;
using GateWay.server.db.interfaces;
using LiteDB;
using System.Linq;

namespace GateWay.server.authentication.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public LiteCollection<UserEntity> GetTable(LiteDatabase db)
        {
            return db.GetCollection<UserEntity>("user");
        }

        public void AddUser(UserEntity user)
        {
            using (var db = _dbContext.DB())
            {
                var users = GetTable(db);

                users.EnsureIndex(x => x.Login, true);

                users.Insert(user);
            }
        }

        public UserEntity FindByLogin(string Login)
        {
            using (var db = _dbContext.DB())
            {
                var users = GetTable(db);
                var result = users.Find(x => x.Login == Login);
                return result.FirstOrDefault();
            }
        }
    }
}
