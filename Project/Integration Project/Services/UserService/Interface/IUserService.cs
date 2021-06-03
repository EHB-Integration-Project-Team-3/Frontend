using Integration_Project.Models;
using Integration_Project.Services.EventService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.UserService.Interface {
    public interface IUserService : IBaseService<InternalUser> {
        public InternalUser Get(Guid Id);
        public InternalUser Add(InternalUser t);
        public InternalUser Validate(string email, string wachtwoord);
    }
}
