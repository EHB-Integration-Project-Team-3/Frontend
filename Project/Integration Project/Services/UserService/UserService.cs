using Integration_Project.Models;
using Integration_Project.Services.UserService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.UserService {
    public class UserService : IUserService {
        public bool Add(InternalUser t) => throw new NotImplementedException();
        public bool Delete(int Id) => throw new NotImplementedException();
        public InternalUser Get(int Id) => throw new NotImplementedException();
        public List<InternalUser> GetAll() => throw new NotImplementedException();
        public List<InternalUser> GetAllForUser(Guid UserId) => throw new NotImplementedException();
        public bool Update(InternalUser t) => throw new NotImplementedException();
    }
}
