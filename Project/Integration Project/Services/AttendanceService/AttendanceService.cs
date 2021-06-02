using Integration_Project.Areas.Identity.Data;
using Integration_Project.Models;
using Integration_Project.Services.EventService.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.AttendanceService
{
    public class AttendanceService : IAttendanceService
    {
        public bool Add(Attendance t)
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    context.Add(t);
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

        public bool Delete(Guid Uuid)
        {
            using (var context = new Integration_ProjectContext()) {
                try {
                    context.Remove(context.Attendances.Where(a => a.Uuid == Uuid).FirstOrDefault());
                    context.SaveChanges();
                    return true;
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }

        public Attendance Get(Guid Id)
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    return context.Attendances
                        .Where(a => a.Uuid == Id)
                        .FirstOrDefault();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public List<Attendance> GetAllForEvent(Guid EventId) {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    return context.Attendances
                        .Where(a => a.EventId == EventId)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public List<Attendance> GetAll()
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    return context.Attendances.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public List<Attendance> GetAllForUser(Guid UserId)
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    return context.Attendances.Where(a => a.UserId == UserId).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public bool Update(Attendance t)
        {
            using (var context = new Integration_ProjectContext())
            {
                try
                {
                    var attendance = context.Attendances.Where(a => a.Uuid == t.Uuid).FirstOrDefault();
                    if (attendance != null)
                    {
                        attendance.UserId = t.UserId;
                        attendance.EventId = t.EventId;
                        context.Update(attendance);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }



        // DUPLICATES

        public bool Delete(int Id) => throw new NotImplementedException();
        public Attendance Get(int Id) => throw new NotImplementedException();
    }
}
