using Integration_Project.Areas.Identity.Data;
using Integration_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration_Project.Services.EventService.Interface;
using Integration_Project.Services.UserService.Interface;

namespace Integration_Project.Services.UserService
{
    public class UserService : IUserService
    {
        public bool Add(InternalUser User)
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    context.Add(User);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
        public bool Delete(Guid Id)
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    var usr = context.Users
                        .Where(u => u.Uuid == Id)
                        .First<InternalUser>();
                    context.Users.Remove(usr);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
        public bool Update(InternalUser User)
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    var usr = context.Users
                        .Where(u => u.Uuid == User.Uuid)
                        .First<InternalUser>();
                    usr = User;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
        InternalUser IBaseService<InternalUser>.Get(Guid Id)
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    return context.Users
                        .Where(u => u.Uuid == Id)
                        .First<InternalUser>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
        List<InternalUser> IBaseService<InternalUser>.GetAll()
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    return context.Users
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
    }
}