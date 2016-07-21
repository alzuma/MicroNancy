using System.Collections.Generic;

namespace GateWay.server.db.entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            Role = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<string> Role { get; set; }
    }
}
