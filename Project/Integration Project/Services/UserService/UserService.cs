﻿using Integration_Project.Areas.Identity.Data;
using Integration_Project.Models;
using Integration_Project.Services.EventService.Interface;
using Integration_Project.Services.UserService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.UserService {
    public class UserService : IUserService {
        public InternalUser Add(InternalUser t) {
            using (var context = new Integration_ProjectContext()) {
                try {
                    var u = context.Add(t);
                    context.SaveChanges();
                    return u.Entity;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return null;
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
                        user.EmailAddress = t.EmailAddress;
                        user.EntityVersion = t.EntityVersion;
                        user.FirstName = t.FirstName;
                        user.LastName = t.LastName;
                        user.Role = t.Role;                       
                        context.Update(user);
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

        bool IBaseService<InternalUser>.Add(InternalUser t) => throw new NotImplementedException();
    }
}
