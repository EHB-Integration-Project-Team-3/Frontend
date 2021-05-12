using Integration_Project.Models;
using Integration_Project.Models.MUUID.Receive;
using Integration_Project.Models.MUUID.Send;
using Integration_Project.Services.MUUIDService.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.MUUIDService {
    public class MUUIDService : IMUUIDService {

        public Guid InsertIntoMUUID(MUUIDSend sendModel) {
            using (var context = new ReceiverContextMUUID()) {
                var response = context.MUUIDS.FromSqlRaw("SELECT UUID()");
                return response.FirstOrDefault().MUUID;
            }
        }

        public object GetUUID() {
            using (var context = new ReceiverContextMUUID()) {
                var response = context.MUUIDS.FromSqlRaw("SELECT UUID()");
                return response.FirstOrDefault();
            }
        }
    }
}
