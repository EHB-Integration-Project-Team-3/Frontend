using Integration_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.EventService.Interface {
    public interface IAttendanceService : IBaseService<Attendance> {
        public bool Delete(Guid Uuid);
        public Attendance Get(Guid Id);
    }
}
