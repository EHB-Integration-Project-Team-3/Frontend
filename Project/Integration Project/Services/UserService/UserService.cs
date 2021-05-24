using Integration_Project.Areas.Identity.Data;
using Integration_Project.Models;
using Integration_Project.Services.UserService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.UserService {
    public class UserService : IUserService {
        public bool Add(InternalUser t) {
            using (var context = new Integration_ProjectContext()) {
                try {
                    context.Add(t);
                    context.SaveChanges();
                    return true;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }
        public bool Delete(int Id) => throw new NotImplementedException();
        public InternalUser Get(int Id) => throw new NotImplementedException();
        public InternalUser Get(Guid Id) {
            using (var context = new Integration_ProjectContext()) {
                try {
                    return context.Users.Where(u => u.Uuid == Id).FirstOrDefault();
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                }

            }
        }
        public List<InternalUser> GetAll() => throw new NotImplementedException();
        public List<InternalUser> GetAllForUser(Guid UserId) => throw new NotImplementedException();
        public bool Update(InternalUser t) {
            using (var context = new Integration_ProjectContext()) {
                try {
                    var user = context.Users.Where(u => u.Uuid == t.Uuid).FirstOrDefault();
                    if (user != null) {
                        context.Update(t);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return false;
                }

            }
        }

        public InternalUser Validate(string email, string wachtwoord) {
            //TODO: adding password check!!!
            using (var context = new Integration_ProjectContext()) {
                try {
                    var user = context.Users.Where(u => u.EmailAddress == email).FirstOrDefault();
                    if (user != null) {
                        return user;
                    }
                    return null;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                }

            }
        }
    }
}
