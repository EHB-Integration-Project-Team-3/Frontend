using Integration_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.EventService.Interface {
    public interface IBaseService<T> {
        public T Get(int Id);
        public List<T> GetAll();
        public List<T> GetAllForUser(Guid UserId);
        public bool Delete(int Id);
        public bool Add(T t);
        public bool Update(T t);
    }
}
