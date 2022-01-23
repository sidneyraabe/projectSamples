using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Mock
{
    public class UserRepositoryMock : IUserRepository
    {
        private List<User> _mockUsers;
        public UserRepositoryMock()
        {
            _mockUsers = new List<User>()
            {
                new User
                {
                    Id = "00000000-0000-0000-0000-000000000000",
                    RoleId = 1,
                    Email = "testuser@test.net",
                    LastName = "Last",
                    FirstName ="First"
                    //name
                },
                new User
                {
                    Id = "11111111-1111-1111-1111-111111111111",
                    RoleId = 1,
                    Email = "testuser2@test.net",
                    LastName = "Last",
                    FirstName ="First"
                //name
                }
            };
        }

        public List<User> GetAll()
        {
            return _mockUsers;
        }
    }
}
