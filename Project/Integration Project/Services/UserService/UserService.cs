using Integration_Project.Areas.Identity.Data;
using Integration_Project.Services.EventService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.UserService
{
    public class UserService : IUserService {
        public bool Add(User User)
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
                        .First<User>();
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
        public bool Update(User User)
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    var usr = context.Users
                        .Where(u => u.Uuid == User.Uuid)
                        .First<User>();
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
        User IBaseService<User>.Get(Guid Id)
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    return context.Users
                        .Where(u => u.Uuid == Id)
                        .First<User>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
        List<User> IBaseService<User>.GetAll()
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
